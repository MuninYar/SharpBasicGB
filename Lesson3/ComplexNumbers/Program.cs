using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yar.Learning;

namespace ComplexNumbers
{
    struct Complex
    {
        public double Re;
        public double Im;
        public override string ToString()
        {
            return $"{Re} + {Im}i";
        }
        /// <summary>
        /// Creates a complex number
        /// </summary>
        /// <param name="re">Real part of the complex number</param>
        /// <param name="im">Imaginary part of the complex number</param>
        /// <returns></returns>
        public static Complex GetComplexNumber(double re, double im)
        {
            Complex complexNumber;
            complexNumber.Re = re;
            complexNumber.Im = im;
            return complexNumber;
        }
        /// <summary>
        /// Creates a complex conjugate number
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Complex GetConjugate(Complex x)
        {
            Complex conjugateNumber;
            conjugateNumber.Re = x.Re;
            conjugateNumber.Im = x.Im * -1;
            return conjugateNumber;
        }
        /// <summary>
        /// Sum of complex numbers
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Complex Sum(Complex x)
        {
            Complex sumResult;
            sumResult.Re = x.Re + Re;
            sumResult.Im = x.Im + Im;
            return sumResult;
        }
        /// <summary>
        /// Subtraction of complex numbers
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Complex Sub(Complex x)
        {
            Complex subResult;
            subResult.Re = Re - x.Re;
            subResult.Im = Im - x.Im;
            return subResult;
        }
        /// <summary>
        /// Multiplication of complex numbers
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Complex Mult(Complex x)
        {
            Complex multResult;
            multResult.Re = (Re * x.Re) + ((Im * x.Im) * -1);
            multResult.Im = (Re * x.Im) + (Im * x.Re);
            return multResult;
        }
        /// <summary>
        /// Division of complex numbers
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Complex Div(Complex x)
        {
            Complex devResult;
            if (x.Re == 0 && x.Im == 0)
                throw new Exception("DevideByZeroExeption");
            else if(x.Im == 0)
            {
                devResult.Re = Re / x.Re;
                devResult.Im = Im / x.Re;
                return devResult;
            }
            else
            {
            devResult.Re = ((Re * x.Re) + (Im * x.Im)) / (Math.Pow(x.Re, 2) + Math.Pow(x.Im, 2));
            devResult.Im = ((Im * x.Re) - (Re * x.Im)) / (Math.Pow(x.Re, 2) + Math.Pow(x.Im, 2));
            return devResult;
            }
        }
    }
    internal class Program
    {
        public static Complex CreateNewComplexNumber()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Creating your complex number!");
                Console.Write("Enter a real part: ");
                if(double.TryParse(Console.ReadLine(), out double userRe))
                {
                    Console.Clear();
                    Console.WriteLine("Creating your complex number!");
                    Console.Write("Enter imaginary part: ");
                    if (double.TryParse(Console.ReadLine(), out double userIm))
                        return Complex.GetComplexNumber(userRe, userIm);
                }
            }
        }
        public static string[] userOptions = new string[]
        {
            "Change complex number",
            "Get conjugate complex number",
            "Add another complex number",
            "Subtract another complex number",
            "Multiply by another complex number",
            "Divide by another complex number",
        };
        public static void Main(string[] args)
        {
            Complex complexNumberToOperate;
            OutputSamples.PrintHead(3);
            Console.ReadKey();
            Console.WriteLine("Let's create a new complex number to operate with! Press any key...");
            Console.ReadKey();
            Console.Clear();
            Complex userComplexNumber = CreateNewComplexNumber();
            Console.Clear();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Your complex number is {userComplexNumber}");
                Console.WriteLine("Choose what to do with your number...");
                OutputSamples.PrintMenu(6, userOptions);
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
                            Console.WriteLine("Let's create a new complex number to operate with! Press any key...");
                            Console.ReadKey();
                            Console.Clear();
                            userComplexNumber = CreateNewComplexNumber();
                            OutputSamples.BackToMenu();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine($"Conjugate complex number to {userComplexNumber} is {Complex.GetConjugate(userComplexNumber)}");
                            OutputSamples.BackToMenu();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Let's create complex number to sum");
                            Console.ReadKey();
                            complexNumberToOperate = CreateNewComplexNumber();
                            Console.WriteLine($"{userComplexNumber} + {complexNumberToOperate} = {userComplexNumber.Sum(complexNumberToOperate)}");
                            OutputSamples.BackToMenu();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Let's create complex number to subtract");
                            Console.ReadKey();
                            complexNumberToOperate = CreateNewComplexNumber();
                            Console.WriteLine($"{userComplexNumber} - {complexNumberToOperate} = {userComplexNumber.Sub(complexNumberToOperate)}");
                            OutputSamples.BackToMenu();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Let's create complex number to multiply by");
                            Console.ReadKey();
                            complexNumberToOperate = CreateNewComplexNumber();
                            Console.WriteLine($"{userComplexNumber} * {complexNumberToOperate} = {userComplexNumber.Mult(complexNumberToOperate)}");
                            OutputSamples.BackToMenu();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Let's create complex number to divide by");
                            Console.ReadKey();
                            complexNumberToOperate = CreateNewComplexNumber();
                            try
                            {
                            Console.WriteLine($"{userComplexNumber} / {complexNumberToOperate} = {userComplexNumber.Div(complexNumberToOperate)}");
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine("Even complex numbers can't be divided by zero!");
                            }
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
