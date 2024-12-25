using Client.Model;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Controller
{
    public class BusController
    {
        private string baseURL = "http://127.0.0.1:8002";
        private readonly HttpClient _httpClient;
        public BusController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<BusInfo>> GetAllBusAsync()
        {
            var getAllBusURL = baseURL + "/getAllBus";
            var response = await _httpClient.GetAsync(getAllBusURL);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error: {response.StatusCode}: {errorContent}");
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            var busInfo = JsonSerializer.Deserialize<List<BusInfo>>(responseContent);
            return busInfo;
        }
        public async Task<List<GetSeatBookedModel>> GetSeatBookedsAsync(int busId, int isBooked)
        {
            var getSeatBookedURL = baseURL + $"/getSeatBooked?busid={busId}&isbook={isBooked}";

            var response = await _httpClient.GetAsync(getSeatBookedURL);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error: {response.StatusCode}: {errorContent}");
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            var seatBooked = JsonSerializer.Deserialize<List<GetSeatBookedModel>>(responseContent);
            return seatBooked;
        }
        public async Task<ReturnMessage> UpdateSeatToBookedAsync(int seatId)
        {
            var updateURL = baseURL + "/updateSeatToBooked";
            var updateData = new
            {
                seatid = seatId
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
    }
}
