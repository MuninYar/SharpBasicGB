using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] oddPositiveNumbers = new int[] {};
            int sum = 0;
            int currentNumber;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out currentNumber))
                    if (currentNumber % 2 != 0 && currentNumber > 0)
                    {
                        sum += currentNumber;
                        Array.Resize(ref oddPositiveNumbers, oddPositiveNumbers.Length + 1);
                        oddPositiveNumbers[oddPositiveNumbers.Length - 1] = currentNumber;
                    }
                    else if (currentNumber == 0)
                    {
                        Console.WriteLine($"Sum of all odd positive numbers = {sum}");
                        Console.Write("Odd positive numbers: ");
                        for (int i = 0; i < oddPositiveNumbers.Length; i++)
                        {
                            Console.Write($"{oddPositiveNumbers[i]} ");
                        }
                        Console.ReadLine();
                        break;
                    }
            }

        }
    }
}
