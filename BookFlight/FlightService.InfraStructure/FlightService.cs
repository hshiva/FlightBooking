using System.Collections.Generic;
using FlightService.Core.InfraStructure;
using TravelRepublic.FlightCodingTest;
using static Models.FlightInformation.FlightInformation;

namespace FlightService.InfraStructure
{
    public abstract class FlightService : IFlightService
    {
        public List<Flight> GetFlightDetails()
        {
            FlightBuilder filghtInfo = FlightBuilder.GetIntance;
            return filghtInfo.GetFlights();
        }
    }
}
