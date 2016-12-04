using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


namespace AdventOfCode
{
    class Day4
    {
        static string[] lines = File.ReadAllLines(@"C: \Users\Kurt\Documents\Visual Studio 2015\Projects\AdventOfCode\input4.txt");
        static string[] splitlines;
        static string name;
        static int number;
        static int total;
        static int curmax;
        static string checksum;
        static List<char> mostoccurs = new List<char>();        
        static List<char> checks = new List<char>();
        static List<char> tempchars = new List<char>();
        static Dictionary<char, int> letterCount;
        static StringBuilder checkstring = new StringBuilder();
        static StringBuilder occurstring = new StringBuilder();

        //part 2 variables
        static uint cipher;
        static uint unicode;
        static char realtext;        
        static string check = "North Pole";
        static string decodedsentence;
        static List<string> output = new List<string>();


        public static void Main()
        {
            foreach (string line in lines)
            {
                //separate the checksum from the rest
                splitlines = line.Split('[');
                name = splitlines[0];
                checksum = splitlines[1];

                checksum = checksum.Trim(']');
                checks = checksum.ToList();
                checks.Sort();

                //separate the name from the number
                name = name.Replace("-","");               
                number = int.Parse(Regex.Match(name, @"\d+").Value);
                name = Regex.Match(name, @"\D+").Value;
               
                Console.WriteLine(name);
                Console.WriteLine(number);
                Part2();
                File.WriteAllLines(@"C: \Users\Kurt\Documents\Visual Studio 2015\Projects\AdventOfCode\output.txt", output);
                /*CountLetters();
                if (Check()) total += number;               
                Reset();
                */
            }
            Console.WriteLine("The sum of real room IDs is " + total);
            Console.ReadLine();
        }   
        
        public static void CountLetters()
        {
            //put the occurring characters into a dictionary
            letterCount = new Dictionary<char, int>();           
            foreach(char c in name)
            {
                if (letterCount.ContainsKey(c))
                {
                    letterCount[c]++;
                }
                else letterCount.Add(c, 1);                                               
            }                             

            //add the 5 chars with the max value to the mostoccurs list while removing it from the dictionary          
            for (int i = 0; i < 5; i++)
            {
                //make an alphabetical list every time     
                tempchars = letterCount.Keys.ToList();
                tempchars.Sort();

                //redefine max value 
                curmax = letterCount.Values.Max();              

                foreach (char c in tempchars)
                {                    
                    //check if max value

                    if (letterCount[c]==curmax)
                    {
                        mostoccurs.Add(c);                        
                        letterCount.Remove(c);                        
                        break;
                    }
                }
            }

            //add both the check and the top5 to comparable strings
            mostoccurs.Sort();
            foreach (char c in mostoccurs)
            {
                occurstring.Append(c);
            }            

            checks.Sort();
            foreach(char c in checks)
            {
                checkstring.Append(c);
            }                                               
        }
        
        public static bool Check()
        {
            return occurstring.Equals(checkstring);
        }   

        public static void Reset()
        {
            mostoccurs.Clear();
            checks.Clear();
            letterCount.Clear();
            tempchars.Clear();
            occurstring.Clear();
            checkstring.Clear();
        }

        public static void Part2()
        {
            cipher = (uint)(number % 26);         

            foreach (char c in name)
            {
                unicode = (uint)c;
                
                if ((unicode + cipher) <= 122)
                {
                    realtext = (char)(unicode + cipher);                                      
                }
                else
                {
                    uint diff = 122 - unicode;
                    realtext = (char)(97 + diff);
                }
                Console.Write(realtext);
                decodedsentence += realtext;
            }
            output.Add(decodedsentence + " " + number);
            decodedsentence = "";
        }
    }
}
