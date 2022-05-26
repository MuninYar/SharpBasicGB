using System;

public delegate double Fun (double x);

public delegate double Fun2 (double x, double y);

class Program
{
    public static void Table(Fun2 F, double x,double a, double b)
    {
        Console.WriteLine("----- X ----- Y -----");
        while (x <= b)
        {
            Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x,a));
            x += 1;
        }
        Console.WriteLine("---------------------");
    }
    public static double MyFunc(double x)
    {
        return x * x * x;
    }

    public static double MyFunc2(double a, double x)
    {
        return a * (x * x);
    }

    public static double MyFunc3(double a, double x)
    {
        return a * Math.Sin(x);
    }
    
    static void Main()
    {
        // Console.WriteLine("Таблица функции MyFunc:");
        // Table(new Fun(MyFunc),-2,2);
        //
        // Console.WriteLine("Еще раз та же таблица, но вызов организован по-новому"); 
        // Table(MyFunc, -2, 2);
        //
        // Console.WriteLine("Таблица функции Sin:");
        // Table(Math.Sin, -2, 2); 
        //
        // Console.WriteLine("Таблица функции x^2:");
        // Table(delegate (double x) { return x * x; }, 0, 3);
        
        Console.WriteLine("Таблица функции a*x^2");
        Table(new Fun2(MyFunc2),1,3, 5);

        Console.WriteLine("Таблица функции a*sin(x)");
        Table(new Fun2(MyFunc3),1,3,5);
    }
}
