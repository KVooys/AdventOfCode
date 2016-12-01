using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode
{
    public static class Day1
    {
        public static void Main()
        {
            //read the file, remove commas and spaces and put it into the coords array
            string lines = File.ReadAllText(@"C:\Users\Kurt\Documents\Visual Studio 2015\Projects\AdventOfCode\input.txt");
            lines = lines.Replace(" ", string.Empty);
            string[] coords = lines.Split(',');

            string loc = "";
            List<String> locs = new List<String>();
            char dir = 'n';
            char[] toTrim = { 'L', 'R' };
            int num = 0;
            int xpos = 0;
            int ypos = 0;
            int total = 0;

            foreach (string c in coords)
            {
                c.Trim();

                if (c[0] == 'L')
                {
                    num = int.Parse(c.Trim('L'));

                    switch (dir)
                    {
                        case ('n'):
                            dir = 'w';

                            for (int i = 1; i <= num; i++)
                            {
                                xpos--;
                                loc = ("" + xpos + " " + ypos);
                                if (locs.Contains(loc))
                                {
                                    Console.WriteLine("Found it:" + loc);
                                }
                                locs.Add(loc);
                            }
                            //xpos -= num;  
                            //locs.Add("" + xpos + " " + ypos);
                            break;
                        case ('e'):
                            dir = 'n';
                            for (int i = 1; i <= num; i++)
                            {
                                ypos++;
                                loc = ("" + xpos + " " + ypos);
                                if (locs.Contains(loc))
                                {
                                    Console.WriteLine("Found it:" + loc);
                                }
                                locs.Add(loc);
                            }
                            //ypos += num;
                            //locs.Add("" + xpos + " " + ypos);
                            break;
                        case ('w'):
                            dir = 's';
                            for (int i = 1; i <= num; i++)
                            {
                                ypos--;
                                loc = ("" + xpos + " " + ypos);
                                if (locs.Contains(loc))
                                {
                                    Console.WriteLine("Found it:" + loc);
                                }
                                locs.Add(loc);
                            }
                            //ypos -= num;
                            //locs.Add("" + xpos + " " + ypos);
                            break;
                        case ('s'):
                            dir = 'e';
                            for (int i = 1; i <= num; i++)
                            {
                                xpos++;
                                loc = ("" + xpos + " " + ypos);
                                if (locs.Contains(loc))
                                {
                                    Console.WriteLine("Found it:" + loc);
                                }
                                locs.Add(loc);
                            }
                            //xpos += num;
                            //locs.Add("" + xpos + " " + ypos);
                            break;
                        default:
                            break;
                    }
                }

                else if (c[0] == 'R')
                {
                    num = int.Parse(c.Trim(toTrim));

                    switch (dir)
                    {
                        case ('n'):
                            dir = 'e';
                            for (int i = 1; i <= num; i++)
                            {
                                xpos++;
                                loc = ("" + xpos + " " + ypos);
                                if (locs.Contains(loc))
                                {
                                    Console.WriteLine("Found it:" + loc);
                                }
                                locs.Add(loc);
                            }
                            //xpos += num;
                            //locs.Add("" + xpos + " " + ypos);
                            break;
                        case ('e'):
                            dir = 's';
                            for (int i = 1; i <= num; i++)
                            {
                                ypos--;
                                loc = ("" + xpos + " " + ypos);
                                if (locs.Contains(loc))
                                {
                                    Console.WriteLine("Found it:" + loc);
                                }
                                locs.Add(loc);
                            }
                            //ypos -= num;
                            //locs.Add("" + xpos + " " + ypos);
                            break;
                        case ('w'):
                            dir = 'n';
                            for (int i = 1; i <= num; i++)
                            {
                                ypos++;
                                loc = ("" + xpos + " " + ypos);
                                if (locs.Contains(loc))
                                {
                                    Console.WriteLine("Found it:" + loc);
                                }
                                locs.Add(loc);
                            }
                            //ypos += num;
                            //locs.Add("" + xpos + " " + ypos);
                            break;
                        case ('s'):
                            dir = 'w';
                            for (int i = 1; i <= num; i++)
                            {
                                xpos--;
                                loc = ("" + xpos + " " + ypos);
                                if (locs.Contains(loc))
                                {
                                    Console.WriteLine("Found it:" + loc);
                                }
                                locs.Add(loc);
                            }
                            //xpos -= num;
                            //locs.Add("" + xpos + " " + ypos);
                            break;
                        default:
                            break;
                    }

                }
                else break;
            }
            total = (Math.Abs(xpos) + Math.Abs(ypos));
            Console.WriteLine("The total distance is " + xpos + " horizontally and " + ypos + " vertically, " + total + " total");
            Console.ReadLine();
        }
    }
}
