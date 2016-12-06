using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Day6
    {
        static string[] lines = File.ReadAllLines(@"C: \Users\Kurt\Documents\Visual Studio 2015\Projects\AdventOfCode\input6.txt");
        static string[] test = {"eedadn",
                                "drvtee",
                                "eandsr",
                                "raavrd",
                                "atevrs",
                                "tsrnev",
                                "sdttsa",
                                "rasrtv",
                                "nssdts",
                                "ntnada",
                                "svetve",
                                "tesnvt",
                                "vntsnd",
                                "vrdear",
                                "dvrsen",
                                "enarar",
                                };
        static string[] columns = new string[8];
        static Dictionary<char, int> letterCount;
        static string curcol = "";
        static string pw;
        static int curmax;
        static int iter;

        public static void Main()
        {
            //place every first char of a string into the first char of a column
            StringsToColumns();

            foreach (string s in columns)
            {
                curcol = s;
                CountLetters();
                //Console.WriteLine(s);
            }
            Console.WriteLine(pw);
            Console.ReadLine();
        }

        public static void CountLetters()
        {
            letterCount = new Dictionary<char, int>();

            //add letters and their occurrence to a dictionary
            foreach (char c in curcol)
            {
                if (letterCount.ContainsKey(c))
                {
                    letterCount[c]++;
                }
                else letterCount.Add(c, 1);
            }

            //redefine the max amount a letter occurs
            curmax = letterCount.Values.Max();
            
            //check if the character is the most occurring character and if so, add it to the password
            foreach (char c in curcol)
            {
                if (letterCount[c] == curmax)
                {
                    pw += c;
                    break;
                }
            }
        }

        //place every char of a string into the string[i]th column
        public static void StringsToColumns()
        {
            foreach (string line in lines)
            {              
                iter = 0;
                foreach (char c in line)
                {
                    columns[iter] += c;
                    iter++;
                }
            }
        }

    }
}
