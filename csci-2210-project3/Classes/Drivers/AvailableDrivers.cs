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
using System.Collections;
using System.Diagnostics.Contracts;

namespace csci_2210_project3.Classes.Drivers
{
    /// <summary>
    /// A class that represents the available drivers
    /// </summary>
    public class AvailableDrivers : IEnumerable<Driver>
    {
        /// <summary>
        /// The list of available drivers
        /// </summary>
        public List<Driver> Drivers { get; private set; }
        /// <summary>
        /// The constructor for the <see cref="AvailableDrivers"/> class
        /// </summary>
        public AvailableDrivers()
        {
            Drivers = new List<Driver>();
        }
        /// <summary>
        /// Adds a driver to the list of available drivers
        /// </summary>
        /// <param name="driver">The <see cref="Driver"/> to add</param>
        /// <exception cref="ArgumentNullException">Thrown if the driver passed into the method is null</exception>
        public void AddDriver(Driver driver)
        {
            if (driver != null)
                Drivers.Add(driver);
            else
                throw new ArgumentNullException("Driver cannot be null");
        }
        /// <summary>
        /// Gets the driver info from the file asynchronously
        /// </summary>
        /// <returns>The Available Drivers</returns>
        internal static async Task<AvailableDrivers> GetDriverInfo()
        {
            string path = Directory.GetCurrentDirectory() + "\\FakeNames\\DriverNames.txt";
            StreamReader sr = new StreamReader(path);
            AvailableDrivers drivers = new();
            for (int i = 0; i < 50; i++)
            {
                string? line = await sr.ReadLineAsync();
                if (!string.IsNullOrEmpty(line))
                {
                    drivers.AddDriver(new Driver(line.Split(',')));
                }
            }
            return drivers;
        }


        public IEnumerator<Driver> GetEnumerator()
        {
            return Drivers.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Drivers.GetEnumerator();
        }
    }
}