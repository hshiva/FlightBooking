using System;
using BookFlight.AppService;
using BookFlight.Core.AppService;
using FlightService.Core.InfraStructure;
using Unity;

namespace BookFlight
{
    static class BookFlight
    {
        static void Main()
        {
            GetFlightDetails();
            //TODO
            //Book Flight
        }


        private static void GetFlightDetails()
        {
            // we can move the dependency injection code into startup file or some common place 
            IUnityContainer unity = new UnityContainer();
            unity.RegisterType<IFlightAppService, FlightAppService>();
            unity.RegisterType<IFlightService, FlightService.InfraStructure.FlightService>();
            var appService = unity.Resolve<FlightAppService>();

            var flightDetails = appService.GetFlightDetails();

            foreach (var flight in flightDetails)
            {
                foreach (var segments in flight.Segments)
                {
                    Console.WriteLine(
                        $"flight Details : Departure Date and Time = {segments.DepartureDate}, Arrival Date and Time ={segments.ArrivalDate} ");
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            }
            Console.ReadKey();
        }
    }
}
