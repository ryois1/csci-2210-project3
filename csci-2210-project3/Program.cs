using csci_2210_project3.Classes;

namespace csci_2210_project3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0) {
                Warehouse.Run(int.Parse(args[0]));
                return;
            }
            Console.WriteLine("How many simulations would you like to run?");
            int numberOfSimulations = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < numberOfSimulations; i++){
                Warehouse.Run(i+1);
            }
        }
       
    }
}
