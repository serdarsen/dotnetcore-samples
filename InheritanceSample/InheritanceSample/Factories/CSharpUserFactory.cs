﻿using System;
using InheritanceSample.Contracts;

namespace InheritanceSample.Factories
{
    public class CSharpUserFactory : BaseUserFactory, ICSharpUserFactory
    {
        public void Update()
        {
            Console.WriteLine("CSharpUserFactory Update");
        }
    }
}