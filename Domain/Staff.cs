using System;

namespace projetCourNet
{
    public class Staff : Passenger
    {
        public DateTime EmploymentDate { get; set; }
        public string Function { get; set; }
        public double Salary { get; set; }

        public override string PassengerType()
        {
            return base.PassengerType() + " I am a Staff Member";
        }

        public override string ToString()
        {
            return base.ToString() +
                   ", EmploymentDate: " + EmploymentDate +
                   ", Function: " + Function +
                   ", Salary: " + Salary;
        }
    }
}