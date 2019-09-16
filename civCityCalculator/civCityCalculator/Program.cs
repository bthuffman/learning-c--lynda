using Newtonsoft.Json;
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
            
            newNation.NumberCivsWithHigherCommerce = int.Parse(ConsoleUtility.Ask("How many Civs have higher levels of Commerce?"));
            DecreasePMInfluence(newNation.NumberCivsWithHigherCommerce, ref decreaseInNationalPMInfluence);

            
            newNation.NumberUnusedTradeRoutes = int.Parse(ConsoleUtility.Ask("How many unused trade routes are there?"));
            DecreasePMInfluence(newNation.NumberUnusedTradeRoutes, ref decreaseInNationalPMInfluence);

            
            newNation.NumberCivsWithHigherCulture = int.Parse(ConsoleUtility.Ask("How many Civs have higher levels of Culture?"));
            DecreasePMInfluence(newNation.NumberCivsWithHigherCulture, ref decreaseInNationalPMInfluence);

            
            newNation.NumberCivsWithMoreTech = int.Parse(ConsoleUtility.Ask("How many Civs have higher levels of Tech?"));
            DecreasePMInfluence(newNation.NumberCivsWithMoreTech, ref decreaseInNationalPMInfluence);

            natBooly = ConsoleUtility.Ask("Is the country at War: y/n?");
            IfElseUtility.IfElseUtilityMethod(ref natBooly, ref decreaseInNationalPMInfluence, ref newNation.AtWar);

            newNation.NumberCivsWithBiggerMilitary = int.Parse(ConsoleUtility.Ask("How many Civs have a bigger Military?"));
            DecreasePMInfluence(newNation.NumberCivsWithBiggerMilitary, ref decreaseInNationalPMInfluence);
            
            newNation.NumberCivsWithHigherProduction = int.Parse(ConsoleUtility.Ask("How many Civs have higher levels of Production?"));
            DecreasePMInfluence(newNation.NumberCivsWithHigherProduction, ref decreaseInNationalPMInfluence);

            Dump(newNation);
            /*
             * SESSION OF PARLIAMENT
             * */
            Console.WriteLine("Is there a national decision for Parliament to Consider: y/n");
            //DecisionByParliament();

            CityStats(decreaseInNationalPMInfluence);
        }

        /*private static void DecisionByParliament()
        {
            throw new NotImplementedException();
        }*/

        private static void CityStats(int decreaseInNationalPMInfluence)
        {
            var decreaseInPMInfluence = decreaseInNationalPMInfluence;
            var booly = "";
            var calculate = true;
            while (calculate)
            {
                var newCity = new City();
                
                newCity.Name = ConsoleUtility.Ask("Name of City:"); ;

                //HOUSING
                
                newCity.Homeless = int.Parse(ConsoleUtility.Ask("City Homeless Pop: "));
                DecreasePMInfluence(newCity.Homeless, ref decreaseInPMInfluence);

                //FOOD

                booly = ConsoleUtility.Ask("is the city pop under 4: y/n?");
                IfElseUtility.IfElseUtilityMethod(ref booly, ref decreaseInPMInfluence, ref newCity.PopUnder4);
                
                booly = ConsoleUtility.Ask("Does the City suffer from Starvation: y/n?");
                IfElseUtility.IfElseUtilityMethod(ref booly, ref decreaseInPMInfluence, ref newCity.Starving);
                
                booly = ConsoleUtility.Ask("Will the city not grow for 15 or more years: y/n?");
                IfElseUtility.IfElseUtilityMethod(ref booly, ref decreaseInPMInfluence, ref newCity.GrowthGreaterThan15Turns);

                //COMMERCE
                booly = ConsoleUtility.Ask("Does the City incur more expenses than income: y/n?");
                IfElseUtility.IfElseUtilityMethod(ref booly, ref decreaseInPMInfluence, ref newCity.NegativeCommerce);

                booly = ConsoleUtility.Ask("Is the City's Net Income less than 5: y/n?");
                IfElseUtility.IfElseUtilityMethod(ref booly, ref decreaseInPMInfluence, ref newCity.CommerceLessThan5);

                //CULTURE
                
                newCity.ExcessNegativeLoyalty = int.Parse(ConsoleUtility.Ask("How many excess disloyalty if any exists? "));
                DecreasePMInfluence(newCity.ExcessNegativeLoyalty, ref decreaseInPMInfluence);

                //SCIENCE
               
                newCity.NumberOfScienceBuildingCanBuild = int.Parse(ConsoleUtility.Ask("How many Education Districts/Buildings are AVAILABLE if any? "));
                DecreasePMInfluence(newCity.NumberOfScienceBuildingCanBuild, ref decreaseInPMInfluence);

                //AMENITIES
                
                newCity.ExcessUnhappiness = int.Parse(ConsoleUtility.Ask("How much if any excess unhappiness does the City suffer?"));
                DecreasePMInfluence(newCity.ExcessUnhappiness, ref decreaseInPMInfluence);

                //CALC ANOTHER CITY
                Console.WriteLine("(2)The PM's influence has been decreased by a total of: " + decreaseInPMInfluence);
                Console.WriteLine("Calculate Another City? y/n");
                if (Console.ReadLine() != "y")
                {
                    calculate = false;
                    Dump(newCity);
                }
                else
                {
                    decreaseInPMInfluence = decreaseInNationalPMInfluence;
                    Dump(newCity);
                }

            }
        }

        public static int DecreasePMInfluence(int number, ref int decreaseInInfluence)
        {
            while (number > 0)
            {
                decreaseInInfluence++;
                number--;
            }
            Console.WriteLine("The PM's influence has been decreased by a total of: " + decreaseInInfluence);
            return decreaseInInfluence;
        }
        /*
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
        */

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
        private static void Dump(object o)
        {
            string json = JsonConvert.SerializeObject(o, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
