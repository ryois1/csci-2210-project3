using System.Collections;
using System.Diagnostics.Contracts;

namespace Classes.Drivers
{
    public class AvailableDrivers : IEnumerable<Driver>
    {
        public List<Driver> Drivers { get; private set; }

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
                if (!String.IsNullOrEmpty(line))
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