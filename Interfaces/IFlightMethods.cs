using System;
using System.Collections.Generic;

namespace projetCourNet.Interfaces
{
    public interface IFlightMethods
    {
        List<DateTime> GetFlightDates(string destination);
        List<DateTime> GetFlightDatesWithForeach(string destination);
        void GetFlights(string filterType, string filterValue);
    }
}