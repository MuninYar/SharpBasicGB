using System;
using System.CodeDom;
using System.IO;
using Yar.Learning;
using static System.Console;

namespace Task5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Empty object
            TwoDimensionalArray twoDimEmpty = new TwoDimensionalArray();
            
            //Object with random values
            TwoDimensionalArray twoDimRandom = new TwoDimensionalArray(5, 5, 10, 50);
            
            //Object from two dimensional array
            int[,] twoDimArr = new int[,] { { 1, 2, 3, 4, 5 }, { 1, 2, 3, 4, 5 } };
            TwoDimensionalArray twoDimFromArray = new TwoDimensionalArray(twoDimArr);
            
            //Object from file
            TwoDimensionalArray twoDimFromFile = new TwoDimensionalArray(AppDomain.CurrentDomain.BaseDirectory + "Input.txt", 2);

            //Prints object elements via tabulation
            TwoDimensionalArray.PrintTwoDimArr(twoDimRandom);
            
            //Object length - property
            Write("Length:");
            WriteLine(twoDimRandom.Length);
            
            //Gets length of object dimension
            Write("Length of 0 dimension: ");
            WriteLine(twoDimRandom.GetLength(0));
            
            //Gets min element value
            Write("Min element value: ");
            WriteLine(twoDimRandom.MinElement);
            
            //Gets max element value
            Write("Max element value: ");
            WriteLine(twoDimRandom.MaxElement);
            
            //Sums all elements - property
            Write("Sum of all elements: ");
            WriteLine(twoDimRandom.SumAllElements());
            
            //Sums all elements which value is greater than border - property
            Write("Sum of all elements greater than 45: ");
            WriteLine(twoDimRandom.SumAllElementsGreaterThan(45));
            
            //Creates txt file with values of the object
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Output.txt";
            twoDimRandom.CreateFile(filePath);
            
            //Initializes coordinates of element with max value
            TwoDimensionalArray.CoordinatesOfMaxElement(twoDimRandom,out int x, out int y);
            WriteLine($"Max element at: {x},{y}");
        }
    }
}