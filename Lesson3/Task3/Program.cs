using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yar.Learning;

namespace Task3
{
    class Fraction
    {
        #region Fields
        /// <summary>
        /// Numerator of a fraction
        /// </summary>
        int _num;
        /// <summary>
        /// Denominator of a fraction
        /// </summary>
        int _den;
        #endregion
        #region Properties
        public int Num
        {
            get { return _num; }
            set { _num = value; }
        }
        public int Den
        {
            get { return _den; }
            set
            {
                if (value == 0)
                    throw new Exception("DevideByZeroExeption");
                else
                    _den = value;
            }
        }
        public double DecimalFraction
        {
            get { return (double)_num / _den; }
        }
        #endregion
        #region Constructors
        public Fraction() { }
        public Fraction(int num, int den)
        {
            this.Den = den;
            this.Num = num;

        }
        #endregion
        #region Public Methods
        public override string ToString()
        {
            return $"{_num}|{_den}";
        }
        /// <summary>
        /// Calculates Greatest Common Divider
        /// </summary>
        /// <param name="a">First argument</param>
        /// <param name="b">Second argument</param>
        /// <returns></returns>
        public static int FindGCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != b)
            {
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            }
            return a;
        }
        /// <summary>
        /// Calculates Least Common Multiple
        /// </summary>
        /// <param name="a">First argument</param>
        /// <param name="b">Second argument</param>
        /// <returns></returns>
        public static int FindLCM(int a, int b)
        {
            return (a * b) / FindGCD(a, b);
        }
        public static Fraction ReduceFraction(Fraction fractionToReduce)
        {
            int GCD = FindGCD(fractionToReduce.Num, fractionToReduce.Den);
            return new Fraction(fractionToReduce.Num / GCD, fractionToReduce.Den / GCD);
        }
        public static void ReductionToCommonDenominator(Fraction fraction1, Fraction fraction2)
        {
            int LCM;
            if (fraction1.Den == fraction2.Den)
                return;
            else
            {
                LCM = FindLCM(fraction1.Den, fraction2.Den);
                fraction1.Num = fraction1.Num * (LCM / fraction1.Den);
                fraction2.Num = fraction2.Num * (LCM / fraction2.Den);
                fraction1.Den = fraction1.Den * (LCM / fraction1.Den);
                fraction2.Den = fraction2.Den * (LCM / fraction2.Den);
            }
        }
        #endregion
        #region Operator Overload
        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            ReductionToCommonDenominator(fraction1, fraction2);
            Fraction result = new Fraction(fraction1.Num + fraction2.Num, fraction1.Den);
            return ReduceFraction(result);
        }
        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            ReductionToCommonDenominator(fraction1, fraction2);
            Fraction result = new Fraction(fraction1.Num - fraction2.Num, fraction1.Den);
            return ReduceFraction(result);
        }
        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            Fraction result = new Fraction(fraction1.Num * fraction2.Num, fraction1.Den * fraction2.Den);
            return ReduceFraction(result);
        }
        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            Fraction result = new Fraction(fraction1.Num * fraction2.Den, fraction1.Den * fraction2.Num);
            return ReduceFraction(result);
        }
        #endregion
    }
    internal class Program
    {
        public static Fraction CreateNewFraction()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Creating fraction!");
                Console.Write("Enter a numerator: ");
                if (int.TryParse(Console.ReadLine(), out int userNum))
                {
                    Console.Clear();
                    Console.WriteLine("Creating fraction!");
                    Console.Write("Enter denominator: ");
                    if (int.TryParse(Console.ReadLine(), out int userDen))
                        return new Fraction(userNum, userDen);
                }
            }
        }
        public static string[] userOptions = new string[]
        {
            "Change fraction",
            "Reduce fraction",
            "Add another fraction",
            "Subtract another fraction",
            "Multiply by another fraction",
            "Divide by another fraction",
            "Represent as a decimal"
        };
        static void Main(string[] args)
        {
            Fraction userFraction = new Fraction();
            Fraction fractionToOperate = new Fraction();
            OutputSamples.PrintHead(3);
            Console.ReadKey();
            Console.WriteLine("Let's create a new fraction to operate with! Press any key...");
            Console.ReadKey();
            Console.Clear();
            userFraction = CreateNewFraction();
            Console.Clear();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Your fraction is {userFraction}");
                Console.WriteLine("Choose what to do with your fraction...");
                OutputSamples.PrintMenu(userOptions.Length, userOptions);
                int userInput;
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch (userInput)
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine("End of program...");
                            return;
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Let's create a new fraction to operate with! Press any key...");
                            Console.ReadKey();
                            Console.Clear();
                            userFraction = CreateNewFraction();
                            OutputSamples.BackToMenu();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine($"Your {userFraction} equals to {Fraction.ReduceFraction(userFraction)}");
                            userFraction = Fraction.ReduceFraction(userFraction);
                            OutputSamples.BackToMenu();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Let's create fraction to sum");
                            Console.ReadKey();
                            fractionToOperate = CreateNewFraction();
                            Console.WriteLine($"{userFraction} + {fractionToOperate} = {userFraction + fractionToOperate}");
                            userFraction += fractionToOperate;
                            OutputSamples.BackToMenu();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Let's create fraction to subtract");
                            Console.ReadKey();
                            fractionToOperate = CreateNewFraction();
                            Console.WriteLine($"{userFraction} - {fractionToOperate} = {userFraction - fractionToOperate}");
                            userFraction -= fractionToOperate;
                            OutputSamples.BackToMenu();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Let's create fraction to multiply by");
                            Console.ReadKey();
                            fractionToOperate = CreateNewFraction();
                            Console.WriteLine($"{userFraction} * {fractionToOperate} = {userFraction * fractionToOperate}");
                            userFraction *= fractionToOperate;
                            OutputSamples.BackToMenu();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Let's create fraction to divide by");
                            Console.ReadKey();
                            fractionToOperate = CreateNewFraction();
                            Console.WriteLine($"{userFraction} / {fractionToOperate} = {userFraction / fractionToOperate}");
                            userFraction /= fractionToOperate;
                            OutputSamples.BackToMenu();
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine($"{userFraction} = {userFraction.DecimalFraction}");
                            OutputSamples.BackToMenu();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Back to menu..");
                    Console.ReadKey();
                }
            }
        }
    }
}
