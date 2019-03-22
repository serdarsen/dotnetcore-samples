using System;

namespace GenericsSample
{
    // where T : IComparable 
    // where T : Product        // If T is Product or any of its children
    // where T : struct         // If T is a value type 
    // where T : class          // 
    // where T : new()          // where T is an object that has a default constructor
    public class Utilities<T> where T : IComparable, new()
    {
        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public T Max(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        //public T Max<T>(T a, T b) where T : IComparable
        //{
        //    return a.CompareTo(b) > 0 ? a : b;
        //}

        // Lets say in specific scenarios
        // we want to instantiate an instance of T
        public void DoSomeThing(T value)
        {
            var obj = new T();
        }
    }
}