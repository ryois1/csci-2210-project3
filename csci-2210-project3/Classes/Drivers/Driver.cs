namespace Classes.Drivers
{
    public class Driver
    {
        public string FullName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        private string NickName { get; set; }

        public Driver(string[] driverInfo)
        {
            FirstName = driverInfo[0].Trim();
            LastName = driverInfo[2].Trim();
            NickName = driverInfo[1].Replace("\"", "").Trim();
            FullName = $"{FirstName}, the {NickName}, {LastName}";
        }
    }
}