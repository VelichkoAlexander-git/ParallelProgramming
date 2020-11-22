using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LaboratoryWorkTwo
{
    /*
    * Парраллельный алгоритм. Последовательный перебор простых чисел.
    */
    class TaskFive
    {
        public int N { get; protected set; }
        public int M { get; protected set; }

        private int current_index;
        private List<int> basePrime;
        private int[] Nums;
        public List<double> Times { get; protected set; }

        public TaskFive(int n, int m)
        {
            N = n;
            M = m;

            basePrime = new List<int>();
            Nums = new int[N + 1];
        }

        public void Init()
        {
            for (int i = 2; i < Math.Sqrt(N); i++)
            {
                if (Nums[i] == 0)
                {
                    for (int j = i + 1; j < Math.Sqrt(N); j++)
                        if (j % i == 0)
                            Nums[j] = 1;
                    basePrime.Add(i);
                }
            }
        }

        private void SequentialSearchAlgorithm()
        {
            Init();
            Thread[] arrThr = new Thread[M];
            for (int i = 0; i < M; i++)
            {

                arrThr[i] = new Thread(Algorithm);
                arrThr[i].Start();
            }
            for (int i = 0; i < M; i++)
                arrThr[i].Join();
        }

        private void Algorithm()
        {
            int current_prime;
            int Len = basePrime.Count;
            while (true)
            {
                if (current_index >= Len)
                    break;

                lock ("Critical")
                {
                    current_prime = basePrime[current_index];
                    current_index++;
                }

                for (int i = (int)Math.Sqrt(N); i < N + 1; i++)
                    if (i % current_prime == 0)
                        Nums[i] = 1;
            }
        }

        public void Run()
        {
            Times = new List<double>();

            for (int i = 0; i < 20; i++)
            {
                basePrime = new List<int>();
                Nums = new int[N + 1];
                current_index = 0;

                DateTime dt1 = DateTime.Now;
                SequentialSearchAlgorithm();
                DateTime dt2 = DateTime.Now;

                Times.Add((dt2 - dt1).TotalMilliseconds);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 2; i < N - 1; i++)
            {
                if (Nums[i] == 0) builder.Append($"{i} ");
            }
            return builder.ToString();
        }
    }
}
