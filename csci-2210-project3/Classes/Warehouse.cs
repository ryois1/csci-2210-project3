namespace csci_2210_project3.Classes
{
    public class Warehouse{
        public List<Dock> Docks { get; private set; }
        public Queue<Truck> Entrance { get; private set; }
            // Trucks have random number of cargo crates
            // Trucks arrive randomly across 48 ticks
            // Trucks can be added to the dock every tick
            // Trucks are unloaded one crate at a time for every tick
            // Each dock takes $100 per tick
        
        public Warehouse(int numberOfDocks){
            Docks = new List<Dock>();
            Entrance = new Queue<Truck>();
            for(int i = 0; i < numberOfDocks; i++){
                Docks.Add(new Dock());
            }
        }
        public static void Run(int simulationNumber){
            Console.WriteLine($"Simulation {simulationNumber}. Warehouse has {simulationNumber} docks");
            Warehouse warehouse = new Warehouse(simulationNumber);
            Console.WriteLine(warehouse);

            int totalCrates = 0;
            double totalSales = 0;
            double totalDockCost = 0;

            for(int tick = 0; tick < 48; tick++){
                // Create random number of trucks
                Random rand = new Random();
                // Probability of a truck arriving is 25%
                if(rand.Next(0, 4) == 0){
                    warehouse.Entrance.Enqueue(new Truck());
                    System.Console.WriteLine($"Truck driver {warehouse.Entrance.Peek().driver} arrived at tick {tick}");
                }
                // Add trucks to docks
                foreach(Dock dock in warehouse.Docks){
                    if(dock.Line.Count == 0 && warehouse.Entrance.Count > 0){
                        dock.JoinLine(warehouse.Entrance.Dequeue());
                        System.Console.WriteLine($"Truck driver {dock.GetFirstTruck().driver} joined dock {dock.Id} at tick {tick}");
                    }
                }
                // Unload trucks
                foreach(Dock dock in warehouse.Docks){
                    if(dock.Line.Count > 0){
                        Truck truck = dock.GetFirstTruck();
                        if(truck.Trailer.Count > 0){
                            Crate crateUnloaded = truck.Unload();
                            totalCrates++;
                            totalSales += crateUnloaded.Price;
                            System.Console.WriteLine($"Truck driver {truck.driver} unloaded crate at dock {dock.Id} at tick {tick}");
                            string status = "UNKNOWN";
                            // Crate Unloaded but truck has more crates
                            // Crate Unloaded and truck has no more crates and another truck took its place
                            // Crate Unloaded and the truck has no more crates and no other truck took its place
                            if(truck.Trailer.Count > 0){
                                status = "UNLOADED";
                            } else if(dock.Line.Count > 1){
                                status = "UNLOADED AND REPLACED";
                            } else {
                                status = "UNLOADED AND NO REPLACEMENT";
                            }
                            List<string> data = new List<string>(new string[] { tick.ToString(), truck.driver, truck.deliveryCompany, crateUnloaded.Id, crateUnloaded.Price.ToString("F2"), status});

                            DataExport.ExportData(data,simulationNumber);
                        }
                    }
                }
                // Remove empty trucks from docks
                foreach(Dock dock in warehouse.Docks){
                    if(dock.Line.Count > 0){
                        Truck truckSentOff = dock.SendOff();
                        if(truckSentOff != null){
                            System.Console.WriteLine($"Truck driver {truckSentOff.driver} left dock {dock.Id} at tick {tick}");
                        }
                    }
                }
                // Calculate dock stats
                foreach(Dock dock in warehouse.Docks){
                    if(dock.Line.Count > 0){
                        dock.TimeInUse++;
                    } else {
                        dock.TimeNotInUse++;
                    }
                }            

                

                System.Console.WriteLine($"Tick {tick} complete. {warehouse.Entrance.Count} trucks waiting to enter. {totalCrates} crates unloaded. ${totalSales} in sales.");
                // Wait 5 seconds
                Thread.Sleep(1000);
            }
            // Calculate total dock cost
            foreach(Dock dock in warehouse.Docks){
                totalDockCost += dock.TimeInUse * 100;
            }

            System.Console.WriteLine($"Simulation {simulationNumber} complete. ${totalDockCost} in dock costs. ${totalSales} in sales. {totalCrates} crates unloaded across {warehouse.Docks.Count} docks.");
            System.Console.WriteLine($"There were {warehouse.Entrance.Count} trucks waiting to enter.");

        }
        public override string ToString() => $"Warehouse has {Docks.Count} docks, {Entrance.Count} trucks waiting to enter.";
    }
}