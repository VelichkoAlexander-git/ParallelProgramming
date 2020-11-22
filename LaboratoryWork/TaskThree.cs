using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LaboratoryWork
{
    /*
     * Выполните анализ эффективности многопоточной обработки при разных
     * параметрах N (10, 100, 1000, 100000) и M (2, 3, 4, 5, 10). Результаты представьте в
     * табличной форме.
    */
    class TaskThree
    {
        private int[] a;
        private int[] b;
        private int N;
        private int M;
        private int[] N_list = new int[] { 10, 100, 1000, 100000 };
        private int[] M_list = new int[] { 2, 3, 4, 5, 10 };

        public StringBuilder TimesString { get; protected set; }

        public TaskThree()
        {
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
            TimesString = new StringBuilder();
            foreach (var n in N_list)
                foreach (var m in M_list)
                {

                    N = n;
                    M = m;

                    FillingTheArray();
                    List<double> Times = new List<double>();

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

                    TimesString.Append($"N = {N} | M = {M} | Time: min = {Times.Min()} , max = {Times.Max()}\n");
                }
        }

        private void Eq(object o)
        {
            int Start = ((int[])o)[0];
            int End = ((int[])o)[1];
            for (int i = Start; i < End; i++)
                b[i] = a[i] * 2;
        }
    }
}
