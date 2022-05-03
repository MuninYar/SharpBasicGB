using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yar.Learning;

namespace ComplexNumbersClass
{
    class ComplexNumbers
    {
        #region Fields
        /// <summary>
        /// Real part of the comlex number
        /// </summary>
        double _re;
        /// <summary>
        /// Imaginary part of the complex number
        /// </summary>
        double _im;
        #endregion
        #region Properties
        public double Re
        {
            get { return _re; }
            set { _re = value; }
        }
        public double Im
        {
            get { return _im; }
            set { _im = value; }
        } 
        #endregion
        #region Constructors
        public ComplexNumbers() { }
        public ComplexNumbers(double re, double im)
        {
            this._re = re;
            this._im = im;
        }
        #endregion
        #region Public Methods
        public override string ToString()
        {
            return $"{_re} + {_im}i";
        }
        public static ComplexNumbers GetConjugate(ComplexNumbers complex1)
        {
            return new ComplexNumbers { Re = complex1.Re, Im = complex1.Im * -1 };
        }
        public static ComplexNumbers operator +(ComplexNumbers complex1, ComplexNumbers complex2)
        {
            return new ComplexNumbers { Re = complex1.Re + complex2.Re, Im = complex1.Im + complex2.Im };
        }
        public static ComplexNumbers operator -(ComplexNumbers complex1, ComplexNumbers complex2)
        {
            return new ComplexNumbers { Re = complex1.Re - complex2.Re, Im = complex1.Im - complex2.Im };
        }
        public static ComplexNumbers operator *(ComplexNumbers complex1, ComplexNumbers complex2)
        {
            return new ComplexNumbers
            {
                Re = (complex1.Re * complex2.Re) + ((complex1.Im * complex2.Im) * -1),
                Im = (complex1.Re * complex2.Im) + ((complex1.Im * complex2.Re))
            };
        }
        public static ComplexNumbers operator /(ComplexNumbers complex1, ComplexNumbers complex2)
        {
            if (complex2.Re == 0 && complex2.Im == 0)
                throw new Exception("DevideByZeroExeption");
            else if( complex2.Im == 0)
            {
                return new ComplexNumbers(complex1.Re / complex2.Re, complex1.Im / complex2.Re);
            }    
            return new ComplexNumbers
            {
                Re = ((complex1.Re * complex2.Re) + (complex1.Im * complex2.Im)) / (Math.Pow(complex2.Re, 2) + Math.Pow(complex2.Im, 2)),
                Im = ((complex1.Im * complex2.Re) - (complex1.Re * complex2.Im)) / (Math.Pow(complex2.Re, 2) + Math.Pow(complex2.Im, 2))
            };
        } 
        #endregion

    }
    internal class Program
    {
        public static ComplexNumbers CreateNewComplexNumber()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Creating your complex number!");
                Console.Write("Enter a real part: ");
                if (double.TryParse(Console.ReadLine(), out double userRe))
                {
                    Console.Clear();
                    Console.WriteLine("Creating your complex number!");
                    Console.Write("Enter imaginary part: ");
                    if (double.TryParse(Console.ReadLine(), out double userIm))
                        return new ComplexNumbers(userRe, userIm);
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
        static void Main(string[] args)
        {
            ComplexNumbers complexNumberToOperate = new ComplexNumbers();
            ComplexNumbers userComplexNumber = new ComplexNumbers();
            OutputSamples.PrintHead(3);
            Console.ReadKey();
            Console.WriteLine("Let's create a new complex number to operate with! Press any key...");
            Console.ReadKey();
            Console.Clear();
            userComplexNumber = CreateNewComplexNumber();
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
                            Console.WriteLine($"Conjugate complex number to {userComplexNumber} is {ComplexNumbers.GetConjugate(userComplexNumber)}");
                            OutputSamples.BackToMenu();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Let's create complex number to sum");
                            Console.ReadKey();
                            complexNumberToOperate = CreateNewComplexNumber();
                            Console.WriteLine($"{userComplexNumber} + {complexNumberToOperate} = {userComplexNumber + complexNumberToOperate}");
                            OutputSamples.BackToMenu();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Let's create complex number to subtract");
                            Console.ReadKey();
                            complexNumberToOperate = CreateNewComplexNumber();
                            Console.WriteLine($"{userComplexNumber} - {complexNumberToOperate} = {userComplexNumber - complexNumberToOperate}");
                            OutputSamples.BackToMenu();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Let's create complex number to multiply by");
                            Console.ReadKey();
                            complexNumberToOperate = CreateNewComplexNumber();
                            Console.WriteLine($"{userComplexNumber} * {complexNumberToOperate} = {userComplexNumber * complexNumberToOperate}");
                            OutputSamples.BackToMenu();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Let's create complex number to divide by");
                            Console.ReadKey();
                            complexNumberToOperate = CreateNewComplexNumber();
                            try
                            {
                                Console.WriteLine($"{userComplexNumber} / {complexNumberToOperate} = {userComplexNumber / complexNumberToOperate}");
                            }
                            catch (Exception ex)
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
