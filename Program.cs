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

            // 1) Plane created with default constructor + property assignment
            Plane p1 = new Plane();
            p1.PlaneId = 1;
            p1.Capacity = 150;
            p1.ManufactureDate = new DateTime(2020, 2, 1);
            p1.PlaneType = PlaneType.Boing;

            // 2) Plane created with parameterized constructor
            Plane p2 = new Plane(PlaneType.Airbus, 250, new DateTime(2022, 5, 10));
            p2.PlaneId = 2;

            // 3) Plane created with object initializer
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

            // Test GetFlightDates with FOR
            List<DateTime> datesFor = service.GetFlightDates("Paris");
            Console.WriteLine("\nFlights to Paris (FOR):");
            foreach (DateTime date in datesFor)
            {
                Console.WriteLine(date);
            }

            // Test GetFlightDates with FOREACH
            List<DateTime> datesForeach = service.GetFlightDatesWithForeach("Paris");
            Console.WriteLine("\nFlights to Paris (FOREACH):");
            foreach (DateTime date in datesForeach)
            {
                Console.WriteLine(date);
            }

            // Test GetFlights with dynamic filter
            Console.WriteLine("\nFlights filtered by Destination = Paris:");
            service.GetFlights("Destination", "Paris");

            Console.ReadLine();
        }
    }
}