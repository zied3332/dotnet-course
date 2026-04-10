using projetCourNet;
using System;
using System.Collections.Generic;

namespace YourNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // ===== Staff =====
            Staff staff = new Staff
            {
                FirstName = "Zied",
                LastName = "Alimi",
                PassportNumber = "AA123456",
                EmailAddress = "zied@test.com",
                TelNumber = 12345678,
                EmploymentDate = DateTime.Now,
                Function = "Pilot",
                Salary = 5000
            };

            // ===== Traveller =====
            Traveller traveller = new Traveller
            {
                FirstName = "Ali",
                LastName = "Ben Salah",
                PassportNumber = "BB987654",
                EmailAddress = "ali@test.com",
                TelNumber = 87654321, 
                Nationality = "Tunisian",
                HealthInformation = "Good"
            };

            // ===== Display =====
            Console.WriteLine("=== Staff ===");
            Console.WriteLine(staff);

            Console.WriteLine("\n=== Traveller ===");
            Console.WriteLine(traveller);

            // ===== Polymorphism test =====
            List<Passenger> people = new List<Passenger>();
            people.Add(staff);
            people.Add(traveller);

            Console.WriteLine("\n=== All Passengers ===");
            foreach (Passenger p in people)
            {
                Console.WriteLine(p);
            }

            Console.ReadLine(); // keep console open
        }
    }
}