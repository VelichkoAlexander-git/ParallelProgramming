using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LaboratoryWorkThree
{
    /*
     * Реализуйте взаимодействие потоков-читателей и потоков-писателей с общим
     * буфером без каких-либо средств синхронизации. 
     */
    class TaskOne
    {
        public int R { get; protected set; }
        public int W { get; protected set; }
        public int NumMessages { get; protected set; }

        static string buffer;
        static Thread[] Writers;
        static Thread[] Readers;

        private bool bEmpty;
        private bool finish;

        public List<double> Times { get; protected set; }

        public List<string[]> ResultWri { get; protected set; }
        public List<List<string>> ResultRea { get; protected set; }

        public TaskOne(int n, int m, int numMessages)
        {
            R = n;
            W = m;
            NumMessages = numMessages;

            bEmpty = true;
            finish = false;
            Writers = new Thread[W];
            Readers = new Thread[R];
            ResultWri = new List<string[]>();
            ResultRea = new List<List<string>>();
        }

        public void Read()
        {
            List<string> MyMessagesRead = new List<string>();
            while (!finish)
                if (!bEmpty)
                {
                    MyMessagesRead.Add(buffer);
                    bEmpty = true;
                }
            ResultRea.Add(MyMessagesRead);
        }
        public void Write()
        {
            string[] MyMessagesWri = new string[NumMessages];
            for (int j = 0; j < NumMessages; j++)
                MyMessagesWri[j] = j.ToString();
            int i = 0;
            while (i < NumMessages)
                if (bEmpty)
                {
                    buffer = MyMessagesWri[i++];
                    bEmpty = false;
                }
            ResultWri.Add(MyMessagesWri);
        }

        public void Run()
        {
            Times = new List<double>();

            for (int tmp = 0; tmp < 20; tmp++)
            {
                bEmpty = true;
                finish = false;
                Writers = new Thread[W];
                Readers = new Thread[R];
                ResultWri = new List<string[]>();
                ResultRea = new List<List<string>>();

                DateTime dt1 = DateTime.Now;
                for (int i = 0; i < W; i++)
                {
                    Writers[i] = new Thread(Write);
                    Writers[i].Name = i.ToString();
                    Writers[i].Start();
                }
                for (int i = 0; i < R; i++)
                {
                    Readers[i] = new Thread(Read);
                    Readers[i].Start();
                }
                for (int i = 0; i < W; i++)
                    Writers[i].Join();
                finish = true;
                for (int i = 0; i < R; i++)
                    Readers[i].Join();
                DateTime dt2 = DateTime.Now;

                Times.Add((dt2 - dt1).TotalMilliseconds);
            }
        }

        public override string ToString()
        {
            StringBuilder Result = new StringBuilder();

            int cnt = 0;
            for (int i = 0; i < ResultWri.Count; i++)
            {
                cnt += ResultWri[i].GetLength(0);
            }
            Result.AppendLine($"Всего сообщений отправлено:{cnt}");

            cnt = 0;
            for (int i = 0; i < ResultRea.Count; i++)
            {
                if (ResultRea[i] != null)
                    cnt += ResultRea[i].Count;

            }
            Result.AppendLine($"Получено сообщений: {cnt}");

            return Result.ToString();
        }
    }
}
