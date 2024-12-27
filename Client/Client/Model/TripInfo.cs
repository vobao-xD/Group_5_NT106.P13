using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class TripInfo
    {
        public int TripId { get; set; }
        public string Plate { get; set; }
        public int SeatNum { get; set; }
        public string DepartLocation { get; set; }
        public string ArriveLocation { get; set; }
        public DateTime DepartTime { get; set; }
        public int? TripStatusId { get; set; }
        public string TripStatusName { get; set; }
    }
}
