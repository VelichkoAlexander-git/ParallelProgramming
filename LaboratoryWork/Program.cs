using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork
{
    class Program
    {
        static void Main(string[] args)
        {

            TaskOne taskOne = new TaskOne(50);
            taskOne.Run();
            Console.WriteLine($"Время min: {taskOne.Times.Min()} | max: {taskOne.Times.Max()}");

            TaskTwo taskTwo = new TaskTwo(50, 4);
            taskTwo.Run();
            Console.WriteLine($"Время min: {taskTwo.Times.Min()} | max: {taskTwo.Times.Max()}");

            TaskThree taskThree = new TaskThree();
            taskThree.Run();
            Console.WriteLine(taskThree.TimesString);

            TaskFour taskFour = new TaskFour(50, 4, 3);
            taskFour.Run();
            Console.WriteLine($"Время min: {taskFour.Times.Min()} | max: {taskFour.Times.Max()}");

            TaskFive taskFive = new TaskFive(50, 4);
            taskFive.Run();
            Console.WriteLine($"Время min: {taskFive.Times.Min()} | max: {taskFive.Times.Max()}");

            Console.ReadLine();
        }
    }
}
