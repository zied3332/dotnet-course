using System;
using System.Collections.Generic;

namespace projetCourNet
{
    public class Passenger
    {
        public string PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string TelNumber { get; set; }
        public string EmailAddress { get; set; }

        public List<Flight> Flights { get; set; } = new List<Flight>();

        public bool CheckProfile(string firstName, string lastName)
        {
            return FirstName == firstName && LastName == lastName;
        }

        public bool CheckProfile(string firstName, string lastName, string emailAddress)
        {
            return FirstName == firstName &&
                   LastName == lastName &&
                   EmailAddress == emailAddress;
        }

        public bool CheckProfile(string firstName, string lastName, string emailAddress = null, bool useEmail = false)
        {
            if (useEmail)
                return FirstName == firstName &&
                       LastName == lastName &&
                       EmailAddress == emailAddress;

            return FirstName == firstName && LastName == lastName;
        }

        public virtual string PassengerType()
        {
            return "I am a passenger";
        }

        public override string ToString()
        {
            return "FirstName: " + FirstName +
                   ", LastName: " + LastName +
                   ", BirthDate: " + BirthDate +
                   ", PassportNumber: " + PassportNumber +
                   ", EmailAddress: " + EmailAddress +
                   ", TelNumber: " + TelNumber;
        }
    }
}