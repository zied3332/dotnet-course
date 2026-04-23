using System;
using System.Collections.Generic;

namespace projetCourNet.Interfaces
{
    public interface IFlightMethods
    {
        List<DateTime> GetFlightDates(string destination);
        List<DateTime> GetFlightDatesWithForeach(string destination);
        void GetFlights(string filterType, string filterValue);
        void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        double DurationAverage(string destination);
        List<Flight> OrderedDurationFlights();

        Flight LongestFlight();
        List<Traveller> SeniorTravellers(Flight flight);
        void DestinationGroupedFlights();
        void FlightCountByDestination();
        Flight MostOccupiedFlight();
        List<string> GetDestinations();
        bool ExistsParisFlight();
    }
}