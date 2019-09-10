using System;
using System.Collections.Generic;

namespace civCityCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var decreaseInNationalPMInfluence = 0;
            var cities = new List<City>();
            var natBooly = "";
            /*
             * NATIONAL STATS
             * */

            var newNation = new Nation();
            //COMMERCE
            Console.WriteLine("How many Civs have higher levels of Commerce?");
            newNation.NumberCivsWithHigherCommerce = int.Parse(Console.ReadLine());
            decreaseNationalPMInfluence(newNation.NumberCivsWithHigherCommerce, ref decreaseInNationalPMInfluence);

            Console.WriteLine("How many unused trade routes are there?");
            newNation.NumberUnusedTradeRoutes = int.Parse(Console.ReadLine());
            decreaseNationalPMInfluence(newNation.NumberUnusedTradeRoutes, ref decreaseInNationalPMInfluence);

            Console.WriteLine("How many Civs have higher levels of Culture?");
            newNation.NumberCivsWithHigherCulture = int.Parse(Console.ReadLine());
            decreaseNationalPMInfluence(newNation.NumberCivsWithHigherCulture, ref decreaseInNationalPMInfluence);

            Console.WriteLine("How many Civs have higher levels of Tech?");
            newNation.NumberCivsWithMoreTech = int.Parse(Console.ReadLine());
            decreaseNationalPMInfluence(newNation.NumberCivsWithMoreTech, ref decreaseInNationalPMInfluence);

            Console.WriteLine("Is the country at War: y/n?");
            natBooly = Console.ReadLine();
            if (natBooly != "y" && natBooly != "n")
            {
                TryAgain();
            }
            else if (natBooly == "y")
            {
                newNation.AtWar = true;
                decreaseNationalPMInfluence(1, ref decreaseInNationalPMInfluence);
                Console.WriteLine("(1)The PM's influence has been decreased by a total of: " + decreaseInNationalPMInfluence);
            }
            else
            {
                Console.WriteLine("Error");
            }
            natBooly = "";

            Console.WriteLine("How many Civs have a bigger Military?");
            newNation.NumberCivsWithMoreTech = int.Parse(Console.ReadLine());
            decreaseNationalPMInfluence(newNation.NumberCivsWithMoreTech, ref decreaseInNationalPMInfluence);

            Console.WriteLine("How many Civs have higher levels of Production?");
            newNation.NumberCivsWithMoreTech = int.Parse(Console.ReadLine());
            decreaseNationalPMInfluence(newNation.NumberCivsWithMoreTech, ref decreaseInNationalPMInfluence);


            /*
             * SESSION OF PARLIAMENT
             * */
            Console.WriteLine("Is there a national decision for Parliament to Consider: y/n");
            DecisionByParliament();

            CityStats(decreaseInNationalPMInfluence);


        }

        private static void DecisionByParliament()
        {
            throw new NotImplementedException();
        }

        private static void CityStats(int decreaseInNationalPMInfluence)
        {
            var decreaseInPMInfluence = decreaseInNationalPMInfluence;
            var booly = "";
            var calculate = true;
            while (calculate)
            {

                var newCity = new City();

                Console.WriteLine("Name of City:");
                newCity.Name = Console.ReadLine();

                //HOUSING

                Console.WriteLine("City Homeless Pop: ");
                newCity.Homeless = int.Parse(Console.ReadLine());
                decreasePMInfluence(newCity.Homeless, ref decreaseInPMInfluence);

                //FOOD

                Console.WriteLine("Is the City Pop under 4: y/n?");
                booly = Console.ReadLine();
                if (booly != "y" && booly != "n")
                {
                    TryAgain();
                }
                else if (booly == "y")
                {
                    newCity.PopUnder4 = true;
                    decreasePMInfluence(1, ref decreaseInPMInfluence);
                    Console.WriteLine("(1)The PM's influence has been decreased by a total of: " + decreaseInPMInfluence);
                }
                else
                {
                    Console.WriteLine("Error");
                }
                booly = "";

                Console.WriteLine("Does the City suffer from Starvation: y/n?");
                booly = Console.ReadLine();
                if (booly != "y" && booly != "n")
                {
                    TryAgain();
                }
                else if (booly == "y")
                {
                    newCity.Starving = true;
                    decreasePMInfluence(1, ref decreaseInPMInfluence);
                    Console.WriteLine("(1)The PM's influence has been decreased by a total of: " + decreaseInPMInfluence);
                }
                else
                {
                    Console.WriteLine("Error");
                }
                booly = "";

                Console.WriteLine("Will the city not grow for 15 or more years: y/n?");
                booly = Console.ReadLine();
                if (booly != "y" && booly != "n")
                {
                    TryAgain();
                }
                else if (booly == "y")
                {
                    newCity.GrowthGreaterThan15Turns = true;
                    decreasePMInfluence(1, ref decreaseInPMInfluence);
                    Console.WriteLine("(1)The PM's influence has been decreased by a total of: " + decreaseInPMInfluence);
                }
                else
                {
                    Console.WriteLine("Error");
                }
                booly = "";

                //COMMERCE
                Console.WriteLine("Does the City incur more expenses than income: y/n?");
                booly = Console.ReadLine();
                if (booly != "y" && booly != "n")
                {
                    TryAgain();
                }
                else if (booly == "y")
                {
                    newCity.NegativeCommerce = true;
                    decreasePMInfluence(1, ref decreaseInPMInfluence);
                    Console.WriteLine("(1)The PM's influence has been decreased by a total of: " + decreaseInPMInfluence);
                }
                else
                {
                    Console.WriteLine("Error");
                }
                booly = "";

                Console.WriteLine("Is the City's Net Income less than 5: y/n?");
                booly = Console.ReadLine();
                if (booly != "y" && booly != "n")
                {
                    TryAgain();
                }
                else if (booly == "y")
                {
                    newCity.CommerceLessThan5 = true;
                    decreasePMInfluence(1, ref decreaseInPMInfluence);
                    Console.WriteLine("(1)The PM's influence has been decreased by a total of: " + decreaseInPMInfluence);
                }
                else
                {
                    Console.WriteLine("Error");
                }
                booly = "";

                //CULTURE
                Console.WriteLine("How many excess disloyalty if any exists? ");
                newCity.ExcessNegativeLoyalty = int.Parse(Console.ReadLine());
                decreasePMInfluence(newCity.ExcessNegativeLoyalty, ref decreaseInPMInfluence);

                //SCIENCE
                Console.WriteLine("How many Education Districts/Buildings are AVAILABLE if any? ");
                newCity.NumberOfScienceBuildingCanBuild = int.Parse(Console.ReadLine());
                decreasePMInfluence(newCity.NumberOfScienceBuildingCanBuild, ref decreaseInPMInfluence);

                //AMENITIES
                Console.WriteLine("How much if any excess unhappiness does the City suffer?");
                newCity.ExcessUnhappiness = int.Parse(Console.ReadLine());
                decreasePMInfluence(newCity.ExcessUnhappiness, ref decreaseInPMInfluence);

                //CALC ANOTHER CITY
                Console.WriteLine("(2)The PM's influence has been decreased by a total of: " + decreaseInPMInfluence);
                Console.WriteLine("Calculate Another City? y/n");
                if (Console.ReadLine() != "y")
                {
                    calculate = false;
                }
                else
                {
                    decreaseInPMInfluence = decreaseInNationalPMInfluence;
                }

            }
        }

        static int decreaseNationalPMInfluence(int number, ref int decreaseInNationalPMInfluence)
        {
            while (number > 0)
            {
                decreaseInNationalPMInfluence++;
                number--;
            }
            Console.WriteLine("The PM's influence has been decreased by a total of: " + decreaseInNationalPMInfluence);
            return decreaseInNationalPMInfluence;
        }
        static int decreasePMInfluence(int number, ref int decreaseInPMInfluence)
        {
            while (number > 0)
            {
                decreaseInPMInfluence++;
                number--;
            }
            Console.WriteLine("The PM's influence has been decreased by a total of: " + decreaseInPMInfluence);
            return decreaseInPMInfluence;
        }

        static string TryAgain()
        {
            Console.WriteLine("Input invalid, please try again:");
            return Console.ReadLine();
        }

        class City
        {
            public string Name;
            //Housing
            public int Homeless;
            //Food
            public bool PopUnder4;
            public bool Starving;
            public bool GrowthGreaterThan15Turns;
            //Commerce
            public bool NegativeCommerce;
            public bool CommerceLessThan5;
            //Culture
            public int ExcessNegativeLoyalty;
            //Science
            public int NumberOfScienceBuildingCanBuild;
            //Amenities
            public int ExcessUnhappiness;
        }

        class Nation
        {
            //Commerce
            public int NumberCivsWithHigherCommerce;
            public int NumberUnusedTradeRoutes;
            //Culture
            public int NumberCivsWithHigherCulture;
            //Science
            public int NumberCivsWithMoreTech;
            //Military
            public bool AtWar;
            public int NumberCivsWithBiggerMilitary;
            //Inustry 
            public int NumberCivsWithHigherProduction;
        }
    }
}
