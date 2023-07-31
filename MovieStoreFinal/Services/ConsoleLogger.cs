using System;

namespace MovieStore.Services
{
    public class ConsoleLogger : ILoggerServices
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] - " + message);
        }
    }
}
