namespace Client.Model
{
    public class TicketInfo
    {
        public int TicketId { get; set; }
        public int? TripId { get; set; }
        public string PlateNumber { get; set; }
        public string DepartLocation { get; set; }
        public string ArriveLocation { get; set; }
        public DateTime DepartTime { get; set; }
        public List<int> SeatIds { get; set; }
        public string UserFullName { get; set; }

        public static implicit operator List<object>(TicketInfo v)
        {
            throw new NotImplementedException();
        }
    }
}