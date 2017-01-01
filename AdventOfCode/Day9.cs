using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Day9
    {
        static string source = File.ReadAllText(@"C: \Users\Kurt\Documents\Visual Studio 2015\Projects\AdventOfCode\input9.txt");
        static string test = "A(1x5)BC";
        static string[] betweenbracks;
        static string fix;
        static int beforex;
        static int afterx;

        public static void Main()
        {
            Console.WriteLine(test);
            Decipher();
            Console.ReadLine();
        }

        public static void Decipher()
        {
            //get the part between brackets
            MatchCollection bracks = Regex.Matches(test, @"\((.+)\)");
            foreach (Match m in bracks)
            {
                fix = m.ToString();
                //remove brackets and x to find relevant numbers
                fix = fix.Replace("(", "");
                fix = fix.Replace(")", "");
                betweenbracks = fix.Split('x');
                beforex = int.Parse(betweenbracks[0]);
                afterx = int.Parse(betweenbracks[1]);
                Console.WriteLine(beforex + " " + afterx);

                //now we need to check the input's next [afterx] characters right after the 2nd bracket
            }
            
        }

    }
}
