using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace DoubleBinary
{
    class UserInput
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double From { get; set; }
        public double To { get; set; }
        public double Step { get; set; }
    }
    class Program
    {
        public delegate double Function (double x, double a, double b, double c);
        public static double F2(double x, double a, double b, double c)
        {
            return a * (x * x) + b * x + c;
        }
        public static double F3(double x, double a, double b, double c)
        {
            return a * (x * x * x) + b * x + c;
        }
        
        public static void SaveFunc(Function F, string fileName, UserInput input)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = input.From;
            while (x<=input.To)
            {
                bw.Write(F(x, input.A, input.B, input.C));
                x += input.Step;
            }
            bw.Close();
            fs.Close();
        }
        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double[] valueArray = new double [fs.Length / sizeof(double)];
            min = double.MaxValue;
            double d;
            for(int i=0;i<fs.Length/sizeof(double);i++)
            {
                d = bw.ReadDouble();
                valueArray[i] = d;
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return valueArray;
        }
        static void Main(string[] args)
        {
            List<Function> delegateList = new List<Function>()
            {
                F2,
                F3
            };
            
            Console.WriteLine("Зададим параметры функции для поиска минимума функции:");
            var input = GetUserInput();
            
            int userInput;
            do
            {
                Console.WriteLine("Выбирите функцию: ");
                Console.WriteLine("1 - ax^2 + bx + c");
                Console.WriteLine("2 - ax^3 + bx + c");
                Console.WriteLine("Для выхода - любое другое число");
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            
            switch (userInput)
            {
                default: return;
                case 1:
                    SaveFunc(delegateList[0],"data.bin", input);
                    PrintArray(Load("data.bin", out double min1));
                    Console.WriteLine($"Минимум = {min1}");
                    Console.ReadKey();
                    break;
                case 2:
                    SaveFunc(delegateList[1],"data.bin", input);
                    PrintArray(Load("data.bin", out double min2));
                    Console.WriteLine($"Минимум = {min2}");
                    Console.ReadKey();
                    break;
            }
        }
        private static UserInput GetUserInput()
        {
            UserInput input = new UserInput();
            while (true)
            {
                Console.Write("a = ");
                if (!double.TryParse(Console.ReadLine(), out double a))
                {
                    Console.WriteLine("Введите число!");
                }
                else
                {
                    input.A = a;
                    break;
                }
            }
            while (true)
            {
                Console.Write("b = ");
                if (!double.TryParse(Console.ReadLine(), out double a))
                {
                    Console.WriteLine("Введите число!");
                }
                else
                {
                    input.B = a;
                    break;
                }
            }
            while (true)
            {
                Console.Write("c = ");
                if (!double.TryParse(Console.ReadLine(), out double a))
                {
                    Console.WriteLine("Введите число!");
                }
                else
                {
                    input.C = a;
                    break;
                }
            }
            while (true)
            {
                Console.Write("From = ");
                if (!double.TryParse(Console.ReadLine(), out double a))
                {
                    Console.WriteLine("Введите число!");
                }
                else
                {
                    input.From = a;
                    break;
                }
            }
            while (true)
            {
                Console.Write("To = ");
                if (!double.TryParse(Console.ReadLine(), out double a))
                {
                    Console.WriteLine("Введите число!");
                }
                else
                {
                    input.To = a;
                    break;
                }
            }
            while (true)
            {
                Console.Write("Step = ");
                if (!double.TryParse(Console.ReadLine(), out double a))
                {
                    Console.WriteLine("Введите число!");
                }
                else
                {
                    input.Step = a;
                    break;
                }
            }
            return input;
        }

        private static void PrintArray(double[] arr)
        {
            Console.WriteLine("Значения: ");
            foreach (var value in arr)
            {
                Console.Write($"{value} \t");
            }
            Console.WriteLine();
        }
    }
}
