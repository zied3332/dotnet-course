using System;
using System.Collections.Generic;
using System.Linq;
using projetCourNet.Interfaces;

namespace projetCourNet.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        // 1) Get flight dates by destination
        public List<DateTime> GetFlightDates(string destination)
        {
            // Old method syntax:
            // return Flights
            //     .Where(f => f.Destination == destination)
            //     .Select(f => f.FlightDate)
            //     .ToList();

            var query =
                from f in Flights
                where f.Destination == destination
                select f.FlightDate;

            return query.ToList();
        }

        // 2) Get flight dates by destination using foreach
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

        // 3) Dynamic filter by property name and value
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

        // 4) Show flight details of a given plane
        public void ShowFlightDetails(Plane plane)
        {
            // Old method syntax:
            // var result = Flights
            //     .Where(f => f.Plane == plane)
            //     .Select(f => new
            //     {
            //         f.Destination,
            //         f.FlightDate
            //     });

            var result =
                from f in Flights
                where f.Plane == plane
                select new
                {
                    f.Destination,
                    f.FlightDate
                };

            foreach (var item in result)
            {
                Console.WriteLine($"Destination: {item.Destination} | Date: {item.FlightDate}");
            }
        }

        // 5) Number of flights programmed in 7 days from a start date
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            // Old method syntax:
            // return Flights.Count(f =>
            //     f.FlightDate >= startDate &&
            //     f.FlightDate <= startDate.AddDays(7));

            var query =
                from f in Flights
                where f.FlightDate >= startDate
                      && f.FlightDate <= startDate.AddDays(7)
                select f;

            return query.Count();
        }

        // 6) Average duration for a destination
        public double DurationAverage(string destination)
        {
            // Old method syntax:
            // return Flights
            //     .Where(f => f.Destination == destination)
            //     .Average(f => f.EstimatedDuration);

            var query =
                from f in Flights
                where f.Destination == destination
                select f.EstimatedDuration;

            return query.Average();
        }

        // 7) Order flights by duration descending
        public List<Flight> OrderedDurationFlights()
        {
            // Old method syntax:
            // return Flights
            //     .OrderByDescending(f => f.EstimatedDuration)
            //     .ToList();

            var query =
                from f in Flights
                orderby f.EstimatedDuration descending
                select f;

            return query.ToList();
        }

        // 8) Longest flight
        public Flight LongestFlight()
        {
            // Old method syntax:
            // return Flights
            //     .OrderByDescending(f => f.EstimatedDuration)
            //     .FirstOrDefault();

            var query =
                from f in Flights
                orderby f.EstimatedDuration descending
                select f;

            return query.FirstOrDefault();
        }

        // 9) 3 oldest travellers of a flight
        public List<Traveller> SeniorTravellers(Flight flight)
        {
            // Old method syntax:
            // return flight.Passengers
            //     .OfType<Traveller>()
            //     .OrderByDescending(t => t.BirthDate)
            //     .Take(3)
            //     .ToList();

            var query =
                from t in flight.Passengers.OfType<Traveller>()
                orderby t.BirthDate ascending
                select t;

            return query.Take(3).ToList();
        }

        // 10) Group flights by destination
        public void DestinationGroupedFlights()
        {
            // Old method syntax:
            // var grouped = Flights
            //     .GroupBy(f => f.Destination);

            var grouped =
                from f in Flights
                group f by f.Destination into g
                select g;

            foreach (var group in grouped)
            {
                Console.WriteLine($"Destination {group.Key}");
                foreach (var flight in group)
                {
                    Console.WriteLine($"Décollage: {flight.FlightDate}");
                }
            }
        }

        // 11) Count flights by destination
        public void FlightCountByDestination()
        {
            // Old method syntax:
            // var result = Flights
            //     .GroupBy(f => f.Destination)
            //     .Select(g => new
            //     {
            //         Destination = g.Key,
            //         Count = g.Count()
            //     });

            var result =
                from f in Flights
                group f by f.Destination into g
                select new
                {
                    Destination = g.Key,
                    Count = g.Count()
                };

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Destination}: {item.Count}");
            }
        }

        // 12) Most occupied flight
        public Flight MostOccupiedFlight()
        {
            // Old method syntax:
            // return Flights
            //     .OrderByDescending(f => f.Passengers.Count)
            //     .FirstOrDefault();

            var query =
                from f in Flights
                orderby f.Passengers.Count descending
                select f;

            return query.FirstOrDefault();
        }

        // 13) Distinct destinations
        public List<string> GetDestinations()
        {
            // Old method syntax:
            // return Flights
            //     .Select(f => f.Destination)
            //     .Distinct()
            //     .ToList();

            var query =
                (from f in Flights
                 select f.Destination).Distinct();

            return query.ToList();
        }

        // 14) Check if Paris flight exists
        public bool ExistsParisFlight()
        {
            // Old method syntax:
            // return Flights
            //     .Any(f => f.Destination == "Paris");

            var query =
                from f in Flights
                where f.Destination == "Paris"
                select f;

            return query.Any();
        }
    }
}