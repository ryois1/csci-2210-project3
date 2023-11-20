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
using csci_2210_project3.Classes;

namespace csci_2210_project3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Warehouse.Run(int.Parse(args[0]));
                return;
            }
            double highestProfitDock = default;
            double highestProfit = 0;
            double runnerUpDock = default;
            double runnerUpProfit = 0;
            int numberOfSimulations = 10;
            double totalProfit = 0;
            for (int pass = 0; pass < 10; pass++)
            {
                for (int i = 0; i < numberOfSimulations; i++)
                {
                    double profit = Warehouse.Run(i + 1);
                    totalProfit += profit;

                    if (profit > highestProfit)
                    {
                        highestProfit = profit;
                        highestProfitDock = i + 1;
                    }
                    else if (profit > runnerUpProfit)
                    {
                        runnerUpProfit = profit;
                        runnerUpDock = i + 1;
                    }
                }
            }

            double averageProfit = totalProfit / (10 * numberOfSimulations);

            Console.WriteLine($"Dock {highestProfitDock} had the highest profit with {highestProfit}");
            Console.WriteLine($"Dock {runnerUpDock} had the second highest profit with {runnerUpProfit}");
            Console.WriteLine($"Average profit per simulation: {averageProfit}");
        }


    }

}

