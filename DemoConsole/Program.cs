using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static ConsoleApplication1.DemoDSL;

namespace ConsoleApplication1
{
    // Null Conditional ?.
    // Null Conditional ?[]
    // Auto Property Initializers
    // nameof() expressions
    // Expression bodied methods
    // String Interpolation
    //   * FormattableString
    // await in catch blocks
    // Exception Filtering

    class Program
    {
        static void Main(string[] args)
        {
            Out(() => AsyncMethodExample(10, 10)).Wait();
            Out(() => AsyncMethodExample(null, 10)).Wait();
            Out(() => AsyncMethodExample(10, null)).Wait();

            Out(() => GetFirstFourCharacters(null));
            Out(() => GetFirstFourCharacters("sml"));
            Out(() => GetFirstFourCharacters("Lots of data to be seen here"));
            Out(() => new Person().ToString());

            Console.ReadLine();
        }

        private static async Task AsyncMethodExample(int? xCoordinate, int? yCoordinate)
        {
            try
            {
                Guard(xCoordinate, nameof(xCoordinate));
                Guard(yCoordinate, nameof(yCoordinate));
            }
            catch (ArgumentException ex) when (ex.ParamName == nameof(yCoordinate))
            {
                await LogAsync($"Y > {ex.Message}");
            }
            catch (ArgumentException ex) when (ex.ParamName == nameof(xCoordinate))
            {
                await LogAsync($"X > {ex.Message}");
            }
        }

        private static string GetFirstFourCharacters(string verboseParameterName)
        {
            if (verboseParameterName?.Length < 4) return nameof(verboseParameterName);
            return verboseParameterName?.Substring(0, 4) ?? "NULL";
        }
    }

    public class Person
    {
        public string FirstName { get; } = "Tim";
        public string LastName { get; } = "Rayburn";

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
