using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
