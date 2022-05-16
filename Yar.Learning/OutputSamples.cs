using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Yar.Learning
{
    public class OutputSamples
    {
        public static void PrintHead(int lessonNumber)
        {
            Console.WriteLine("=============================");
            Console.WriteLine(" C# Basics");
            Console.WriteLine(" Yaroslav Rezchikov");
            Console.WriteLine($" Lesson: {lessonNumber}");
            Console.WriteLine(" Press any key to continue...");
            Console.WriteLine("=============================");
            Console.ReadKey();
        }
        public static void PrintMenu(int userOptionNumber, string [] userOptionCondition)
        {
            Console.WriteLine("===================");
            Console.WriteLine(" MENU");
            for (int i = 0; i < userOptionNumber; i++)
                Console.WriteLine($"{i+1} -> {userOptionCondition[i]}");
            Console.WriteLine("0 -> End program... ");
            Console.WriteLine("===================");
        }
        public static void BackToMenu()
        {
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void PrintTaskCondition(string condition)
        {
            for (int i = 0; i < condition.Length + 4; i++)
                Console.Write("=");
            Console.WriteLine();
            Console.WriteLine("# " + condition + " #");
            for (int i = 0; i < condition.Length + 4; i++)
                Console.Write("=");
            Console.WriteLine();
        }
        public static void Explosion()
        {
            Console.WriteLine("___________________$$$$$$$$$$$$$");
            Console.WriteLine("_____________$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("___________$$$___$$$$$$$$$$$$$$$$___$$$");
            Console.WriteLine("_________$$$______$$$$$$$$$$$$$$______$$$");
            Console.WriteLine("_______$$$_________$$$$$$$$$$$$_________$$$");
            Console.WriteLine("______$$$____________$$$$$$$$$____________$$$");
            Console.WriteLine("_____$$$______________$$$$$$$______________$$$");
            Console.WriteLine("____$$$________________$$$$$________________$$$");
            Console.WriteLine("____$$_______________________________________$$");
            Console.WriteLine("____$$_______________________________________$$");
            Console.WriteLine("____$$$$$$$$$$$$$$$$$_________$$$$$$$$$$$$$$$$$");
            Console.WriteLine("____$$$$$$$$$$$$$$$$$$_______$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("_____$$$$$$$$$$$$$$$$$_______$$$$$$$$$$$$$$$$$");
            Console.WriteLine("______$$$$$$$$$$$$$$$_________$$$$$$$$$$$$$$$");
            Console.WriteLine("_______$$$$$$$$$$$$$___________$$$$$$$$$$$$$");
            Console.WriteLine("________$$$$$$$$$$$_____________$$$$$$$$$$$");
            Console.WriteLine("__________$$$$$$$$_______________$$$$$$$$");
            Console.WriteLine("____________$$$$$_________________$$$$$");
            Console.WriteLine("_______________$$$$$$$_______$$$$$$$");
            Console.WriteLine("___________________$$$$$$$$$$$$$");
        }
    }

    public class YarArray
    {
        /// <summary>
        /// Fills the array with random numbers
        /// </summary>
        /// <param name="array"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static int[] FillRandomArray(int[] array, int from, int to)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(from, to);
            }
            return array;
        }

        /// <summary>
        /// Outputs an array elements via tabulation
        /// </summary>
        /// <param name="array"></param>
        public static void PrintArray(int [] array)
        {
            foreach (var e in array)
            {
                Console.Write($"{e}\t");
            }
        }
    }
    public class MyArray
    {
        #region Fields
        private  int[] _array;
        #endregion
        
        #region Properties
        
        /// <summary>
        /// Index property
        /// </summary>
        /// <param name="index"></param>
        public int this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }
        
        /// <summary>
        /// Returns a sum of all elements 
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = 0;
                foreach (var t in _array)
                {
                    sum += t;
                }
                return sum;
            }
        }
        
        /// <summary>
        /// Returns a number of all elements with max value
        /// </summary>
        public int MaxCount
        {
            get
            {
                return CountMax(_array, FindMax(_array));
            }
        }
        
        /// <summary>
        /// Returns a length of the object
        /// </summary>
        public int Length
        {
            get
            {
                return _array.Length;
            }
        }
        
        #endregion

        #region Constructors
        
        /// <summary>
        /// Creates an object from an array
        /// </summary>
        /// <param name="array"></param>
        public MyArray(int[] array)
        {
            this._array = new int [array.Length];
            Array.Copy(array, this._array, array.Length);
        }   
        
        /// <summary>
        /// Creates an object from a txt file 
        /// </summary>
        /// <param name="fileName"></param>
        public MyArray(string fileName)
        {
            this._array = LoadArrayFromFile(fileName);
        }
        
        /// <summary>
        /// Creates an object without parameters
        /// </summary>
        public MyArray(){}
        
        /// <summary>
        /// Creates an object with given parameters 
        /// </summary>
        /// <param name="length">длина объекта</param>
        /// <param name="firstValue">начальное значение</param>
        /// <param name="step">шаг</param>
        public MyArray(int length, int firstValue, int step)
        {
            this._array = CreateArrayWithStep( length,  firstValue, step);
        }
        
        #endregion

        #region Methods
        
        /// <summary>
        /// Reads an array from a txt file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static int[] LoadArrayFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                    throw new FileNotFoundException();
            int[] buffer = new int [1000];
            int lineCounter = 0;
            StreamReader streamReader = new StreamReader(fileName);
            while (!streamReader.EndOfStream)
            {
                if(int.TryParse(streamReader.ReadLine(),out int fileLine))
                {
                    buffer[lineCounter] = fileLine;
                    lineCounter++;
                }
            }
            streamReader.Close();
            int[] resultArray = new int[lineCounter];
            Array.Copy(buffer,resultArray,lineCounter);
            return resultArray;
        }

        /// <summary>
        /// Creates an object with random numbers
        /// </summary>
        /// <param name="length"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static MyArray CreateRandomNumberArray(int length,int from, int to)
        {
            Random random = new Random();
            int[] arrayBuff = new int[length];
            for (int i = 0; i < length; i++)
            {
                arrayBuff[i] = random.Next(from, to);
            }
            MyArray array = new MyArray(arrayBuff);
            return array;
        }
        
        /// <summary>
        /// Outputs an object elements via tabulation
        /// </summary>
        public void PrintMyArray()
        {
            foreach (var e in _array)
            {
                Console.Write($"{e}\t");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Returns a number of pairs of elements, one of witch is divisible by dev (Task 1)
        /// </summary>
        /// <param name="array"></param>
        /// <param name="dev"></param>
        /// <returns></returns>
        public static int Task1(MyArray array,int dev)
        {
            int counter = 0;
            if (dev == 0)
                throw new DivideByZeroException(); 
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] % dev == 0 && array[i + 1] % dev != 0 ||
                    array[i] % dev != 0 && array[i + 1] % dev == 0)
                    counter++;
            }
            return counter;
        }
        
        /// <summary>
        /// Creates an array with given parameters
        /// </summary>
        /// <param name="length"></param>
        /// <param name="firstValue"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        private int[] CreateArrayWithStep(int length, int firstValue, int step)
        {
            int[] array = new int[length];
            array[0] = firstValue;
            for (int i = 1; i < array.Length; i++)
            {
                array[i] = array[i - 1] + step;
            }

            return array;
        }
        
        /// <summary>
        /// Creates an object with inversed values
        /// </summary>
        /// <returns></returns>
        public static MyArray Inverse(MyArray array)
        {
            int[] newArray = new int [array.Length];
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = array[i] * -1;
            }
            return new MyArray(newArray);
        }
        
        /// <summary>
        /// Multiplies all elements of an object by multiplier
        /// </summary>
        /// <param name="multiplier"></param>
        public void Multi(int multiplier)
            {
                for (int i = 0; i < _array.Length; i++)
                {
                    _array[i] *= multiplier;
                }
            }
        
        /// <summary>
        /// Finds an element with max value in the array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int FindMax(int[] array)
        {
            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        }
        
        /// <summary>
        /// Returns a number of elements with max values in the array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int CountMax(int [] array, int max)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == max)
                    counter++;
            }
            return counter;
        }

        /// <summary>
        /// Shows a number of Occurrences for each element in the object
        /// </summary>
        /// <param name="array"></param>
        public static void NumberOfOccurrences(MyArray array)
        {
            Array.Sort(array._array);
            var dict = new Dictionary<int, int>();
            foreach (var a in array._array)
            {
                int elementCounter = 0;
                foreach (var b in array._array)
                {
                    if (a == b)
                        elementCounter++;
                }
                dict[a] = elementCounter;
            }
            foreach (var e in dict)
            {
                Console.WriteLine($"Number of occurrences for {e.Key} = {e.Value}");
            }
        }
        #endregion
    }
    public class TwoDimensionalArray
    {
        private int[,] _twoDimArr;
        
        public int this[int index1, int index2]
        {
            get => _twoDimArr[index1, index2];
            set => _twoDimArr[index1, index2] = value;
        }
        public int Length => _twoDimArr.Length;
        public int MinElement => GetMinElement(_twoDimArr);
        public int MaxElement => GetMaxElement(_twoDimArr);


        public TwoDimensionalArray(){}
        public TwoDimensionalArray(int index1, int index2)
        {
            this._twoDimArr = new int [index1, index2];
        }
        public TwoDimensionalArray(int[,] twoDimArr)
        {
            this._twoDimArr = twoDimArr;
        }
        public TwoDimensionalArray(int dim1Length, int dim2Length, int from, int to)
        {
            this._twoDimArr = CreateTwoDimArrWithRandomValues(dim1Length, dim2Length, from, to);
        }
        public TwoDimensionalArray(string fileName, int dim1Length)
        {
            this._twoDimArr = ReadFromFile(fileName, dim1Length);
        }

        
        private int [,] CreateTwoDimArrWithRandomValues(int dim1Length, int dim2Length, int from, int to)
        {
            Random random = new Random();
            var twoDimArr = new int [dim1Length, dim2Length];
            for (int i = 0; i < dim1Length; i++)
            {
                for (int j = 0; j < dim2Length; j++)
                {
                    twoDimArr[i, j] = random.Next(from, to);
                }
            }
            return twoDimArr;
        }
        
        public int GetLength(int dimension)
        {
            return _twoDimArr.GetLength(dimension);
        }
        
        public static void PrintTwoDimArr(TwoDimensionalArray twoDimArray)
        {
            for (int i = 0; i < twoDimArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimArray.GetLength(1); j++)
                {
                    Console.Write($"{twoDimArray[i,j]}\t");
                }
                Console.WriteLine();
            } 
        }

        private int[,] ReadFromFile(string fileName, int dim1Length)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException();
            int dim2Length = TwoDimensionalArray.CountLinesInFile(fileName) / dim1Length;
            if (dim2Length < 2)
                throw new Exception($"Not enough numbers to create two dimensional array");
            int[,] twoDimArr = new int[dim1Length, dim2Length];
            StreamReader sr = new StreamReader(fileName);
            
            for (int i = 0; i < dim1Length; i++)
            {
                for (int j = 0; j < dim2Length;j++)
                {
                    if (int.TryParse(sr.ReadLine(), out int line))
                    {
                        twoDimArr[i, j] = line;
                    }
                }
            }
            sr.Close();
            return twoDimArr;
        }

        private static int CountLinesInFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            int lineCounter = 0;
            while(!sr.EndOfStream)
            {
                if (int.TryParse(sr.ReadLine(), out int line))
                    lineCounter++;
            }

            return lineCounter;
        }

        private int GetMinElement(int[,] twoDimArr)
        {
            int min = twoDimArr[0,0];
            for (int i = 0; i < twoDimArr.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimArr.GetLength(1); j++)
                {
                    if (twoDimArr[i, j] < min)
                        min = twoDimArr[i, j];
                }
            }
            return min;
        }

        private int GetMaxElement(int[,] twoDimArr)
        {
            int max = 0;
            for (int i = 0; i < twoDimArr.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimArr.GetLength(1); j++)
                {
                    if (twoDimArr[i, j] > max)
                        max = twoDimArr[i, j];
                }
            }

            return max;
        }

        public int SumAllElements()
        {
            int sum = 0;
            for (int i = 0; i < _twoDimArr.GetLength(0); i++)
            {
                for (int j = 0; j < _twoDimArr.GetLength(1); j++)
                {
                    sum += _twoDimArr[i, j];
                }
            }

            return sum;
        }

        public int SumAllElementsGreaterThan(int border)
        {
            int sum = 0;
            for (int i = 0; i < _twoDimArr.GetLength(0); i++)
            {
                for (int j = 0; j < _twoDimArr.GetLength(1); j++)
                {
                    if (_twoDimArr[i,j]>border)
                        sum += _twoDimArr[i, j];
                }
            }
            return sum;
        }

        public void CreateFile(string filePath)
        {
            FileStream fs = File.Create(filePath);
            fs.Close();
            StreamWriter sw = new StreamWriter(filePath);
            for (int i = 0; i < _twoDimArr.GetLength(0); i++)
            {
                for (int j = 0; j < _twoDimArr.GetLength(1); j++)
                {
                    sw.Write($"{_twoDimArr[i,j]}\t");
                }
                sw.WriteLine();
            }
            sw.Close();
        }

        public static void CoordinatesOfMaxElement(TwoDimensionalArray twoDimArr,out int x, out int y)
        {
            int max = 0;
            int xMax = 0; int yMax =0;
            for (int i = 0; i < twoDimArr.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimArr.GetLength(1); j++)
                {
                    if (twoDimArr[i, j] > max)
                    {
                        max = twoDimArr[i, j]; 
                        xMax = i;
                        yMax = j;
                    }
                }
            }
            x = xMax;
            y = yMax;
        }
        
    }
}
