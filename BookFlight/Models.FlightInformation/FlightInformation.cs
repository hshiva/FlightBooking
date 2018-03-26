using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FlightInformation
{
    public class FlightInformation
    {
        public class Flight
        {
            public IList<Segment> Segments { get; set; }
        }

        public class Segment
        {
            public DateTime? DepartureDate { get; set; }
            public DateTime? ArrivalDate { get; set; }
        }
    }
}
