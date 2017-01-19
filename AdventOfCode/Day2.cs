using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//challenge: http://adventofcode.com/2016/day/2
namespace AdventOfCode
{
    class Day2
    {
        //challenge 1
        public static void Main()
        {
            //numpad logic, 2D array
            int[,] numpad = new int[3, 3] 
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7 ,8, 9 }
            };
            int x = 1;
            int y = 1;
            int pos = 0;
                 

            string[] lines = File.ReadAllLines(@"C:\Users\Kurt\Documents\Visual Studio 2015\Projects\AdventOfCode\input2.txt");
            foreach (string s in lines)
            {
                //loop over chars in string
                foreach (char c in s) {
                    switch (c)
                    {
                        case 'U':
                            if (x > 0)
                            {
                                x -= 1;
                            }                           
                            pos = numpad[x, y];                           
                            break;
                        case 'D':
                            if (x < 2)
                            {
                                x += 1;
                            }                          
                            pos = numpad[x, y];                           
                            break;
                        case 'L':
                            if (y > 0)
                            {
                                y -= 1;
                            }                          
                            pos = numpad[x, y];                                           
                            break;
                        case 'R':
                            if (y < 2)
                            {
                                y += 1;
                            }                            
                            pos = numpad[x, y];                          
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine(pos);
            }
            Console.ReadLine();
        }

        //challenge 2 
        public static void Keypad2()
        {
            char[,] keypad = new char[5, 5]
            {
                {'0', '0', '1', '0', '0' },
                {'0', '2', '3', '4', '0' },
                {'5', '6', '7', '8', '9' },
                {'0', 'A', 'B', 'C', '0' },
                {'0', '0', 'D', '0', '0' }
            };

            int x = 2;
            int y = 2;
            char pos = '#';
            string[] lines = File.ReadAllLines(@"C:\Users\Kurt\Documents\Visual Studio 2015\Projects\AdventOfCode\input2.txt");
            foreach (string s in lines)
            {
                //loop over chars in string
                foreach (char c in s)
                {
                    switch (c)
                    {
                        //also check if the position is still on the filled part of the keypad, aka not 0
                        case 'U':
                            if (x > 0)
                            {
                                if(keypad[x-1,y]!='0'){
                                    x -= 1;
                                }                                  
                            }
                            pos = keypad[x, y];
                            break;
                        case 'D':
                            if (x < 4)
                            {
                                if (keypad[x + 1, y] != '0')
                                {
                                    x += 1;
                                }
                            }
                            pos = keypad[x, y];
                            break;
                        case 'L':
                            if (y > 0)
                            {
                                if (keypad[x, y - 1] != '0')
                                {
                                    y -= 1;
                                }
                            }
                            pos = keypad[x, y];
                            break;
                        case 'R':
                            if (y < 4)
                            {
                                if (keypad[x, y + 1] != '0')
                                {
                                    y += 1;
                                }
                            }
                            pos = keypad[x, y];
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine(pos);
            }
            Console.ReadLine();
        }
    }
}
