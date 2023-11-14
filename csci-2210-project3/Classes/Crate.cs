using System.Text;
namespace csci_2210_project3.Classes
{
    /// <summary>
    /// A class that represents a crate
    /// </summary>
    public class Crate
    {
        /// <summary>
        /// The ID of the crate
        /// </summary>
        public string Id { get; private set; }
        /// <summary>
        /// The price of the crate
        /// </summary>
        public double Price { get; private set; }
        /// <summary>
        /// The constructor for the <see cref="Crate"/> class
        /// </summary>
        public Crate()
        {
            Id = GenerateId();
            Price = GeneratePrice();
        }
        /// <summary>
        /// Generates a random price for the crate
        /// </summary>
        /// <returns>a <see cref="double"/>; <see cref="Price"/> of the crate</returns>
        private double GeneratePrice()
        {
            Random rand = new Random();
            double dollarValue = rand.Next(50, 501);
            double centValue = rand.Next(0, 100) / 100.0;
            return dollarValue + centValue;
        }
        /// <summary>
        /// Generates a random ID for the crate
        /// </summary>
        /// <returns>the <see cref="Crate">s <see cref="Id"/></returns>
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
        public override string ToString() => "{id}, {price}";
    }
}