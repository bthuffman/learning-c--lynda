using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_for_Student_Objects
{
    public static class ExtensionMethods
    {
        //"This" is a keyword that points to itself. 
        public static int toInt(this string value)
        {
            return int.Parse(value);
        }
    }
    class Util
    {
        //Notice here the use of method overloading. The two Ask methods have the same names but 
        //because they take in two different parameters (more specifically in this case one string
        //and one int type) they work. You see similar functionality when using Console.Write which 
        //takes 17 different types/parameters
        static public string Ask(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }

        static public string Ask(int question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }
        static public int AskInt(string question)
        {
            try
            {
                Console.Write(question);
                //notice using the extension toInt here instead of int.Parse(Console.Readline());
                return Console.ReadLine().toInt();
            }
            catch (Exception)
            {
                throw new FormatException("Input was not a number.");
            }

        }
    }
}
