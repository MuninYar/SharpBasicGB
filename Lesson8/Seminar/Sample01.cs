using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Seminar
{

    public class Sample
    {
        public int Param { get; set; }

        public void Run(int a)
        {
            Console.WriteLine($"Run {a} ...");
        }
    }

    internal class Sample01
    {
        static void Main(string[] args)
        {
            // typeof
            // GetType

            Sample sample1 = new Sample();
            sample1.Param = 10;

            Sample sample2 = new Sample();
            sample2.Param = 20;

            Type type1 = typeof(Sample);
            Type type2 = sample1.GetType();

            PropertyInfo propertyInfo = type1.GetProperty("Param");
            if (propertyInfo.CanRead)
            {
                int paramValue = (int)propertyInfo.GetValue(sample2);
                Console.WriteLine($"value -> {paramValue}");
            }

            MethodInfo methodInfo = 
                type2.GetMethods().FirstOrDefault( method => method.Name == "Run");
            methodInfo.Invoke(sample1, new object[] { 100 });

            if (propertyInfo.CanWrite)
            {
                propertyInfo.SetValue(sample2, 50);
            }

            if (propertyInfo.CanRead)
            {
                int paramValue = (int)propertyInfo.GetValue(sample2);
                Console.WriteLine($"value -> {paramValue}");
            }

            Console.ReadLine();

        }
    }
}
