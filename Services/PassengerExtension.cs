using System;

namespace projetCourNet.Services
{
    // Extension class MUST be static
    public static class PassengerExtension
    {
        // Extension method MUST be static
        // "this Passenger passenger" => extends Passenger class
        public static string UpperFullName(this Passenger passenger)
        {
            // Safety check
          
            if (passenger == null)
                return string.Empty;

            // Capitalize first letter of FirstName
            string firstName = char.ToUpper(passenger.FirstName[0]) +
                               passenger.FirstName.Substring(1).ToLower();

            // Capitalize first letter of LastName
            string lastName = char.ToUpper(passenger.LastName[0]) +
                              passenger.LastName.Substring(1).ToLower();

            // Return full name
            return $"{firstName} {lastName}";
        }
    }
}