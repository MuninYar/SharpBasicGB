using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yar.Learning;

namespace Lesson_2
{
    internal class Program
    {
        public static string[] taskConditions = new string[]
        {
            "Return the smallest number",
            "Count the number of digits in the variable",
            "Sum of all odd positive numbers",
            "Login & Password",
            "Calculate BMI",
            "Count 'good' numbers in 1000000000",
            "Develop a recursive method to print numbers from a to b, and another method to sum them" 
        };
        static void Main(string[] args)
        {
            while (true)
            {
                OutputSamples.PrintHead(2);
                OutputSamples.PrintMenu(7,taskConditions);
                Console.WriteLine("Choose a task...");
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    default:
                        Console.WriteLine("Unnown command! Back to menu ...");
                        OutputSamples.BackToMenu();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("End of program...");
                        return;
                    case 1:
                        Console.Clear();
                        Task1();
                        OutputSamples.BackToMenu();
                        break;
                    case 2:
                        Console.Clear();
                        Task2();
                        OutputSamples.BackToMenu();
                        break;
                    case 3:
                        Console.Clear();
                        Task3();
                        OutputSamples.BackToMenu();
                        break;
                    case 4:
                        Console.Clear();
                        Task4();
                        OutputSamples.BackToMenu();
                        break;
                    case 5:
                        Console.Clear();
                        Task5();
                        OutputSamples.BackToMenu();
                        break;
                    case 6:
                        Console.Clear();
                        Task6();
                        OutputSamples.BackToMenu();
                        break;
                    case 7:
                        Console.Clear();
                        Task7();
                        OutputSamples.BackToMenu();
                        break;
                } 
            }
        }
        static void Task1()
        {
            OutputSamples.PrintTaskCondition(taskConditions[0]);
            //Console.WriteLine("Return the smallest number");
            Console.Write("Enter first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter third number: ");
            int thirdNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Smallest number is " + ReturnSmallestNumber(firstNumber,secondNumber,thirdNumber));
        }
        static int ReturnSmallestNumber(int firstNumber, int secondNumber, int thirdNumber)
        {
            if (firstNumber <= secondNumber && firstNumber <= thirdNumber)
                return firstNumber;
            else if (secondNumber <= firstNumber && secondNumber <= thirdNumber)
                return secondNumber;
            else 
                return thirdNumber;
        }
        static void Task2()
        {
            OutputSamples.PrintTaskCondition(taskConditions[1]);
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(CountDigitsInNumber(number));
        }
        static int CountDigitsInNumber(int number)
        {
            if (number/10 == 0)
                return 1;
            else
                return CountDigitsInNumber(number/10)+1;
        }
        static void Task3()
        {
            OutputSamples.PrintTaskCondition(taskConditions[2]);
            int sum = 0;
            while (true)
            {
                Console.Write("Enter a number: ");
                int userInput = int.Parse(Console.ReadLine());
                if (userInput == 0)
                    break;
                if (userInput % 2 != 0 && userInput > 0)
                    sum += userInput;
            }
            Console.WriteLine($"Sum of all odd positive numbers = {sum}");
        }
        static void Task4()
        {
            OutputSamples.PrintTaskCondition(taskConditions[3]);
            int tryCount = 3;
            do
            {
                Console.Write("Login: ");
                string login = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                if (CheckLoginPassword(login, password))
                {
                    Console.WriteLine("Yeah, it' all right. You can pass ...");
                    return;
                }
                else
                {
                    tryCount--;
                    Console.WriteLine($"Wrong! {tryCount} try left!");
                }
            }
            while (tryCount != 0);
            Console.Clear();
            Console.WriteLine("OH NO! YOU TRIGGERED A MASSIVE EXPLOSION!");
            Console.ReadLine();
            OutputSamples.Explousion();
        }
        static bool CheckLoginPassword(string login, string password)
        {
            return login == "root" && password == "GeekBrains";
        }
        static void Task5()
        {
            OutputSamples.PrintTaskCondition(taskConditions[4]);
            Console.Write("Weight in kg: ");
            double weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Hight in cm: ");
            double hight = double.Parse(Console.ReadLine());

            double BMI = CalculateBMI(weight,hight);
            BMICompareToNormal(BMI, weight, hight);
            
        }
        static double CalculateBMI(double weight, double hight)
        {
            return (weight / Math.Pow(hight, 2)) * 10000;
        }
        static void BMICompareToNormal(double BMI,double weight, double hight)
        {
            if (BMI < 18)
            {
                Console.WriteLine($"Your BMI is {Math.Round(BMI,2)}. That's too LOW!");
                Console.WriteLine($"You need to gain {(Math.Pow(hight,2)*18/10000-weight)} kg to reach lower weight limit");
            }
            else if (BMI >25)
            {
                Console.WriteLine($"Your BMI is {Math.Round(BMI, 2)}. That's too HIGH");
                Console.WriteLine($"You need to loose {weight - (Math.Pow(hight, 2) * 25)/10000} kg to reach upper wight limit");
            }
            else
                Console.WriteLine($"Your BMI is {Math.Round(BMI, 2)}. That's just fine!");
        }
        static void Task6()
        {
            OutputSamples.PrintTaskCondition(taskConditions[5]);
            int numberToProcess = 1000000000;
            int goodNumbersCounter = 0;
            Console.WriteLine($"The number is {numberToProcess}. Press Enter to start...");
            Console.ReadLine();
            Console.WriteLine("Calculating... Please Wait...");
            DateTime startCalculationTime = DateTime.Now;
            for (int i = 1; i <= numberToProcess; i++)
            {
                if (CheckIfNumberIsGood(i))
                    goodNumbersCounter++;
            }
            DateTime finishCalculationTime = DateTime.Now;
            Console.WriteLine("Number of 'good' numbers = {0}. Calculation took {1} ...",goodNumbersCounter, finishCalculationTime - startCalculationTime);
        }
        static int SumOfDigits(int number)
        {
            if (number == 0)
                return 0;
            else
                return SumOfDigits(number / 10) + number % 10;
        }
        static bool CheckIfNumberIsGood (int numberToCheck)
        {
            return numberToCheck % SumOfDigits(numberToCheck) == 0;
        }
        static void Task7()
        {
            OutputSamples.PrintTaskCondition(taskConditions[6]);
            Console.Write("Enter first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.Write(PrintAllNumbers(firstNumber,secondNumber));
            Console.WriteLine();
            Console.WriteLine($"Sum of that numbers = {SumOfNumbers(firstNumber, secondNumber)}");
        }
        static int SumOfNumbers(int numberToSumFrom, int numberToSumTo)
        {
            if (numberToSumFrom == numberToSumTo)
                return numberToSumFrom;
            else
                return SumOfNumbers(numberToSumFrom+1, numberToSumTo)+numberToSumFrom;
        }
        static string PrintAllNumbers(int numberToPrintFrom, int numberToPrintTo)
        {
            if (numberToPrintTo-numberToPrintFrom == 0)
                return numberToPrintTo.ToString();
            else
                return $"{PrintAllNumbers(numberToPrintFrom, numberToPrintTo-1)}, {numberToPrintTo}";
        }
    }
}
