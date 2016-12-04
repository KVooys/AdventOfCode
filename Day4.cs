using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode
{
    class Day4
    {
        static string[] lines = File.ReadAllLines(@"C:\Users\Kurt\Documents\Visual Studio 2015\Projects\AdventOfCode\input4.txt");
        static string[] splitline;

        public static void Main()
        {
            foreach(string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }
    }

}

