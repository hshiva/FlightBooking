using System.Collections.Generic;
using BookFlight.Core.AppService;
using FlightService.Core.InfraStructure;
using Models.FlightInformation;
namespace BookFlight.AppService
{
    public abstract class FlightAppService : IFlightAppService
    {
        private readonly IFlightService _flightService = null;
        public FlightAppService(IFlightService service)
        {
            _flightService = service;
        }
        public List<FlightInformation.Flight> GetFlightDetails()
        {
            return _flightService.GetFlightDetails();
        }
    }
}
