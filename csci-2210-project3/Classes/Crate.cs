using System.Text;
namespace csci_2210_project3.Classes
{
    /// <summary>
    /// A class that represents a crate for the truck class
    /// </summary>
    public class Crate
    {
        public string Id { get; private set; }
        public double Price { get; private set; }
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

        private string GenerateId(){
            Random rand = new Random();
            StringBuilder id = new StringBuilder();
            for(int i = 0; i < 8; i++){
                id.Append(rand.Next(0, 10));
            }
            return id.ToString();
        }
        public override string ToString() => "{id}, {price}";
    }
}