using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_To_Screen_Center
{
    internal class Program
    {
        /*
        а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
        б) Сделать задание, только вывод организовать в центре экрана.
        в) *Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y).
         */

        //Резчиков Ярослав
        static void Main(string[] args)
        {
            string[] dataToPrint = new string[] { "Yaroslav", "Rezchikov", "Erevan" };
            for (int i = 0; i < dataToPrint.Length; i++)
            {
            Print(dataToPrint[i], (Console.WindowWidth / 2 - (dataToPrint[i].Length/2)), Console.WindowHeight / 2+i);
            }
        }
        static void Print(string output, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(output);
        }
    }
}
