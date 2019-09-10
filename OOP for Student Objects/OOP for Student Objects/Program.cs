using System;
using System.Collections.Generic;


namespace OOP_for_Student_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();

            var adding = true;

            while (adding)
            {
                var newStudent = new Student();

                Console.Write("Student Name: ");
                newStudent.Name = (Console.ReadLine());

                Console.Write("Student Grade: ");
                newStudent.Grade = (int.Parse(Console.ReadLine()));

                Console.Write("Student Birthday: ");
                newStudent.Birthday = (Console.ReadLine());

                Console.Write("Student Address: ");
                newStudent.Address = (Console.ReadLine());

                Console.Write("Student Phone: ");
                newStudent.Phone = (int.Parse(Console.ReadLine()));
                
                Console.WriteLine("Add another? y/n");

                students.Add(newStudent);

                if (Console.ReadLine() != "y")
                    adding = false;
            }

            foreach (var student in students)
            {
                Console.WriteLine("Name: {0}, Grade: {1}, Birthday: {2}, Address: {3}, Phone: {4}", student.Name, student.Grade, student.Birthday, student.Address, student.Phone);
            }

            Console.ReadLine();
        }
    }

    class Student
    {
        public string Name;
        public int Grade;
        public string Birthday;
        public string Address;
        public int Phone;
    }
}
