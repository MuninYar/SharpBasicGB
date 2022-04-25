using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yar.Learning
{
    public class OutputSamples
    {
        public static void PrintHead(int lessonNumber)
        {
            Console.WriteLine("====================");
            Console.WriteLine(" C# Basics");
            Console.WriteLine(" Yaroslav Rezchikov");
            Console.WriteLine($" Lesson: {lessonNumber}");
            Console.WriteLine("====================");
        }
        public static void PrintMenu(int tasksNumber, string [] taskCondition)
        {
            Console.WriteLine("===================");
            Console.WriteLine(" MENU");
            for (int i = 0; i < tasksNumber; i++)
                Console.WriteLine($"{i+1} -> Task N {i+1} ... {taskCondition[i]}");
            Console.WriteLine("0 -> End program... ");
            Console.WriteLine("===================");
        }
        public static void BackToMenu()
        {
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void PrintTaskCondition(string condition)
        {
            for (int i = 0; i < condition.Length+4; i++)
                Console.Write("=");
                Console.WriteLine();
            Console.WriteLine("# " + condition + " #");
            for (int i = 0; i < condition.Length+4; i++)
                Console.Write("=");
                Console.WriteLine();
        }
        public static void Explousion()
        {
            Console.WriteLine("___________________$$$$$$$$$$$$$");
            Console.WriteLine("_____________$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("___________$$$___$$$$$$$$$$$$$$$$___$$$");
            Console.WriteLine("_________$$$______$$$$$$$$$$$$$$______$$$");
            Console.WriteLine("_______$$$_________$$$$$$$$$$$$_________$$$");
            Console.WriteLine("______$$$____________$$$$$$$$$____________$$$");
            Console.WriteLine("_____$$$______________$$$$$$$______________$$$");
            Console.WriteLine("____$$$________________$$$$$________________$$$");
            Console.WriteLine("____$$_______________________________________$$");
            Console.WriteLine("____$$_______________________________________$$");
            Console.WriteLine("____$$$$$$$$$$$$$$$$$_________$$$$$$$$$$$$$$$$$");
            Console.WriteLine("____$$$$$$$$$$$$$$$$$$_______$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("_____$$$$$$$$$$$$$$$$$_______$$$$$$$$$$$$$$$$$");
            Console.WriteLine("______$$$$$$$$$$$$$$$_________$$$$$$$$$$$$$$$");
            Console.WriteLine("_______$$$$$$$$$$$$$___________$$$$$$$$$$$$$");
            Console.WriteLine("________$$$$$$$$$$$_____________$$$$$$$$$$$");
            Console.WriteLine("__________$$$$$$$$_______________$$$$$$$$");
            Console.WriteLine("____________$$$$$_________________$$$$$");
            Console.WriteLine("_______________$$$$$$$_______$$$$$$$");
            Console.WriteLine("___________________$$$$$$$$$$$$$");
        }
    }
}
