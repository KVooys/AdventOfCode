using System;
using System.IO;

//challenge: http://adventofcode.com/2016/day/3

namespace AdventOfCode
{
    class Day3
    {

        static string[] lines = File.ReadAllLines(@"C: \Users\Kurt\Documents\Visual Studio 2015\Projects\AdventOfCode\input3.txt");
        static string[] numbers = new string[3];
        static int a = 0;
        static int b = 0;
        static int c = 0;
        static int count;

        //part 1
        public static void Main()
        {
            

            //split every line from the input
            foreach(string line in lines)
            {
                //split all the numbers in the line
                numbers = line.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);                               
                
                
                foreach (string n in numbers)
                {
                    if (n != String.Empty)
                    {
                        a = int.Parse(numbers[0]);
                        b = int.Parse(numbers[1]);
                        c = int.Parse(numbers[2]);
                    }                  
                }
                Console.Out.WriteLine(a + "+" + b + "+" + c);
                if (IsATriangle()) count++;
            }
            Console.Out.WriteLine("There are " + count + " possible triangles.");
            Console.ReadLine();
        }

        public static bool IsATriangle()
        {
            if ((a + b > c) && (a + c > b) && (b + c > a))
            {
                return true;
            }
            else return false;
        }
        
        //part 2 of the challenge
        public static void Part2()
        {
            int i = 0;
            int n1, n2, n3, n4, n5, n6, n7, n8, n9;            
            string firstrow;
            string secondrow;
            string thirdrow;

            //loop over the text file again
            while (i < lines.Length)
            {
                //place three topmost rows into temporary strings
                firstrow = lines[i];
                secondrow = lines[i + 1];
                thirdrow = lines[i + 2];

                //rearrange the numbers to logical numbers
                numbers = firstrow.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                n1 = int.Parse(numbers[0]);
                n4 = int.Parse(numbers[1]);
                n7 = int.Parse(numbers[2]);
                numbers = secondrow.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                n2 = int.Parse(numbers[0]);
                n5 = int.Parse(numbers[1]);
                n8 = int.Parse(numbers[2]);
                numbers = thirdrow.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                n3 = int.Parse(numbers[0]);
                n6 = int.Parse(numbers[1]);
                n9 = int.Parse(numbers[2]);

                a = n1;
                b = n2;
                c = n3;
                if (IsATriangle()) count++;
                a = n4;
                b = n5;
                c = n6;
                if (IsATriangle()) count++;
                a = n7;
                b = n8;
                c = n9;
                if (IsATriangle()) count++;
                i += 3;
            }
            Console.Out.WriteLine(count);
            Console.ReadLine();
        }
    }
}
