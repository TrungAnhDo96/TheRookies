using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PrimeNumFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeFinderService service = new PrimeFinderService(0, 100000);
            Stopwatch watch = new Stopwatch();

            long synchronousElapsed = MeasureExeTime(() => service.FindPrimeNumbers(), watch);
            Console.WriteLine("Synchronous Prime Number Search time: " + synchronousElapsed);

            long asynchronousElapsed = MeasureExeTime(() => service.FindPrimeNumbersWithAsync(), watch);
            Console.WriteLine("Asynchronous Prime Number Search time: " + asynchronousElapsed);

            //PrintPrimeNumbers(service);
        }

        static long MeasureExeTime(Action action, Stopwatch watch)
        {
            watch.Reset();
            watch.Start();
            action.Invoke();
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }

        static void PrintPrimeNumbers(PrimeFinderService service)
        {
            List<int> collectedPrimeNumbers = service.GetPrimeNumbers();
            Console.WriteLine("Prime number count: " + collectedPrimeNumbers.Count);
            Console.WriteLine("Prime numbers: ");
            foreach (int number in collectedPrimeNumbers)
            {
                Console.Write(" " + number);
            }
        }
    }
}
