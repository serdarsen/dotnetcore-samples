﻿using System;
using InheritanceSample.Contracts;

namespace InheritanceSample.Factories
{
    public class JavaUserFactory : UserFactory, IJavaUserFactory
    {
        public void Upgrade()
        {
            Console.WriteLine("JavaUserFactory Upgrade");
        }
    }
}