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
namespace csci_2210_project3.Classes
{
    /// <summary>
    /// This class is used to represent a warehouse
    /// </summary>
    public class Warehouse
    {
        /// <summary>
        /// The list of docks in the warehouse
        /// </summary>
        public List<Dock> Docks { get; private set; }
        /// <summary>
        /// The queue of trucks waiting to enter the warehouse
        /// </summary>
        public Queue<Truck> Entrance { get; private set; }
        // Trucks have random number of cargo crates
        // Trucks arrive randomly across 48 ticks
        // Trucks can be added to the dock every tick
        // Trucks are unloaded one crate at a time for every tick
        // Each dock takes $100 per tick


        /// <summary>
        /// The constructor for the warehouse
        /// </summary>
        /// <param name="numberOfDocks">number of docs</param>
        public Warehouse(int numberOfDocks)
        {
            Docks = new List<Dock>();
            Entrance = new Queue<Truck>();
            for (int i = 0; i < numberOfDocks; i++)
            {
                Docks.Add(new Dock());
            }
        }
        /// <summary>
        /// Runs the simulation
        /// </summary>
        /// <param name="simulationNumber">simulation to run</param>
        public static double Run(int simulationNumber)
        {
            Console.WriteLine($"Simulation {simulationNumber}. Warehouse has {simulationNumber} docks");
            Warehouse warehouse = new Warehouse(simulationNumber);
            Console.WriteLine(warehouse);

            int totalCrates = 0;
            double totalSales = 0;
            double totalDockCost = 0;

            for (int tick = 0; tick < 48; tick++)
            {
                Random intRand = new Random();
                bool truckArrived = ProbTruck(tick);
                // Create random number of trucks
                if (truckArrived)
                {
                    warehouse.Entrance.Enqueue(new Truck());
                    System.Console.WriteLine($"Truck driver {warehouse.Entrance.Peek().driver} arrived at tick {tick}");
                }
                // Add trucks to docks
                foreach (Dock dock in warehouse.Docks)
                {
                    if (dock.Line.Count == 0 && warehouse.Entrance.Count > 0)
                    {
                        dock.JoinLine(warehouse.Entrance.Dequeue());
                        System.Console.WriteLine($"Truck driver {dock.GetFirstTruck().driver} joined dock {dock.Id} at tick {tick}");
                    }
                }
                // Unload trucks
                foreach (Dock dock in warehouse.Docks)
                {
                    if (dock.Line.Count > 0)
                    {
                        Truck truck = dock.GetFirstTruck();
                        if (truck.Trailer.Count > 0)
                        {
                            Crate crateUnloaded = truck.Unload();
                            totalCrates++;
                            totalSales += crateUnloaded.Price;
                            System.Console.WriteLine($"Truck driver {truck.driver} unloaded crate at dock {dock.Id} at tick {tick}");
                            string status = "UNKNOWN";
                            // Crate Unloaded but truck has more crates
                            // Crate Unloaded and truck has no more crates and another truck took its place
                            // Crate Unloaded and the truck has no more crates and no other truck took its place
                            if (truck.Trailer.Count > 0)
                            {
                                status = "UNLOADED";
                            }
                            else if (dock.Line.Count > 1)
                            {
                                status = "UNLOADED AND REPLACED";
                            }
                            else
                            {
                                status = "UNLOADED AND NO REPLACEMENT";
                            }
                            List<string> data = new List<string>(new string[] { tick.ToString(), truck.driver, truck.deliveryCompany, crateUnloaded.Id, crateUnloaded.Price.ToString("c"), status });

                            DataExport.ExportData(data, simulationNumber);
                        }
                    }
                }
                // Remove empty trucks from docks
                foreach (Dock dock in warehouse.Docks)
                {
                    if (dock.Line.Count > 0)
                    {
                        Truck truckSentOff = dock.SendOff();
                        if (truckSentOff != null)
                        {
                            System.Console.WriteLine($"Truck driver {truckSentOff.driver} left dock {dock.Id} at tick {tick}");
                        }
                    }
                }
                // Calculate dock stats
                foreach (Dock dock in warehouse.Docks)
                {
                    if (dock.Line.Count > 0)
                    {
                        dock.TimeInUse++;
                    }
                    else
                    {
                        dock.TimeNotInUse++;
                    }
                }



                System.Console.WriteLine($"Tick {tick} complete. {warehouse.Entrance.Count} trucks waiting to enter. {totalCrates} crates unloaded. {totalSales.ToString("c")} in sales.");
                // Thread.Sleep(1000);
            }
            // Calculate total dock cost
            foreach (Dock dock in warehouse.Docks)
            {
                totalDockCost += dock.TimeInUse * 100;
            }

            System.Console.WriteLine($"Simulation {simulationNumber} complete. {totalDockCost.ToString("c")} in dock costs. {totalSales.ToString("c")} in sales. {totalCrates} crates unloaded across {warehouse.Docks.Count} docks.");
            System.Console.WriteLine($"There were {warehouse.Entrance.Count} trucks waiting to enter.");
            double profit = totalSales - totalDockCost;
            System.Console.WriteLine($"The warehouse made {profit.ToString("c")} in profit.");
            DataExport.ExportData(new List<string>(new string[] { totalDockCost.ToString("c"), totalSales.ToString("c"), profit.ToString("c") }), simulationNumber);
            return (double)profit;

        }
        /// <summary>
        /// override of the ToString method
        /// </summary>
        /// <returns>a <see cref="string"/>the warehouse as a string</returns>
        public override string ToString() => $"Warehouse has {Docks.Count} docks, {Entrance.Count} trucks waiting to enter.";

        /// <summary>
        /// Determines if a truck will enter the queue, based on the tick
        /// </summary>
        /// <param name="tick">the current tick</param>
        /// <returns>true if a random number falls under a value</returns>
        /// <remarks> used chatgpt to help generate the curve function</remarks>
        static bool ProbTruck(int tick)
        {
            // Scale factor to adjust the range of the probability (25% to 50%)
            double scaleFactor = 0.25;

            // Calculate the probability using a modified -x^2 function and shift up by 1
            // Scale the result to be between 0.25 and 0.5
            double probability = (-Math.Pow(tick - 24, 2.0) / Math.Pow(24, 2.0) + 1) * scaleFactor + 0.25;

            // Ensure the probability is within the valid range [0.25, 0.5]
            probability = Math.Max(0.25, Math.Min(0.5, probability));

            Random random = new Random();
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"Probability of truck arriving at tick {tick} is {probability}");
            Console.ResetColor();
            return random.NextDouble() < probability;
        }
    }
}