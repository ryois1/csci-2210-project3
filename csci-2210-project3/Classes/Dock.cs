///////////////////////////////////////////////////////////////////////////////
//
// Authors: Brendan Dalhover <dalhover@etsu.edu>
//          Jacob Hebert <hebertj@etsu.edu>
//          Russell Payne <payner3@etsu.edu>
//          Deep Desai <desaid@etsu.edu>
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 3 Warehouse Simulation
// Description: This program simulates a warehouse to determine the optimal
//             number of docks to have in the warehouse.
//
///////////////////////////////////////////////////////////////////////////////
using System.Text;

namespace csci_2210_project3.Classes
{
    /// <summary>
    /// A class that represents a dock for the warehouse
    /// </summary>
    public class Dock
    {
        /// <summary>
        /// The ID of the dock
        /// </summary>
        public string Id { get; private set; }
        /// <summary>
        /// The line of trucks waiting to be unloaded
        /// </summary>
        public Queue<Truck> Line { get; private set; }
        /// <summary>
        /// The total sales of the dock
        /// </summary>
        public double TotalSales { get; private set; }
        /// <summary>
        /// The total crates of the dock
        /// </summary>
        public int TotalCrates { get; private set; }
        /// <summary>
        /// The total trucks of the dock
        /// </summary>
        public int TotalTrucks { get; private set; }
        /// <summary>
        /// The time in use of the dock
        /// </summary>
        public int TimeInUse { get; set; }
        /// <summary>
        /// The amount of time a dock is idle
        /// </summary>
        public int TimeNotInUse { get; set; }
        /// <summary>
        /// The constructor for the <see cref="Dock"/> class
        /// </summary>
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
        /// <summary>
        /// Generates a random ID for the dock
        /// </summary>
        /// <returns>a <see cref="string"/>, the dock's id</returns>
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
        /// <param name="truck"><see cref="Truck"/> to add</param>
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
        /// <summary>
        /// Gets the first truck in the line
        /// </summary>
        /// <returns>the first <see cref="Truck"> in the line</returns>
        public Truck GetFirstTruck()
        {
            Truck firstTruck = Line.Peek();
            return firstTruck;
        }
        /// <summary>
        /// Override of the ToString method
        /// </summary>
        /// <returns>the <see cref="Dock"/> represented as a <see cref="string"/></returns>
        public override string ToString() => $"Dock {Id} has {Line.Count} trucks waiting, {TimeInUse} ticks in use, {TimeNotInUse} ticks not in use";
    }
}
