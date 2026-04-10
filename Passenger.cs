using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetCourNet
{
    public class Passenger
    {
        public string PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int TelNumber { get; set; }
        public string EmailAddress { get; set; }
        public virtual List<Flight> Flights { get; set; }

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
