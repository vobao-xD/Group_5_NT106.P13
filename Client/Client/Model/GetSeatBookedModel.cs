namespace Client.Model
{
    public class GetSeatBookedModel
    {
        public string LicensePlate { get; set; }
        public string SeatName { get; set; }
        public bool? IsBook { get; set; }
        public int SeatId { get; set; }
    }
}
