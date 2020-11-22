using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWorkTwo
{
    /*
     * Реализовать последовательный алгоритм поиска простых чисел;
     */
    class TaskOne
    {
        public int N { get; protected set; }
        private List<int> basePrime;
        private int[] Nums;
        public List<double> Times { get; protected set; }

        public TaskOne(int n)
        {
            N = n;

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

        private void ModifiedSequentialSearchAlgorithm()
        {
            Init();
            for (int i = (int)(Math.Sqrt(N)); i < N + 1; i++)
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
                ModifiedSequentialSearchAlgorithm();
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
