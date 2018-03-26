using System.Collections.Generic;
using Models.FlightInformation;

namespace FlightService.Core.InfraStructure
{
    public interface IFlightService
    {
        List<FlightInformation.Flight> GetFlightDetails();
    }
}
