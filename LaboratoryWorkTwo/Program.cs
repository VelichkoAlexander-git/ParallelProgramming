using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWorkTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskOne taskOne = new TaskOne(1000);
            taskOne.Run();
            Console.WriteLine($"Время min: {taskOne.Times.Min()} | max: {taskOne.Times.Max()}");

            TaskTwo taskTwo = new TaskTwo(1000, 3);
            taskTwo.Run();
            Console.WriteLine($"Время min: {taskTwo.Times.Min()} | max: {taskTwo.Times.Max()}");

            TaskThree taskThree = new TaskThree(1000, 3);
            taskThree.Run();
            Console.WriteLine($"Время min: {taskThree.Times.Min()} | max: {taskThree.Times.Max()}");

            TaskFour taskFour = new TaskFour(1000, 3);
            taskFour.Run();
            Console.WriteLine($"Время min: {taskFour.Times.Min()} | max: {taskFour.Times.Max()}");

            TaskFive taskFive = new TaskFive(1000, 3);
            taskFive.Run();
            Console.WriteLine($"Время min: {taskFive.Times.Min()} | max: {taskFive.Times.Max()}");

            Console.ReadLine();
        }
    }
}
