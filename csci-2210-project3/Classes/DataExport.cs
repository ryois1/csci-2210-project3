using System;
using System.IO;
using System.Collections.Generic;
using csci_2210_project3.Classes;

namespace csci_2210_project3.Classes
{
    public class DataExport
    {
        /// <summary>
        /// Method to export important data to a csv file.
        /// </summary>
        /// <param name="data"></param>
        /// <param name= "timeTick"></param>
        /// <param name= "simulationNumber"></param>
        public static void ExportData(List<string> data, int simulationNumber)
        {
            string Filepath = "./DataOutput/";
            // Create file directory if it doesn't exist
            if (!Directory.Exists(Filepath))
            {
                Directory.CreateDirectory(Filepath);
            }
            string FileName = $"output{simulationNumber}.csv";
            //allows for multiple output files depending on the simulation number
            string outputFile = Filepath + FileName;
            Console.WriteLine($"Exporting data to {outputFile}...");
            // Create a new file if it doesn't exist and write the header and close the file
            if (!File.Exists(outputFile))
            {
                using (StreamWriter sw = File.CreateText(outputFile))
                {
                    sw.WriteLine(
                        "Time Increment, Driver's name, Company Name, CrateID, Crate Value, Status"
                    );
                    sw.Close();
                }
            }

            // Open the file and write the data to it
            using (StreamWriter sw = File.AppendText(outputFile))
            {
                // Iterate through the data list and write each part of the line, separated by commas, to the file
                for (int i = 0; i < data.Count; i++)
                {
                    sw.Write(data[i]);
                    if (i != data.Count - 1)
                    {
                        sw.Write(",");
                    }
                }

                sw.WriteLine();
                sw.Close();
            }
        }

        /// <summary>
        /// Method to export important results to a csv file.
        /// </summary>
        /// <param name="data">someone fill this out idk how this works</param>
        /// <param name="simulationNumber">             someone fill this out idk how this works</param>
        public static void ExportResults(List<string> data, int simulationNumber)
        {
            string Filepath = "./DataOutput/";
            // Create file directory if it doesn't exist
            if (!Directory.Exists(Filepath))
            {
                Directory.CreateDirectory(Filepath);
            }
            string FileName = $"Results{simulationNumber}.csv";
            //allows for multiple output files depending on the simulation number
            string outputFile = Filepath + FileName;
            Console.WriteLine($"Exporting results to {outputFile}...");
            // Create a new file if it doesn't exist and write the header and close the file
            if (!File.Exists(outputFile))
            {
                using (StreamWriter sw = File.CreateText(outputFile))
                {
                    sw.WriteLine(
                        "Open Docks, Longest Line, Total Trucks Processed, Total Crates Unloaded, Total Value, Average Crate Value, Average Truck Value, Total Time Dock was Open,"
                            + "Titak Tune Dock was not Used, Total Cost of Operating each dock"
                    );
                    sw.Close();
                }
            }

            // Open the file and write the data to it
            using (StreamWriter sw = File.AppendText(outputFile))
            {
                // Iterate through the data list and write each part of the line, separated by commas, to the file
                for (int i = 0; i < data.Count; i++)
                {
                    sw.Write(data[i]);
                    if (i != data.Count - 1)
                    {
                        sw.Write(",");
                    }
                }

                sw.WriteLine();
                sw.Close();
            }
        }
    }
}
