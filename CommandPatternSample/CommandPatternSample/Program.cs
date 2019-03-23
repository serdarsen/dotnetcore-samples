using System;

namespace CommandPatternSample
{
    class Program
    {
        static void Main(string[] args)
        {
            IElectronicDevice TV = TVRemote.GetDevice();

            PowerButton powerButton = new PowerButton(TV);

            powerButton.Execute();
            powerButton.Undo();
        }
    }
}
