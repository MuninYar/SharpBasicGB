using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceBtwDots
{
    /*
        а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). 
           Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
        б) Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
     */

    //Резчиков Ярослав
    internal class DistanceBtwDots
    {

        static void Main(string[] args)
        {
            // User Input

            Console.Write("X1 = ");
            int x1 = int.Parse(Console.ReadLine());
            Console.Write("Y1 = ");
            int y1 = int.Parse(Console.ReadLine());
            Console.Write("X2 = ");
            int x2 = int.Parse(Console.ReadLine());
            Console.Write("Y1 = ");
            int y2 = int.Parse(Console.ReadLine());

            Console.WriteLine(GetDistanceBtwDots(x1, y1, x2, y2)); 

            // Вычисление distanceBtwDots в Main
            /*
            double distanceBtwDots =Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            Console.WriteLine(distanceBtwDots.ToString("0.##"));
            */
        }

        static string GetDistanceBtwDots(int x1,int y1, int x2, int y2)
        {
            double distanceBtwDots = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            return distanceBtwDots.ToString("0.##");
        }
    }
}
