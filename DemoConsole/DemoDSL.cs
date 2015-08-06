using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

using static System.Console;

namespace ConsoleApplication1
{
    public static class DemoDSL
    {
        public static T Out<T>(Expression<Func<T>> expr)
        {
            WriteLine("======================================================");
            WriteLine(expr.Body.ToString());
            var result = expr.Compile().Invoke();
            WriteLine(result);
            WriteLine();
            return result;
        }

        public static T Guard<T>(T obj, string parameterName, string message = null, Exception innerException = null)
        {
            if (obj == null) throw new ArgumentException(message, parameterName, innerException);
            return obj;
        }
        
        public async static Task LogAsync(string message)
        {
            var color = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"LOG > {message}");
            ForegroundColor = color;
            await Task.Delay(1000);
            return;
        }
    }
}
