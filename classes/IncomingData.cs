using MissingNumberSOLID.Interfaces;

namespace MissingNumberSOLID.Classes
{
    public class IncomingData : IData
    {
        private int[]? numberArray;

        /// <summary>
        /// Input Data Store - in this case from cmd line args
        /// </summary>
        /// <param name="args"></param>
        public IncomingData(string[] args)
        {
            FormatArray(args[0]);
        }


        /// <summary>
        /// Formats input into int array
        /// </summary>
        /// <param name="stringArray"></param>
        private void FormatArray(string stringArray)
        {
            IArrayBuilder builder = new ArrayBuilder();
            numberArray = builder.BuildArray(stringArray);
        }


        public int[]? GetData()
        {
            return numberArray;
        }
    }
}