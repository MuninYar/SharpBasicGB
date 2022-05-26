using System;
using System.Collections.Generic;
using System.IO;
class Student
{
    public string lastName;
    public string firstName;
    public string university;
    public string faculty;
    public string department;
    public int age;
    public int course;
    public int group;
    public string city;
// Создаем конструктор
    public Student(string firstName, string lastName, string university, string faculty, string department, int age,int course, int group, string city)
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.university = university;
        this.faculty = faculty;
        this.department = department;
        this.age = age;
        this.course = course;
        this.group = group;
        this.city = city;
    }
}
class Program
{
    static int MyDelegat(Student st1, Student st2)
    {
        if (st1.age > st2.age)
            return 1;
        if (st1.age == st2.age)
            return 0;
        return -1;
        //return String.Compare(st1.age.ToString(),st2.age.ToString());
    }
    static int MyDelegat2(Student st1, Student st2) 
    {
        return String.Compare(st1.course.ToString(),st2.course.ToString());
    }
    static void Main(string[] args)
    {
        int bachelor = 0;
        int masters = 0;
        int course5 = 0;
        int course6 = 0;
        List<Student> list = new List<Student>();
        StreamReader sr = new StreamReader("students.csv");
        while (!sr.EndOfStream)
        {
            try
            {
                string[] s = sr.ReadLine().Split(';');
                list.Add(new Student(s[0],s[1],s[2],s[3],s[4],int.Parse(s[5]),int.Parse(s[6]),int.Parse(s[7]),s[8]));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                if (Console.ReadKey().Key == ConsoleKey.Escape) return;
            }
        }
        sr.Close();
        
        Console.WriteLine("Всего студентов:" + list.Count);
        foreach (var student in list)
        {
            if (student.course == 5) 
                course5++;
            else if (student.course == 6)
                course6++;

            if (student.course > 5)
                masters++;
            else 
                bachelor++;
        }
        Console.WriteLine($"5 курс: {course5}, 6 курс: {course6}");
        Console.WriteLine("Магистров:{0}, Бакалавров:{1}", masters, bachelor);

        CountYoungStudents(list,6);

        Console.ReadKey();

        list.Sort(new Comparison<Student>(MyDelegat));
        Console.WriteLine("Сортировка по возрасту:");
        foreach (var stud in list)
        {
            Console.WriteLine($"{stud.age}  {stud.lastName} {stud.firstName}");
        }

        Console.WriteLine();
        list.Sort(new Comparison<Student>(MyDelegat2));
        Console.WriteLine("Сортировка по курсу и возрасту:");
        foreach (var stud in list)
        {
            Console.WriteLine($"курс: {stud.course} возраст: {stud.age}  {stud.lastName} {stud.firstName}");
        }
    }
    
    

    private static void CountYoungStudents(List<Student> list, int numberOfCourses)
    {
        Dictionary<int, int> numberOfYoungStudents = new Dictionary<int, int>();
        for (int i = 1; i <= numberOfCourses; i++)
        {
            numberOfYoungStudents.Add(i, 0);
        }

        foreach (var student in list)
        {
            if (student.age >= 18 && student.age <= 20)
                numberOfYoungStudents[student.course] += 1;
        }

        Console.WriteLine("Количество студентов 18-20 лет:");
        foreach (var pair in numberOfYoungStudents)
        {
            if (pair.Value == 0)
                continue;
            Console.Write($"{pair.Key} курс: {pair.Value}\n");
        }
    }
}

