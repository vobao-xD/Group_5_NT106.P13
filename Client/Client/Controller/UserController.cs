using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Client.Model;

namespace Client
{
    public class UserController
    {
        private readonly HttpClient _httpClient;
        private string baseURL = "http://127.0.0.1:8002";
        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ReturnMessage> SignUpAsync(string username, string password, string fullname, string email, int userrole)
        {
            var signUpURL = baseURL + "/create_user/";
            var userdata = new
            {
                username = username,
                password = password,
                fullname = fullname,
                email = email,
                userroleid = userrole
            };
            var content = new StringContent(JsonSerializer.Serialize(userdata), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(signUpURL, content);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error: {response.StatusCode}: {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ReturnMessage>(responseContent);
        }
        public async Task<AuthToken> LoginAsync(string username, string password)
        {
            var loginURL = baseURL + "/login/";
            var loginData = new
            {
                username = username,
                password = password
            };

            var content = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(loginURL, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error: {response.StatusCode}: {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var authToken = JsonSerializer.Deserialize<AuthToken>(responseContent);
            return authToken;
        }
        public async Task<UserInfo> UserInfoAsync(string username, string password, AuthToken authToken)
        {
            var loginURL = baseURL + "/userinfo/";
            var loginData = new
            {
                username = username,
                password = password
            };

            var content = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authToken.TokenType, authToken.AccessToken);

            var response = await _httpClient.PostAsync(loginURL, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error: {response.StatusCode}: {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var userinfo = JsonSerializer.Deserialize<UserInfo>(responseContent);
            return userinfo;
        }
        public async Task<List<CustomerInfo>> CustomerInfoAsync(int userRoleId)
        {
            var customerURL = baseURL + $"/getlistcustomer?userroleid={userRoleId}";
            var response = await _httpClient.GetAsync(customerURL);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error: {errorContent}");
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            var customerInfo = JsonSerializer.Deserialize<List<CustomerInfo>>(responseContent);
            return customerInfo;
        }
        public async Task<ReturnMessage> UpdateCustomerVIPAsync(int userId)
        {
            var updateURL = baseURL + "/updateVipCustomer";
            var updateData = new
            {
                userid = userId
            };
            var content = new StringContent(JsonSerializer.Serialize(updateData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(updateURL, content);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error: {response.StatusCode}: {errorContent}");
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ReturnMessage>(responseContent);
            return result;
        }
        public async Task<ReturnMessage> UpdateCustomerRegularAsync(int userId)
        {
            var updateURL = baseURL + "/updateRegularCustomer";
            var updateData = new
            {
                userid = userId
            };
            var content = new StringContent(JsonSerializer.Serialize(updateData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(updateURL, content);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error: {response.StatusCode}: {errorContent}");
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ReturnMessage>(responseContent);
            return result;
        }
        public async Task<TicketInfoModel> GetTicketInfoAsync(string userEmail, int ticketId)
        {
            var ticketInfoURL = baseURL + "/ticket_info/";
            var requestData = new { UserEmail = userEmail, TicketId = ticketId };
            var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");
            HttpResponseMessage response;
            try
            {
                response = await _httpClient.PostAsync(ticketInfoURL, content);
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error: {response.StatusCode} - {errorContent}");
                }
                var responseContent = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(responseContent))
                {
                    throw new Exception("Received empty response from the server.");
                }
                if (responseContent.Contains("ErrorResponse"))
                {
                    return new TicketInfoModel(-1);
                }
                var ticket = JsonSerializer.Deserialize<TicketInfoModel>(responseContent);
                if (ticket == null)
                {
                    throw new Exception("Deserialization failed or ticket information is missing.");
                }
                return ticket;
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception($"HTTP Request failed: {httpEx.Message}");
            }
            catch (JsonException jsonEx)
            {
                throw new Exception($"JSON Deserialization failed: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }
    }
}
