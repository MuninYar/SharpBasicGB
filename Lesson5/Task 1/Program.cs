using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Yar.Learning;

namespace Task_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            OutputSamples.PrintHead(5);
            Console.Clear();
            Console.WriteLine(@"Task 1:
Создать программу, которая будет проверять корректность ввода логина. 
Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, 
при этом цифра не может быть первой.
а) Без использования регулярных выражений:");
            Console.WriteLine("Введите логин: ");
            while (true)
            {
                string login = Console.ReadLine();
                bool flag = false;
                for (int i = 0; i < login.Length; i++)
                {
                    if (Char.GetUnicodeCategory(login[i]) != UnicodeCategory.LowercaseLetter && Char.GetUnicodeCategory(login[i]) != UnicodeCategory.DecimalDigitNumber && Char.GetUnicodeCategory(login[i]) != UnicodeCategory.UppercaseLetter)
                        flag = true;
                }
                if (login.Length > 10 || login.Length < 2)
                    Console.WriteLine("Wrong length.");
                else if (flag)
                    Console.WriteLine("Login must contain only numbers and letters");
                else if (Char.GetUnicodeCategory(login[0]) == UnicodeCategory.DecimalDigitNumber)
                    Console.WriteLine("Login cannot start with a number.");
                else
                {
                    Console.WriteLine("Correct login");
                    break;
                }
            }
            
            
            Console.Clear();
            Console.WriteLine(@"б) С использованием регулярных выражений.");
            Regex loginPattern = new Regex("^[a-zA-Z][0-9a-zA-z]{2,7}$");
            Console.WriteLine("Введите логин:");
            while (true)
            {
                string login2 = Console.ReadLine();
                if (loginPattern.IsMatch(login2))
                {
                    Console.WriteLine("Correct login");
                    break;
                }
                else
                    Console.WriteLine("Incorrect login. Try again");
            }
        }
    }
}