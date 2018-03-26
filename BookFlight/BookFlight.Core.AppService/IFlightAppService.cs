using Models.FlightInformation;
using System.Collections.Generic;

namespace BookFlight.Core.AppService
{
    public interface IFlightAppService
    {
        List<FlightInformation.Flight> GetFlightDetails();
    }
}
