using System.ComponentModel;
using csci_2210_project3.Classes.Drivers;
using csci_2210_project3.Classes.Utilities;

namespace csci_2210_project3.Classes
{
    public class Truck
    {
        public string driver { get; private set; }
        public string deliveryCompany { get; private set; }
        public Stack<Crate> Trailer { get; private set; }

        /// <summary>
        /// Adds crate to the trailer stack
        /// </summary>
        /// <param name="crate"></param>
        public void Load(Crate crate){
            Trailer.Push(crate);
        }

        /// <summary>
        /// Remove front crate, returns next crate
        /// </summary>
        /// <returns></returns>
        public Crate Unload(){
            Crate nextCrate = Trailer.Pop();
            return nextCrate;
        }

        public Truck(){
            driver = FakeNames.GetDriverName();
            deliveryCompany = FakeNames.GetCompanyName();
            Trailer = new Stack<Crate>();
            Random rand = new Random();
            int numberOfCrates = rand.Next(1, 11);
            for(int i = 0; i < numberOfCrates; i++){
                Trailer.Push(new Crate());
            }
        }

        public override string ToString() => $"{driver} from {deliveryCompany} has {Trailer.Count} crates";
    }
}