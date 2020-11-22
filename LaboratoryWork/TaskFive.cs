using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LaboratoryWork
{
    /*
     *  Исследуйте эффективность разделения по диапазону при неравномерной
     *  вычислительной сложности обработки элементов массива.
     */
    class TaskFive
    {
        private int[] a;
        private int[] b;
        private int N;
        private int M;

        public List<double> Times { get; protected set; }

        public TaskFive(int n, int m)
        {
            N = n;
            M = m;
        }

        public void FillingTheArray()
        {
            a = new int[N];
            var Rand = new Random();
            for (int i = 0; i < N; i++)
                a[i] = Rand.Next(0, 9);
        }

        public void Run()
        {
            FillingTheArray();
            Times = new List<double>();

            for (int i = 0; i < 20; i++)
            {
                int Step = N / M;
                int Start = -Step;
                int End = 0;
                Thread[] arrThr = new Thread[M];
                b = new int[N];

                DateTime dt1 = DateTime.Now;
                for (int j = 0; j < M; j++)
                {
                    arrThr[j] = new Thread(Eq);
                    arrThr[j].Start(new int[] { Start += Step, End += Step });
                }

                for (int j = 0; j < M; j++)
                    arrThr[j].Join();
                DateTime dt2 = DateTime.Now;

                Times.Add((dt2 - dt1).TotalMilliseconds);
            }

            a = null;
            b = null;
        }

        private void Eq(object o)
        {
            int Start = ((int[])o)[0];
            int End = ((int[])o)[1];
            for (int i = Start; i < End; i++)
                for (int j = 0; j <= i; j++)
                    b[i] += a[i] * 2;
        }
    }
}
