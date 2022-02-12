namespace Domain.Entities
{
    public class Car
    {
        public int id { get; set; }
        public string TeamName { get; set; }
        public int Speed { get; set; }
        public double MalfunctionChance { get; set; }
        public int DistanceCoveredInMiles { get; set; }
        public int FinishedRace { get; set; }
        public int RacedForHours { get; set; }

    }
}
