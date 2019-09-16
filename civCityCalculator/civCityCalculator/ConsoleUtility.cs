using System;
using System.Collections.Generic;
using System.Text;

namespace civCityCalculator
{
    class ConsoleUtility
    {
        static public string Ask(string question)
        {
            Console.Write(question);
            return System.Console.ReadLine();
        }
    }
}
