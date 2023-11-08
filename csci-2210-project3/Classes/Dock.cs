using System.Text;

namespace csci_2210_project3.Classes
{
    public class Dock
    {
        public string Id { get; private set; }
        public Queue<Truck> Line { get; private set; }
        public double TotalSales { get; private set; }
        public int TotalCrates { get; private set; }
        public int TotalTrucks { get; private set; }
        public int TimeInUse { get; set; }
        public int TimeNotInUse { get; set; }

        public Dock()
        {
            Id = GenerateId();
            Line = new Queue<Truck>();
            TotalSales = 0;
            TotalCrates = 0;
            TotalTrucks = 0;
            TimeInUse = 0;
            TimeNotInUse = 0;
        }

        private string GenerateId()
        {
            Random rand = new Random();
            StringBuilder id = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                id.Append(rand.Next(0, 10));
            }
            return id.ToString();
        }

        /// <summary>
        /// Adds a truck to the line
        /// </summary>
        /// <param name="truck"></param>
        public void JoinLine(Truck truck)
        {
            //Adds Truck to the Dock's line
            Line.Enqueue(truck);
        }

        /// <summary>
        /// Removes the truck and returns first truck
        /// </summary>
        /// <returns>The instance of the first truck</returns>
        public Truck SendOff()
        {
            // If the first truck is empty, remove it from the line
            if (Line.Peek().Trailer.Count != 0) return null;
            Truck firstTruck = Line.Dequeue();
            return firstTruck;
        }

        public Truck GetFirstTruck()
        {
            Truck firstTruck = Line.Peek();
            return firstTruck;
        }

        public override string ToString() => $"Dock {Id} has {Line.Count} trucks waiting, {TimeInUse} ticks in use, {TimeNotInUse} ticks not in use";
    }
}
