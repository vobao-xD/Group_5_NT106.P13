using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class BusInfo
    {
        public int BusId { get; set; }
        public string LicensePlate { get; set; }
        public int SeatNum { get; set; }
        public int? BusStatusId { get; set; }
    }
}
