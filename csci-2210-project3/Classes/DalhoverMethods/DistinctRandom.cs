using System.Runtime.CompilerServices;

namespace Classes.DalhoverClasses.DistinctRand
{
    public class DistinctRandom
    {
        /// <summary>
        /// The minimum value to use
        /// </summary>
        int minValue { get; set; }
        /// <summary>
        /// The maximum value to use, non inclusive
        /// </summary>
        int maxValue { get; set; }
        /// <summary>
        /// The list of options to choose from
        /// </summary>
        List<int> options = new List<int>();
        /// <summary>
        /// The index of the current option
        /// </summary>
        private int optionsIndex;

        /// <summary>
        /// Creates a new <see cref="DistinctRandom"/> with the given <see cref="minValue"/> and <see cref="maxValue"/>
        /// </summary>
        /// <param name="minValue">Minimum value to display</param>
        /// <param name="maxValue">Maximum value to display</param>
        /// <returns>a <see cref="DistinctRandom"/> object</returns>
        /// <remarks>
        /// The <see cref="maxValue"/> is not inclusive
        /// </remarks>
        public DistinctRandom(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.options = GenerateRandomOptions(minValue, maxValue);
            this.optionsIndex = -1;
        }
        /// <summary>
        /// Used to give the user their next random number
        /// </summary>
        /// <returns>Distinct random number</returns>
        public int Next()
        {
            Random rand = new Random();
            this.optionsIndex = rand.Next(this.minValue, this.options.Count);
            int randomNumber = this.options[this.optionsIndex];
            this.options.RemoveAt(this.optionsIndex);
            return randomNumber;

        }
        /// <summary>
        /// Used to populate a list of numbers between the <see cref="minValue"/> and <see cref="maxValue"/>
        /// with the intention of removing them as they are used
        /// </summary>
        /// <param name="minValue">minimum value to include</param>
        /// <param name="maxValue">maximum value to include</param>
        /// <returns>a list of numbers between the given range</returns>
        public static List<int> GenerateRandomOptions(int minValue, int maxValue)
        {
            List<int> options = new List<int>();
            for (int i = minValue; i < maxValue; i++)
            {
                options.Add(i);
            }
            return options;
        }
    }
}