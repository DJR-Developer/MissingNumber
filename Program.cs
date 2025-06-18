using MissingNumberSOLID.Classes;
using MissingNumberSOLID.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MissingNumberSOLID
{
    public class Program
    {
        static void Main(string[] args)
        {
            // In this case we're using command line args as input
            var incomingData = new IncomingData(args);

            // Setup Dependency Injection for input data
            var services = new ServiceCollection()
                .AddSingleton(incomingData)
                .AddTransient<App>()
                .BuildServiceProvider();

            services.GetRequiredService<App>().Run();
        }
    }


    /// <summary>
    /// Application - receives a number array and if valid displays missing values.
    /// </summary>
    public class App
    {
        private readonly IncomingData _incomingData;

        public App(IncomingData incomingData)
        {
            _incomingData = incomingData;
        }

        public void Run()
        {
            int[]? numberArray = _incomingData.GetData();

            if (numberArray == null)
            {
                Console.WriteLine("Error: Invalid Array format.");
                Console.WriteLine("Sample Format: \"[1, 2, 4]\"");
                return;
            }

            if (numberArray.Length == 0)
            {
                Console.WriteLine("Please submit a list of numbers to build an array.");
                Console.WriteLine("Sample Format: \"[1, 2, 4]\"");
                return;
            }

            IArraySolver solver = new ArraySolver();
            List<int> missingNumbers = solver.FindMissingNumber(numberArray);

            if (missingNumbers.Count == 0)
            {
                Console.WriteLine($"There are no missing numbers in the array {string.Join(", ", numberArray.Where(n => n > 0))}.");
            }

            Console.WriteLine($"The missing number/s in the array {string.Join(", ", numberArray.Where(n => n > 0))} are: {string.Join(", ", missingNumbers.Where(n => n > 0))}.");
        }
    }
}