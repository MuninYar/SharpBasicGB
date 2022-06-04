using System;
using System.Reflection;

namespace Task1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            FieldInfo[] fieldInfos = typeof(DateTime).GetFields();
            Type typ = typeof(DateTime);
            Console.WriteLine("Public:");
            foreach (var field in fieldInfos)
            {
                Console.WriteLine($"Field Name: {field}");
            }
            Console.WriteLine();
            
            FieldInfo [] type = typeof(DateTime).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("Private: ");
            foreach (var field in type)
            {
                Console.WriteLine($"Field Name: {field}");
            }
        }
    }
}