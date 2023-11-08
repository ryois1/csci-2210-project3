namespace csci_2210_project3.Classes.Utilities{
    public static class FakeNames{
        private static string baseDirectory = "\\FakeNames\\";
        private static string driverNamesFile = "DriverNames.txt";
        private static string companyNamesFile = "companyNames.txt";

        public static string GetDriverName(){
            string parentWD = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string[] driverNames = File.ReadAllLines(parentWD + baseDirectory + driverNamesFile);
            Random rand = new Random();
            return driverNames[rand.Next(0, driverNames.Length)];
        }

        public static string GetCompanyName(){
            string parentWD = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string[] companyNames = File.ReadAllLines(parentWD + baseDirectory + companyNamesFile);
            Random rand = new Random();
            return companyNames[rand.Next(0, companyNames.Length)];
        }
    }
}