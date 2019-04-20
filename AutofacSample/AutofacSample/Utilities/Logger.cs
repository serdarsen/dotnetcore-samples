﻿using System;

using AutofacSample.Utilities.Contracts;

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