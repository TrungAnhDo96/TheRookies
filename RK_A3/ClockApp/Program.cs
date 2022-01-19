using System.Threading;
using System;

namespace ClockApp
{
    class Program
    {
        public delegate void ClockUpdate();

        static void Main(string[] args)
        {
            ClockService service = new ClockService(59);
            ClockUpdate clockUpdate = new ClockUpdate(service.Increment);
            clockUpdate += new ClockUpdate(() =>
            {
                Thread.Sleep(1000);
            });

            Console.WriteLine("Timer Start! Press any key to stop....");
            while (!Console.KeyAvailable)
            {
                clockUpdate.Invoke();
                Console.WriteLine("Current Time: " + service.ShowClock());
            }
        }
    }
}
