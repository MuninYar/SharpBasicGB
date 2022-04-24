using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnarie
{
    /* 
        Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
        В результате вся информация выводится в одну строчку:
            а) используя склеивание;
            б) используя форматированный вывод;
            в) используя вывод со знаком $. 

        Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h);
        где m — масса тела в килограммах, h — рост в метрах.
    */


    // Резчиков Ярослав
    internal class Questionnarie
    { 
        static void Main(string[] args)
        {
            // User Input
            Console.Write("Your name? ");
            string name = Console.ReadLine();
            Console.Write("Your surname? ");
            string surname = Console.ReadLine();
            Console.Write("Your age? ");
            string age = Console.ReadLine();
            Console.Write("Your hight? ");
            double hight = double.Parse(Console.ReadLine());
            Console.Write("Your weight? ");
            double weight = double.Parse(Console.ReadLine());

            // Вывод анкетных данных
            Console.WriteLine(name + " " + surname + " " + age + " year's old " + hight + " cm " + weight + " kg");
            Console.WriteLine("{0} {1} {2} year's old {3} cm {4} kg", name,surname,age,hight,weight);
            Console.WriteLine($"{name} {surname} {age} year's old {hight} cm {weight} kg");

            //Рассчет и вывод ИМТ
            Console.WriteLine($"BMI = {CalculateBodyMassIndex(hight,weight)}");

            //Интерпритация ИМТ
            Console.WriteLine($"Your BMI is {BMIinterpritator(CalculateBodyMassIndex(hight,weight))}");

        }
        static double CalculateBodyMassIndex (double hight, double weight)
        {
            return Math.Round((weight / (hight * hight) * 10000),2); //Коэфициент 10к для перевода см2 в м2
        }
        static string BMIinterpritator(double BMI)
        {
            if (BMI >= 18.5 && BMI <= 25)
                return "normal";
            else if (BMI > 25)
                return "high";
            else
                return "low";
        }
    }
}
