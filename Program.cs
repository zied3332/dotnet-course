using System;
using System.Collections.Generic;
using projetCourNet.Services;

namespace projetCourNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // =========================
            // TP1 - PLANES
            // =========================

            Plane p1 = new Plane();
            p1.PlaneId = 1;
            p1.Capacity = 150;
            p1.ManufactureDate = new DateTime(2020, 2, 1);
            p1.PlaneType = PlaneType.Boing;

            Plane p2 = new Plane(PlaneType.Airbus, 250, new DateTime(2022, 5, 10));
            p2.PlaneId = 2;

            Plane p3 = new Plane
            {
                PlaneId = 3,
                Capacity = 300,
                ManufactureDate = new DateTime(2023, 1, 1),
                PlaneType = PlaneType.Airbus
            };

            Console.WriteLine("=== PLANES ===");
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);

            // =========================
            // TP1 - PASSENGERS
            // =========================

            Staff staff = new Staff
            {
                FirstName = "Zied",
                LastName = "Alimi",
                PassportNumber = "AA123456",
                EmailAddress = "zied@test.com",
                TelNumber = "12345678",
                BirthDate = new DateTime(2002, 1, 1),
                EmploymentDate = DateTime.Now,
                Function = "Pilot",
                Salary = 5000
            };

            Traveller traveller = new Traveller
            {
                FirstName = "Ali",
                LastName = "Ben Salah",
                PassportNumber = "BB987654",
                EmailAddress = "ali@test.com",
                TelNumber = "87654321",
                BirthDate = new DateTime(2000, 5, 15),
                Nationality = "Tunisian",
                HealthInformation = "Good"
            };

            Passenger passenger = new Passenger
            {
                FirstName = "Sara",
                LastName = "Mansour",
                PassportNumber = "CC111222",
                EmailAddress = "sara@test.com",
                TelNumber = "99887766",
                BirthDate = new DateTime(1999, 10, 10)
            };

            Console.WriteLine("\n=== PASSENGERS ===");
            Console.WriteLine(passenger);
            Console.WriteLine(staff);
            Console.WriteLine(traveller);

            // CheckProfile tests
            Console.WriteLine("\n=== CHECK PROFILE ===");
            Console.WriteLine(passenger.CheckProfile("Sara", "Mansour"));
            Console.WriteLine(passenger.CheckProfile("Sara", "Mansour", "sara@test.com"));
            Console.WriteLine(passenger.CheckProfile("Sara", "Mansour", "sara@test.com", true));

            // Polymorphism test
            List<Passenger> people = new List<Passenger>
            {
                passenger,
                staff,
                traveller
            };

            Console.WriteLine("\n=== PASSENGER TYPES ===");
            foreach (Passenger p in people)
            {
                Console.WriteLine(p.PassengerType());
            }

            Console.WriteLine("\n=== ALL PASSENGERS ===");
            foreach (Passenger p in people)
            {
                Console.WriteLine(p);
            }

            // =========================
            // TP2 - TEST DATA + SERVICES
            // =========================

            Console.WriteLine("\n=== TP2 TEST ===");

            // Initialize static test data
            TestData.Initialize();

            // Create service instance
            FlightMethods service = new FlightMethods();
            service.Flights = TestData.listFlights;

            // =========================
            // EXISTING TESTS
            // =========================

            List<DateTime> datesFor = service.GetFlightDates("Paris");
            Console.WriteLine("\nFlights to Paris (LINQ):");
            foreach (DateTime date in datesFor)
            {
                Console.WriteLine(date);
            }

            Console.WriteLine("\nFlights filtered by Destination = Paris:");
            service.GetFlights("Destination", "Paris");

            // =========================
            // 2 TEST ShowFlightDetails
            // =========================
            Console.WriteLine("\n=== 2 - TEST ShowFlightDetails ===");
            service.ShowFlightDetails(TestData.listFlights[0].Plane);

            // =========================
            // 3 TEST ProgrammedFlightNumber
            // =========================
            Console.WriteLine("\n=== 3 - TEST ProgrammedFlightNumber ===");
            DateTime startDate = new DateTime(2022, 5, 1);
            int programmedCount = service.ProgrammedFlightNumber(startDate);
            Console.WriteLine($"Flights between {startDate.ToShortDateString()} and {startDate.AddDays(7).ToShortDateString()} = {programmedCount}");

            // =========================
            // 4 TEST DurationAverage
            // =========================
            Console.WriteLine("\n=== 4 - TEST DurationAverage ===");
            double averageDuration = service.DurationAverage("Paris");
            Console.WriteLine($"Average duration for Paris flights = {averageDuration}");

            // =========================
            // 5 TEST OrderedDurationFlights
            // =========================
            Console.WriteLine("\n=== 5 - TEST OrderedDurationFlights ===");
            List<Flight> orderedFlights = service.OrderedDurationFlights();
            foreach (Flight flight in orderedFlights)
            {
                Console.WriteLine($"FlightId: {flight.FlightId}, Destination: {flight.Destination}, Duration: {flight.EstimatedDuration}");
            }

            // =========================
            //  6 TEST LongestFlight
            // =========================
            Console.WriteLine("\n=== 6 - TEST LongestFlight ===");
            Flight longestFlight = service.LongestFlight();
            if (longestFlight != null)
            {
                Console.WriteLine($"Longest flight -> FlightId: {longestFlight.FlightId}, Destination: {longestFlight.Destination}, Duration: {longestFlight.EstimatedDuration}");
            }

            // =========================
            // 7 TEST SeniorTravellers
            // =========================
            Console.WriteLine("\n=== 7 - TEST SeniorTravellers ===");
            List<Traveller> seniorTravellers = service.SeniorTravellers(TestData.listFlights[0]);
            foreach (Traveller t in seniorTravellers)
            {
                Console.WriteLine($"{t.FirstName} {t.LastName} - BirthDate: {t.BirthDate.ToShortDateString()}");
            }

            // =========================
            // 8 TEST DestinationGroupedFlights
            // =========================
            Console.WriteLine("\n=== 8 - TEST DestinationGroupedFlights ===");
            service.DestinationGroupedFlights();

            // =========================
            // 9 TEST FlightCountByDestination
            // =========================
            Console.WriteLine("\n===  9 - TEST FlightCountByDestination ===");
            service.FlightCountByDestination();

            // =========================
            // 10 TEST MostOccupiedFlight
            // =========================
            Console.WriteLine("\n===  10 - TEST MostOccupiedFlight ===");
            Flight mostOccupied = service.MostOccupiedFlight();
            if (mostOccupied != null)
            {
                Console.WriteLine($"Most occupied flight -> FlightId: {mostOccupied.FlightId}, Destination: {mostOccupied.Destination}, Passengers: {mostOccupied.Passengers.Count}");
            }

            // =========================
            // 11 TEST GetDestinations
            // =========================
            Console.WriteLine("\n=== 11 - TEST GetDestinations ===");
            List<string> destinations = service.GetDestinations();
            foreach (string destination in destinations)
            {
                Console.WriteLine(destination);
            }

            // =========================
            // 12 TEST ExistsParisFlight
            // =========================
            Console.WriteLine("\n===  12 - TEST ExistsParisFlight ===");
            bool existsParis = service.ExistsParisFlight();
            Console.WriteLine($"Is there a flight to Paris? {existsParis}");

           

            Console.WriteLine("\n=== TEST EXTENSION METHOD ===");
            Console.WriteLine(passenger.UpperFullName());
            Console.WriteLine(traveller.UpperFullName());
            Console.WriteLine(staff.UpperFullName());
            
            Console.ReadLine();
        }
    }
}