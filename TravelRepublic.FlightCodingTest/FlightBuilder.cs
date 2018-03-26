using System;
using System.Collections.Generic;
using System.Linq;
using Models.FlightInformation;

namespace TravelRepublic.FlightCodingTest
{
    public sealed class FlightBuilder
    {
        private DateTime _threeDaysFromNow;
        private int noOfdays = 3;
        private FlightBuilder()
        {
            _threeDaysFromNow = DateTime.Now.AddDays(noOfdays);
        }
        private static readonly Lazy<FlightBuilder> Intance = new Lazy<FlightBuilder>(() => new FlightBuilder());

        public static FlightBuilder GetIntance => Intance.Value;

        public List<FlightInformation.Flight> GetFlights()
        {
            return new List<FlightInformation.Flight>
            {
                     //A normal flight with two hour duration
                     CreateFlight(_threeDaysFromNow, _threeDaysFromNow.AddHours(2)),

                     //A normal multi segment flight
                     CreateFlight(_threeDaysFromNow, _threeDaysFromNow.AddHours(2), _threeDaysFromNow.AddHours(3), _threeDaysFromNow.AddHours(5)),

                     //A flight departing in the past
                     CreateFlight(_threeDaysFromNow.AddDays(-6), _threeDaysFromNow),

                     //A flight that departs before it arrives
                     CreateFlight(_threeDaysFromNow, _threeDaysFromNow.AddHours(-6)),

                     //A flight with more than two hours ground time
                     CreateFlight(_threeDaysFromNow, _threeDaysFromNow.AddHours(2), _threeDaysFromNow.AddHours(5), _threeDaysFromNow.AddHours(6)),

                     //Another flight with more than two hours ground time
                     CreateFlight(_threeDaysFromNow, _threeDaysFromNow.AddHours(2), _threeDaysFromNow.AddHours(3), _threeDaysFromNow.AddHours(4),
                     _threeDaysFromNow.AddHours(6), _threeDaysFromNow.AddHours(7)),

                    
                      //1.Derpart before current date
                       CreateFlight(_threeDaysFromNow.AddDays(-3),_threeDaysFromNow.AddDays(-noOfdays)),

                      //2. Have a segment with an arrival date before the departure date.
                      CreateFlight(_threeDaysFromNow.AddHours(6),_threeDaysFromNow),

                      //3. Spend more than 2 hours on the ground. i.e those with a total gap of over two hours between the arrival date of one segment and 
                      //the departure date of the next.
                      CreateFlight(_threeDaysFromNow.AddDays(-noOfdays),_threeDaysFromNow.AddDays(-noOfdays).AddHours(2),_threeDaysFromNow.AddDays(-noOfdays).AddHours(5),_threeDaysFromNow.AddDays(-noOfdays).AddHours(6))

             };
        }

        private static FlightInformation.Flight CreateFlight(params DateTime[] dates)
        {
            if (dates.Length % 2 != 0) throw new ArgumentException($"You must pass an even number of dates,{dates}");

            var departureDates = dates.Where((date, index) => index % 2 == 0);
            var arrivalDates = dates.Where((date, index) => index % 2 == 1);

            var segments = departureDates.Zip(arrivalDates,
                                              (departureDate, arrivalDate) =>
                                              new FlightInformation.Segment { DepartureDate = departureDate, ArrivalDate = arrivalDate }).ToList();

            return new FlightInformation.Flight { Segments = segments };
        }
    }

   
}

