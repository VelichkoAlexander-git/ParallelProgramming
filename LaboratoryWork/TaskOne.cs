using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LaboratoryWork
{
    /*
    * Реализуйте последовательную обработку элементов массива, например,
    * умножение элементов массива на число. Число элементов массива задается
    * параметром N.
    */
    class TaskOne
    {
        private int[] a;
        private int[] b;
        private int N;

        public List<double> Times { get; protected set; }

        public TaskOne(int n)
        {
            N = n;
        }

        public void FillingTheArray()
        {
            a = new int[N];
            b = new int[N];
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
                b = new int[N];
                var thr = new Thread(Eq);
                //вычислительная процедура
                DateTime dt1 = DateTime.Now;
                thr.Start(new int[] { 0, N });
                thr.Join();
                DateTime dt2 = DateTime.Now;

                Times.Add((dt2 - dt1).TotalMilliseconds);
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
