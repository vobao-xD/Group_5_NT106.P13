namespace Client.Model
{
    public class TicketInfoModel
    {
        public int TicketId { get; set; }
        public int? TripId { get; set; }
        public string PlateNumber { get; set; }
        public string DepartLocation { get; set; }
        public string ArriveLocation { get; set; }
        public DateTime DepartTime { get; set; }
        public List<int> SeatIds { get; set; }
        public string UserFullName { get; set; }

    }
}