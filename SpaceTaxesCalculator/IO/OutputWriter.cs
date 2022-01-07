using System;

namespace SpaceTaxesCalculator.IO
{
    public static class OutputWriter
    {
        public static void Write(string message)
            => Console.Write(message);

        public static void WriteLine(string message)
            => Console.WriteLine(message);

        public static void DisplayExceptions(string message)
        {
            ConsoleColor currentConsoleFontColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentConsoleFontColor;
        }
    }
}