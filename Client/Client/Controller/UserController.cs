using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Controller
{
    public class UserController
    {
        private readonly HttpClient _httpClient;
        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> SignUpAsync(string username, string password, string fullname, string email, int userrole)
        {
            var signUpURL = "http://127.0.0.1:8002/create_user/";
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
                return $"Error: {response.StatusCode}: {errorContent}";
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return $"Sign Up Successfully";
        }
    }
}
