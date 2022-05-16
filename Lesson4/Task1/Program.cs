using System;
using Yar.Learning;
namespace Task1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int [] randomNumberArray = new int[20];
            YarArray.FillRandomArray(randomNumberArray, -10000, 10000);
            int counter = 0;
            for (int i = 0; i < randomNumberArray.Length - 1; i++)
            {
                if (randomNumberArray[i] % 3 == 0 && randomNumberArray[i + 1] % 3 != 0 ||
                    randomNumberArray[i] % 3 != 0 && randomNumberArray[i + 1] % 3 == 0)
                    counter++;
            }
            YarArray.PrintArray(randomNumberArray);
            Console.WriteLine();
            Console.WriteLine($"Количество пар - {counter}");
        }
    }
}