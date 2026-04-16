using System;
using System.Collections.Generic;

namespace projetCourNet
{
    public static class TestData
    {
        public static List<Flight> listFlights = new List<Flight>();

        public static void Initialize()
        {
            Plane boing = new Plane
            {
                PlaneId = 1,
                Capacity = 150,
                ManufactureDate = new DateTime(2015, 2, 3),
                PlaneType = PlaneType.Boing
            };

            Plane airbus = new Plane
            {
                PlaneId = 2,
                Capacity = 250,
                ManufactureDate = new DateTime(2020, 11, 11),
                PlaneType = PlaneType.Airbus
            };

            listFlights = new List<Flight>
            {
                new Flight
                {
                    FlightId = 1,
                    Destination = "Paris",
                    FlightDate = new DateTime(2022,1,1,15,10,10),
                    EffectiveArrival = new DateTime(2022,1,1,17,10,10),
                    EstimatedDuration = 110,
                    Plane = airbus
                },
                new Flight
                {
                    FlightId = 2,
                    Destination = "Paris",
                    FlightDate = new DateTime(2022,2,1,21,10,10),
                    EffectiveArrival = new DateTime(2022,2,1,23,10,10),
                    EstimatedDuration = 105,
                    Plane = boing
                },
                new Flight
                {
                    FlightId = 3,
                    Destination = "Madrid",
                    FlightDate = new DateTime(2022,4,1,6,10,10),
                    EffectiveArrival = new DateTime(2022,4,1,8,10,10),
                    EstimatedDuration = 130,
                    Plane = boing
                }
            };
        }
    }
}