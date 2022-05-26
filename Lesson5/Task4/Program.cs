using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Task4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Задача ЕГЭ");
            Console.WriteLine("На вход - список учеников в файле Input.txt");
            
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "Input.txt";
            StreamReader sr = new StreamReader(fileName);

            int numberOfStudents = int.Parse(sr.ReadLine());
            //Regex surnameName = new Regex("^[А-Яа-я]{0,20}\\s[А-Яа-я]{0,15}");
            //Regex grades = new Regex(@"\d{1}\s\d{1}\s\d{1}");
            
            Dictionary<string, int> dict = new Dictionary<string, int>();

            char[] sep = { ' ' };
            string[] buffer = new string[5];

            for (int i = 0; i < numberOfStudents; i++)
            {
                string line = sr.ReadLine();
                buffer = line.Split(sep, StringSplitOptions.None);
                dict.Add(buffer[0]+" "+ buffer[1],int.Parse(buffer[2])+int.Parse(buffer[3])+int.Parse(buffer[4]));
            }

            int min=15;
            int min2=15;
            int min3=15;
            
            foreach (var grade in dict)
            {
                if (grade.Value < min)
                    min = grade.Value;
            }

            foreach (var grade in dict)
            {
                if (grade.Value < min2 && grade.Value > min)
                    min2 = grade.Value;
            }

            foreach (var grade in dict)
            {
                if (grade.Value > min2 && grade.Value < min3)
                    min3 = grade.Value;
            }

            Console.WriteLine("Отстающие: ");
            foreach (var e in dict)
            {
                if (e.Value==min || e.Value == min2 || e.Value==min3)
                    Console.WriteLine(e.Key);
            }
            string test = sr.ReadLine();

            
        }
    }
}