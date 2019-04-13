using System;
using AutofacSample.Contracts;

namespace AutofacSample.Utilities
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}