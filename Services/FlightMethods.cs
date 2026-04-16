using System;
using System.Collections.Generic;
using projetCourNet.Interfaces;

namespace projetCourNet.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        // ?? FOR LOOP
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();

            for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].Destination == destination)
                {
                    dates.Add(Flights[i].FlightDate);
                }
            }

            return dates;
        }

        // ?? FOREACH LOOP
        public List<DateTime> GetFlightDatesWithForeach(string destination)
        {
            List<DateTime> dates = new List<DateTime>();

            foreach (Flight flight in Flights)
            {
                if (flight.Destination == destination)
                {
                    dates.Add(flight.FlightDate);
                }
            }

            return dates;
        }

        // ?? DYNAMIC FILTER
        public void GetFlights(string filterType, string filterValue)
        {
            foreach (Flight flight in Flights)
            {
                var property = typeof(Flight).GetProperty(filterType);

                if (property != null)
                {
                    var value = property.GetValue(flight);

                    if (value != null && value.ToString() == filterValue)
                    {
                        Console.WriteLine(flight);
                    }
                }
            }
        }
    }
}