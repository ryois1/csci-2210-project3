namespace csci_2210_project3.Classes.Drivers
{
    /// <summary>
    /// This class is used to represent a truck driver
    /// </summary>
    public class Driver
    {
        /// <summary>
        /// The full name of the driver
        /// </summary>
        public string FullName { get; private set; }
        /// <summary>
        /// The first name of the driver
        /// </summary>
        public string FirstName { get; private set; }
        /// <summary>
        /// The last name of the driver
        /// </summary>
        public string LastName { get; private set; }
        /// <summary>
        /// The nickname of the driver
        /// </summary>
        /// <remarks> this includes their nickname </remarks>
        private string NickName { get; set; }
        /// <summary>
        /// The constructor for the <see cref="Driver"/> class
        /// </summary>
        /// <param name="driverInfo">the drivers info line</param>
        /// <remarks>the driver info line must be split by commas</remarks>
        public Driver(string[] driverInfo)
        {
            FirstName = driverInfo[0].Trim();
            LastName = driverInfo[2].Trim();
            NickName = driverInfo[1].Replace("\"", "").Trim();
            FullName = $"{FirstName}, the {NickName}, {LastName}";
        }
    }
}