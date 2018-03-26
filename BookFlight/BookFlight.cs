using System;
using TravelRepublic.FlightCodingTest;

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
            FlightBuilder filghtInfo = FlightBuilder.GetIntance;
            var flightDetails = filghtInfo.GetFlights();
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
