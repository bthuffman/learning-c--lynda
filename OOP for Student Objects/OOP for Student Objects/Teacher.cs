using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_for_Student_Objects
{
    class Teacher : Member, IPayee
    {
        public string Subject;

        public void Pay()
        {
            Console.WriteLine("Paying teacher");
        }
    }
}
