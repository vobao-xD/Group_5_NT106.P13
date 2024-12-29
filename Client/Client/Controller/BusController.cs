using System.Text;
using System.Text.Json;
using Client.Model;

namespace Client
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
        public async Task<List<TripInfo>> GetAllTripsAsync()
        {
            var getAllTripsURL = baseURL + "/getAllTrip";

            var response = await _httpClient.GetAsync(getAllTripsURL);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error: {response.StatusCode}: {errorContent}");
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            var tripInfo = JsonSerializer.Deserialize<List<TripInfo>>(responseContent);
            return tripInfo;
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
        public async Task<ReturnMessage> CreateTripAsync(string plate, int seatNum, int busStatusId, string departLocation, string arriveLocation, DateTime departTime, int tripStatusId)
        {
            var createTripURL = baseURL + "/create_trip/";

            var tripData = new
            {
                plate = plate,
                seat_num = seatNum,
                bus_status_id = busStatusId,
                depart_location = departLocation,
                arrive_location = arriveLocation,
                depart_time = departTime,
                trip_status_id = tripStatusId
            };

            var content = new StringContent(JsonSerializer.Serialize(tripData), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(createTripURL, content);

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
