namespace projetCourNet
{
    public class Traveller : Passenger
    {
        public string HealthInformation { get; set; }
        public string Nationality { get; set; }

        public override string PassengerType()
        {
            return base.PassengerType() + " I am a traveller";
        }

        public override string ToString()
        {
            return base.ToString() +
                   ", HealthInformation: " + HealthInformation +
                   ", Nationality: " + Nationality;
        }
    }
}