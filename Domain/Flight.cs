using System;
using System.Collections.Generic;

namespace projetCourNet
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public double EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }

        public List<Passenger> Passengers { get; set; } = new List<Passenger>();
        public Plane Plane { get; set; }

        public override string ToString()
        {
            return "FlightId: " + FlightId +
                   ", Destination: " + Destination +
                   ", Departure: " + Departure +
                   ", FlightDate: " + FlightDate +
                   ", EffectiveArrival: " + EffectiveArrival +
                   ", EstimatedDuration: " + EstimatedDuration;
        }
    }
}