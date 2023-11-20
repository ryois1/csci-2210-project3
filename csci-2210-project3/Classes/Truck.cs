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
using System.ComponentModel;
using csci_2210_project3.Classes.Drivers;
using csci_2210_project3.Classes.Utilities;

namespace csci_2210_project3.Classes
{
    /// <summary>
    /// Class to represent a truck
    /// </summary>
    public class Truck
    {
        /// <summary>
        /// The driver of the truck
        /// </summary>
        public string driver { get; private set; }
        /// <summary>
        /// The company the truck is delivering for
        /// </summary>
        public string deliveryCompany { get; private set; }
        /// <summary>
        /// The trucks trailer
        /// </summary>
        public Stack<Crate> Trailer { get; private set; }

        /// <summary>
        /// Adds crate to the trailer stack
        /// </summary>
        /// <param name="crate"></param>
        public void Load(Crate crate)
        {
            Trailer.Push(crate);
        }

        /// <summary>
        /// Remove front crate, returns next crate
        /// </summary>
        /// <returns></returns>
        public Crate Unload()
        {
            Crate nextCrate = Trailer.Pop();
            return nextCrate;
        }
        /// <summary>
        /// Constructor for the <see cref="Truck"/> class
        /// </summary>
        public Truck()
        {
            driver = FakeNames.GetDriverName();
            deliveryCompany = FakeNames.GetCompanyName();
            Trailer = new Stack<Crate>();
            Random rand = new Random();
            int numberOfCrates = rand.Next(1, 11);
            for (int i = 0; i < numberOfCrates; i++)
            {
                Trailer.Push(new Crate());
            }
        }
        /// <summary>
        /// override of the ToString method
        /// </summary>
        /// <returns>a <see cref="string">, the truck as a string</returns>
        public override string ToString() => $"{driver} from {deliveryCompany} has {Trailer.Count} crates";
    }
}