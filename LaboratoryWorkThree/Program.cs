using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWorkThree
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskOne taskOne = new TaskOne(2, 2, 1000);
            taskOne.Run();
            Console.WriteLine($"Время min: {taskOne.Times.Min()} | max: {taskOne.Times.Max()}");

            TaskTwo taskTwo = new TaskTwo(2, 2, 1000);
            taskTwo.Run();
            Console.WriteLine($"Время min: {taskTwo.Times.Min()} | max: {taskTwo.Times.Max()}");

            Console.ReadLine();
        }
    }
}
