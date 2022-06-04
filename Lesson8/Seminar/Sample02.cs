using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Seminar
{

    public class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Second { get; set; }
        public int Age { get; set; }
    }

    internal class Sample02
    {

        public static Person LoadPersonFromXml(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            Person person = (Person)xmlSerializer.Deserialize(fileStream);
            fileStream.Close();
            return person;
        }

        public static void SavePersonToXml(string fileName, Person person)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fileStream, person);
            fileStream.Close();
        }

        static void Main(string[] args)
        {
            Person person = LoadPersonFromXml(AppDomain.CurrentDomain.BaseDirectory + "Person.xml");
            if (person != null)
            {
                Console.WriteLine($"{person.LastName} {person.FirstName} {person.Second} {person.Age}");
            }

            person.LastName = "Иванов";

            SavePersonToXml(AppDomain.CurrentDomain.BaseDirectory + "Person.new.xml", person);

            person = LoadPersonFromXml(AppDomain.CurrentDomain.BaseDirectory + "Person.new.xml");
            if (person != null)
            {
                Console.WriteLine($"{person.LastName} {person.FirstName} {person.Second} {person.Age}");
            }

            Console.ReadLine();
        }

    }
}
