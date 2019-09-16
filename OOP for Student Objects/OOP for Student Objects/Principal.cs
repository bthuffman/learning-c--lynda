using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_for_Student_Objects
{
    class Principal : Member, IPayee
    {
        public void Pay()
        {
            Console.WriteLine("Paying principal");
        }
    }
}
