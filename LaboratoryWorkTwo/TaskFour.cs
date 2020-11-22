using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LaboratoryWorkTwo
{
    /*
    * Парраллельный алгоритм. Применение пула потоков
    */
    class TaskFour
    {
        public int N { get; protected set; }
        public int M { get; protected set; }

        private List<int> basePrime;
        private int[] Nums;
        public List<double> Times { get; protected set; }

        public TaskFour(int n, int m)
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
            int Len = basePrime.Count;
            CountdownEvent events = new CountdownEvent(Len);

            for (int i = 0; i < Len; i++)
            {
                ThreadPool.QueueUserWorkItem(Algorithm, new object[] { basePrime[i], events });
            }

            events.Wait();
        }

        private void Algorithm(object obj)
        {
            int Sqrt = (int)Math.Sqrt(N);
            int prime = (int)((object[])obj)[0];
            CountdownEvent ev = ((object[])obj)[1] as CountdownEvent;
            for (int i = Sqrt; i < N + 1; i++)
                if (i % prime == 0)
                    Nums[i] = 1;
            ev.Signal();
        }

        public void Run()
        {
            Times = new List<double>();

            for (int i = 0; i < 20; i++)
            {
                basePrime = new List<int>();
                Nums = new int[N + 1];
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
