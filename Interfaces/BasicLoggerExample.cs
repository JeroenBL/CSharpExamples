using System;

namespace newConsole
{
    internal class Program
    {
        static Ilogger GetLogger()
        {
            return new ConsoleLogger();
        }

        static void Main(string[] args)
        {
            var logger = GetLogger();
            logger.LogMessage("Hello World");
            logger.LogMessage("Press any key to exit the program!");
            Console.ReadLine();
        }
    }

    public interface Ilogger 
    {
        void LogMessage(string message);
    }

    public class ConsoleLogger : Ilogger 
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"[ConsoleLogger]: {message}");
        }
    }
}
