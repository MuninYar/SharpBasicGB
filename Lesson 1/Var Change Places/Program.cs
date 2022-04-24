using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var_Change_Places
{
    internal class VarChangePlaces
    {
        /* 
        Написать программу обмена значениями двух переменных типа int без использования вспомогательных методов.
            а) с использованием третьей переменной;
            б) без использования третьей переменной. 
        */

        //Резчиков Ярослав
        static void Main(string[] args)
        {
            // C использованием 3 переменной
            int a = 10;
            int b = 20;
            Console.WriteLine($"a= {a} b= {b}");
            int c = a;
            a = b;
            b = c;
            Console.WriteLine($"a= {a} b= {b}");

            // Без использования 3 переменной
            string a3 = "b3";
            string b3 = "a3";
            Console.WriteLine($"a= {a3} b= {b3}");
            (a3,b3) = (b3, a3);
            Console.WriteLine($"a= {a3} b= {b3}");

            // Частный случай для числовых значений
            double a2 = 5.5;
            double b2 = 8.1;
            Console.WriteLine($"a= {a2} b= {b2}");
            a2 = a2 + b2;
            b2 = b2 - a2;
            b2 = -b2;
            a2 = a2 - b2;
            Console.WriteLine($"a= {a2} b= {b2}");
        }
    }
}
