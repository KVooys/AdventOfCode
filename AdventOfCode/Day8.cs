using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

////challenge: http://adventofcode.com/2016/day/8

namespace AdventOfCode
{
    class Day8
    {
        static char[,] LCD = new char[3, 7]
          {
                {'.', '.', '.', '.', '.', '.', '.'},
                {'.', '.', '.', '.', '.', '.', '.'},
                {'.', '.', '.', '.', '.', '.', '.'}
          };

        public static void Main()
        {
            Rect(3, 2);
            MoveCol(2, 1);
            //display the grid as it currently is
            for (int k = 0; k < LCD.GetLength(0); k++)
            {
                
                for(int l = 0; l < LCD.GetLength(1); l++)
                {
                    Console.Write(LCD[k, l]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        //create an x,y rectangle of #s
        public static void Rect(int a, int b)
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    LCD[j, i] = '#';
                }
            }
        }

        //shift the array at column [a] down by b
        public static void MoveCol(int a, int b)
        {
            
        }

    }
}
