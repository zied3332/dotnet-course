using System;
using System.Collections.Generic;

namespace projetCourNet
{
    public enum PlaneType
    {
        Boing,
        Airbus
    }

    public class Plane
    {
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int Capacity { get; set; }

        public List<Flight> Flights { get; set; } = new List<Flight>();

        public Plane()
        {
        }

        public Plane(PlaneType pt, int capacity, DateTime date)
        {
            PlaneType = pt;
            Capacity = capacity;
            ManufactureDate = date;
        }

        public override string ToString()
        {
            return "PlaneId: " + PlaneId +
                   ", Capacity: " + Capacity +
                   ", ManufactureDate: " + ManufactureDate +
                   ", PlaneType: " + PlaneType;
        }
    }
}