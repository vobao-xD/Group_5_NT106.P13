using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class TicketInfoModel2
    {
        public int TicketId { get; set; }
        public int? TripId { get; set; }
        public string PlateNumber { get; set; }
        public string DepartLocation { get; set; }
        public string ArriveLocation { get; set; }
        public DateTime DepartTime { get; set; }
        public List<string> SeatList { get; set; }
        public string UserFullName { get; set; }

        public TicketInfoModel2() { }
        public TicketInfoModel2(int ticketId) { this.TicketId = ticketId; }

    }
}


