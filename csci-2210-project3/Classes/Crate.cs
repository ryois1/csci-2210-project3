using System.Text;
namespace Classes
{
    /// <summary>
    /// A class that represents a crate for the truck class
    /// </summary>
    public class Crate
    {
        /// <summary>
        /// The unique identifier of the crate
        /// </summary>
        public Guid Id { get; private set; }
        /// <summary>
        /// The price of the crate
        /// </summary>
        public double Price { get; private set; }
        /// <summary>
        /// Crate constructor
        /// </summary>
        public Crate()
        {
            Id = Guid.NewGuid();
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
    }
}