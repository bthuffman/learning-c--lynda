using System;
using System.Collections.Generic;

namespace OOP_for_Student_Objects
{
    enum School
    {
        Hogwarts,
        Harvard,
        MIT
    }

    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            //here priority is an example of named arguements. Used because there is 
            //technically the system parameter that is to be set before it (see 
            //Logger.cs) and we don't want to confuse us trying to set the priority 
            //level with identifying the system.
            Logger.Log("Tracker started", priority: 0);
            PayRoll payroll = new PayRoll();
            payroll.PayAll();



            var adding = true;

            while (adding)
            {
                try
                {
                    Logger.Log("Adding new student");

                    var newStudent = new Student();

                    newStudent.Name = Util.Ask("Student Name: ");

                    newStudent.Grade = Util.AskInt("Student Grade: ");

                    newStudent.School = (School)Util.AskInt("School Name (type the corresponding number): \n 0: Hogwarts High \n 1: Harvard \n 2: MIT \n)");

                    newStudent.Birthday = Util.Ask("Student Birthday: ");

                    newStudent.Address = Util.Ask("Student Address: ");

                    newStudent.Phone = Util.AskInt("Student Phone Number: ");

                    students.Add(newStudent);
                    Student.Count++;
                    Console.WriteLine("Student Count: {0}", Student.Count);

                    Console.WriteLine("Add another? y/n");

                    if (Console.ReadLine() != "y")
                        adding = false;
                }
                catch (FormatException msg)
                {
                    Console.WriteLine(msg.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error adding student, Please try again");
                }
            }

            ShowGrade("Tom");

            foreach (var student in students)
            {
                Console.WriteLine("Name: {0}, Grade: {1}", student.Name, student.Grade);
            }
            Exports();
        }

        static void Import()
        {
            var importedStudent = new Student("Jenny", 86, "birthday", "address", 123456);
            Console.WriteLine(importedStudent.Name);
        }

        static void Exports()
        {
            foreach (var student in students)
            {
                switch (student.School)
                {
                    case School.Hogwarts:
                        Console.WriteLine("Exporting to Hogwarts");
                        break;
                    case School.Harvard:
                        Console.WriteLine("Exporting to Harvard");
                        break;
                    case School.MIT:
                        Console.WriteLine("Exporting to MIT");
                        break;
                }
            }
        }

        static void ShowGrade(string name)
        {
            var found = students.Find(student => student.Name == name);

            Console.WriteLine("{0}'s Grade: {1}", found.Name, found.Grade);
        }
    }

    class Member
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
    }

    class Student : Member
    {
        static public int Count { get; set; } = 0;

        public int Grade { get; set; }
        public string Birthday { get; set; }
        public School School { get; set; }

        public Student()
        {

        }

        public Student(string name, int grade, string birthday, string address, int phone)
        {
            Name = name;
            Grade = grade;
            Birthday = birthday;
            Address = address;
            Phone = phone;
        }
    }
}
