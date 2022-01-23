using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeNumFinder
{
    class PrimeFinderService
    {
        private List<int> _primeNumbers;
        private int _min;
        private int _max;

        public PrimeFinderService(int min, int max)
        {
            _primeNumbers = new List<int>();
            _min = min;
            _max = max;
        }

        public void FindPrimeNumbersWithAsync()
        {
            Task[] tasks = new Task[_max - _min + 1];
            for (int i = _min; i <= _max; i++)
            {
                tasks[i] = Task.Run(() => CollectValidPrimeNumber(i));
            }

            Task.WaitAll(tasks);
        }

        public void FindPrimeNumbers()
        {
            for (int i = _min; i <= _max; i++)
            {
                CollectValidPrimeNumber(i);
            }
        }

        private void CollectValidPrimeNumber(int num)
        {
            if (IsPrimeNumber(num))
                _primeNumbers.Add(num);
        }

        private bool IsPrimeNumber(int num)
        {
            int primeValidDividorCount = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                    primeValidDividorCount++;
            }

            return primeValidDividorCount == 2;
        }

        public List<int> GetPrimeNumbers()
        {
            return _primeNumbers;
        }
    }
}