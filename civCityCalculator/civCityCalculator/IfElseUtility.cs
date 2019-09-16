using System;
using System.Collections.Generic;
using System.Text;

namespace civCityCalculator
{
    class IfElseUtility
    {
        public static bool statistic { get; private set; }

        public static (string, int, bool) IfElseUtilityMethod(ref string boolyish, ref int decreaseInNationalPMInfluence, ref bool stat)
        {
            bool NoOrInvalidInput = true;
            while (NoOrInvalidInput)
            {
                if (boolyish != "y" && boolyish != "n")
                {
                    Console.WriteLine("Input invalid, please try again:");
                    boolyish = Console.ReadLine();
                }
                else if (boolyish == "y")
                {
                    Program.DecreasePMInfluence(1, ref decreaseInNationalPMInfluence);
                    Console.WriteLine("(1)The PM's influence has been decreased by a total of: " + decreaseInNationalPMInfluence);
                    statistic = true;
                    NoOrInvalidInput = false;
                    stat = statistic;
                    return (boolyish, decreaseInNationalPMInfluence, stat);
                }
                else
                {
                    Console.WriteLine("Responded No.");
                    statistic = true;
                    NoOrInvalidInput = false;
                    return (boolyish, decreaseInNationalPMInfluence, stat);
                }
            }
            boolyish = "";
            return (boolyish, decreaseInNationalPMInfluence, stat);
        }
    }
}
