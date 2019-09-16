using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_for_Student_Objects
{
    class Logger
    {
        //a constant is static by default therefore use of static redunant before the word const. 
        const string DefaultSystemName = "SchoolTracker";

        public static void Log(string msg, string system = DefaultSystemName, int priority = 1)
        {
            //This is the original before used string interpolation
            //Console.WriteLine("System: {0}, Priority: {1}, Msg: {2}", system, priority, msg);
            //This is string interprolation.
            Console.WriteLine($"System: {system}, Priority: {priority}, Msg: {msg}");
        }
    }
}
