namespace csci_2210_project3.Classes.Utilities{
    /// <summary>
    /// This class is used to get the fake names from the file for both the drivers and companies.
    /// </summary>
    public static class FakeNames
    {
        /// <summary>
        /// The base directory for the fake names.
        /// </summary>
        private static string baseDirectory = "\\FakeNames\\";
        /// <summary>
        /// The file name for the driver names.
        /// </summary>
        private static string driverNamesFile = "DriverNames.txt";
        /// <summary>
        /// The file name for the company names.
        /// </summary>
        private static string companyNamesFile = "companyNames.txt";
        /// <summary>
        /// This method is used to get the driver name from the file.
        /// and returns a random drivers name
        /// </summary>
        /// <returns>a <see cref="string"/>, the <see cref="Driver">'s name</returns>
        public static string GetDriverName()
        {
            string parentWD = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string[] driverNames = File.ReadAllLines(parentWD + baseDirectory + driverNamesFile);
            Random rand = new Random();
            return driverNames[rand.Next(0, driverNames.Length)];
        }
        /// <summary>
        /// This method is used to get a random company name from the file.
        /// </summary>
        /// <returns>a <see cref="string"/>, the company name</returns>
        public static string GetCompanyName()
        {
            string parentWD = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string[] companyNames = File.ReadAllLines(parentWD + baseDirectory + companyNamesFile);
            Random rand = new Random();
            return companyNames[rand.Next(0, companyNames.Length)];
        }
    }
}