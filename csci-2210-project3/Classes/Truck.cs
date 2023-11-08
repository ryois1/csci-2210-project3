using System.ComponentModel;
using csci_2210_project3.Classes.DalhoverMethods;
using csci_2210_project3.Classes.Drivers;

namespace csci_2210_project3.Classes
{
    public class Truck
    {
        /// <summary>
        /// The driver of the truck
        /// </summary>
        public Driver TruckDriver { get; private set; }
        /// <summary>
        /// The company that owns the truck
        /// </summary>
        public string DeliveryCompany { get; private set; }
        /// <summary>
        /// The trailer of the truck
        /// </summary>
        public Stack<Crate> Trailer { get; private set; }
        /// <summary>
        /// The random number generator, used to get the driver and company info without having duplicates.
        /// </summary>
        /// <remarks>
        /// Needed to be saved so that the same random number generator would be used for each truck
        /// </remarks>
        private DistinctRandom Random { get; set; } = new(0, 50);

        /// <summary>
        /// Creates a new <see cref="Truck"/> with the given <see cref="Driver"/> and <see cref="deliveryCompany"/>
        /// </summary>
        /// <param name="driver">The driver of the truck</param>
        /// <param name="deliveryCompany">The company the driver works for</param>
        public Truck(Driver driver, string deliveryCompany)
        {
            TruckDriver = driver;
            DeliveryCompany = deliveryCompany;
            Trailer = new Stack<Crate>();
        }
        public Truck(Dictionary<string, Driver> truckInfo)
        {

            int index = Random.Next();
            TruckDriver = truckInfo.Values.ElementAt(index);
            DeliveryCompany = truckInfo.Keys.ElementAt(index);
            Trailer = new Stack<Crate>();
        }
        /// <summary>
        /// Gets the truck info from the file
        /// </summary>
        /// <returns>a <see cref="Dictionary"/> containing the Company name as a key and the driver name/nickname as the value</returns>
        internal async Task<Dictionary<string, Driver>> GetTruckInfo()
        {
            Dictionary<string, Driver> truckInfo = new();
            string[] companies = await GetCompanyInfo();
            AvailableDrivers availableDrivers = await AvailableDrivers.GetDriverInfo();
            DistinctRandom random = new(0, companies.Length);
            foreach (string company in companies)
            {
                int driverIndex = random.Next();
                truckInfo.Add(company, availableDrivers.Drivers[driverIndex]);
                availableDrivers.Drivers.RemoveAt(driverIndex);
            }
            return truckInfo;
        }
        /// <summary>
        /// Gets the company info from the file
        /// </summary>
        /// <returns>an array of <see cref="string"/>s, the companies</returns>
        internal async Task<string[]> GetCompanyInfo()
        {
            string path = Directory.GetCurrentDirectory();
            path += "\\FakeNames\\CompanyNames.txt";
            Console.WriteLine(path);
            StreamReader sr = new StreamReader(path);
            string[] companies = (await sr.ReadToEndAsync()).Split('\n');
            return companies;
        }

        public void Load(Crate crate) => Trailer.Push(crate);
        public Crate Unload() => Trailer.Pop();
    }
}