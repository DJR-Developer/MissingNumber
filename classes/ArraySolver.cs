using MissingNumberSOLID.Interfaces;

namespace MissingNumberSOLID.Classes
{
    public class ArraySolver : IArraySolver
    {
        /// <summary>
        /// Looks at the supplied int array and determines if any number are missing in the sequence
        /// </summary>
        /// <param name="array">Integer Array</param>
        /// <returns>An integer list with any missing numbers</returns>
        public virtual List<int> FindMissingNumber(int[] array)
        {
            List<int> missingNumbers = new List<int>();

            Array.Sort(array);

            for (int pos = 0; pos < array.Length; pos++)
            {
                if (pos == 0) continue; // Nothing can be missing at the beginning

                int expectedValue = array[pos - 1] + 1;
                if (array[pos] != expectedValue) missingNumbers.Add(expectedValue);
            }

            return missingNumbers;
        }
    }
}