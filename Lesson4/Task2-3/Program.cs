using System;
using System.Collections.Generic;
using System.IO;
using Yar.Learning;
using static System.Console;

namespace Task2_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            OutputSamples.PrintHead(4);
            WriteLine("Продемонстрировать работу библиотеки с классом MyArray");
            
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine("1. Creating object from an array...");
            ResetColor();
            MyArray fromArray = new MyArray(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            fromArray.PrintMyArray();
            ReadKey();
            
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine("2. Creating object from Input.txt. Feel free to change it, or it's name...");
            ResetColor();
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "Input.txt";
            bool flagForFile = true;
            try
            {
                MyArray catcher = new MyArray(fileName);
            }
            catch (Exception e)
            {
                WriteLine("File Not Found");
                flagForFile = false;
            }
            if (flagForFile)
            {
                MyArray fromInput = new MyArray(fileName);
                fromInput.PrintMyArray();
            }
            ReadKey();
            
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine("3. Creating an object with given parameters...");
            ResetColor();
            ReadKey();
            
            WriteLine("This will require:");
            WriteLine("Length (natural positive number, not zero): ");
            int length = UserInputNaturalPositiveNotZero();
            WriteLine("First value for an object: ");
            int firstValue = UserInputNatural();
            WriteLine("And a step: ");
            int step = UserInputNatural();
            WriteLine("Final object:");
            MyArray fromGivenValues = new MyArray(length, firstValue, step);
            fromGivenValues.PrintMyArray();
            ReadKey();
            
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine("4. Now let's create one with random values...");
            ResetColor();
            WriteLine("Length (natural, positive, not zero): ");
            length = UserInputNaturalPositiveNotZero();
            WriteLine("Range start: ");
            int from = UserInputNatural();
            WriteLine("And an end of range: ");
            int to = UserInputNatural();
            MyArray randomValues = new MyArray();
            randomValues = MyArray.CreateRandomNumberArray(length, from, to);
            WriteLine("Final object: ");
            randomValues.PrintMyArray();
            ReadKey();

            ForegroundColor = ConsoleColor.DarkGreen;
            Write("5. Now for a randomValue object, let's count all pairs one of the elements in witch is divisible by 3 (Task1): ");
            ResetColor();
            WriteLine(MyArray.Task1(randomValues,3));
            ReadKey();
            
            ForegroundColor = ConsoleColor.DarkGreen;
            Write("6. Sum of all elements: ");
            ResetColor();
            WriteLine(randomValues.Sum);
            ReadKey();
            
            ForegroundColor = ConsoleColor.DarkGreen;
            Write("7. Number of elements with max value: ");
            ResetColor();
            WriteLine(randomValues.MaxCount);
            ReadKey();
            
            ForegroundColor = ConsoleColor.DarkGreen;
            Write("8. Now, let's multiply all elements by ... ");
            ResetColor();
            int multiplier = UserInputNatural();
            randomValues.Multi(multiplier);
            randomValues.PrintMyArray();
            ReadKey();
            
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine("9. Inverted: ");
            ResetColor();
            MyArray inversedRandom = MyArray.Inverse(randomValues);
            inversedRandom.PrintMyArray();
            ReadKey();
            
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine("10. Number of occurrences for each element in random array object: ");
            ResetColor();
            MyArray.NumberOfOccurrences(randomValues);
            ReadKey();
        }

        private static int UserInputNaturalPositiveNotZero()
        {
            while (true)
            {
                if (!(int.TryParse(ReadLine(), out int userInput) && (userInput != 0) && (userInput > 0)))
                {
                    WriteLine("Incorrect Input! Try again...");
                    continue;
                }
                return userInput;
            }
        }
        private static int UserInputNatural()
        {
            while (true)
            {
                if (!(int.TryParse(ReadLine(), out int userInput)))
                {
                    WriteLine("Incorrect Input. Try again.");
                    continue;
                }
                return userInput;
            }
        }
    }
}