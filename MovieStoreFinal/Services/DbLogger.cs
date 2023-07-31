using System;

namespace MovieStore.Services
{
    public class DBLogger : ILoggerServices
    {
        public void Write(string message)
        {
            Console.WriteLine("[DBLogger] - " + message);
        }
    }
}
