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
            TaskOne taskOne = new TaskOne(2,2, 1000);
            taskOne.Run();
            Console.WriteLine($"Время min: {taskOne.Times.Min()} | max: {taskOne.Times.Max()}");

            TaskTwo taskTwo = new TaskTwo(2, 2, 1000);
            taskTwo.Run();
            Console.WriteLine($"Время min: {taskTwo.Times.Min()} | max: {taskTwo.Times.Max()}");

            TaskThree taskThree = new TaskThree(2, 2, 1000);
            taskThree.Run();
            Console.WriteLine($"Время min: {taskThree.Times.Min()} | max: {taskThree.Times.Max()}");

            TaskFour taskFour = new TaskFour(2, 2, 1000);
            taskFour.Run();
            Console.WriteLine($"Время min: {taskFour.Times.Min()} | max: {taskFour.Times.Max()}");

            TaskFive taskFive = new TaskFive(2, 2, 1000);
            taskFive.Run();
            Console.WriteLine($"Время min: {taskFive.Times.Min()} | max: {taskFive.Times.Max()}");

            Console.ReadLine();
        }
    }
}
