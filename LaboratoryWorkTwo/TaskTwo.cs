using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LaboratoryWorkTwo
{
    /*
    * Парраллельный алгоритм. Декомпозиция по данным.
    */
    class TaskTwo
    {
        public int N { get; protected set; }
        public int M { get; protected set; }

        private int cnt;

        private List<int> basePrime;
        private int[] Nums;
        public List<double> Times { get; protected set; }

        public TaskTwo(int n, int m)
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
                arrThr[i].Start(i);
            }
            for (int i = 0; i < M; i++)
                arrThr[i].Join();
        }

        private void Algorithm(object obj)
        {
            int idx = (int)obj;
            int end;
            int Sqrt = (int)Math.Sqrt(N);
            cnt = (N - Sqrt) / M;
            int start = Sqrt + cnt * idx;

            if (idx == M - 1)
            {
                end = N + 1;
            }
            else
            {
                end = start + cnt;
            }

            for (int i = start; i < end; i++)
                foreach (var item in basePrime)
                {
                    if (i % item == 0)
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
