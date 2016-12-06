using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode
{
    class Day5
    {
        static MD5 md5 = System.Security.Cryptography.MD5.Create();
        static StringBuilder sb = new StringBuilder();
        static StringBuilder pw = new StringBuilder();
        static StringBuilder pw2 = new StringBuilder();
        static string id = "ffykfhsq"; //this id is the only input for today
        static string tohash = "";
        static byte[] inputBytes;
        static byte[] hash;
        static char curpos;
        static int num;
        static int found = 0;

        public static void Main()
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                tohash = ("" + id + i);
                //Console.WriteLine(tohash);
                inputBytes = System.Text.Encoding.ASCII.GetBytes(tohash);
                hash = md5.ComputeHash(inputBytes);
                if (CheckIfFiveZeroes())
                {
                    //AddToPw();
                    if (IsRealPosition())
                    {
                        AddToPw2();
                        //once we have enough numbers to find all the keys, we can stop looping
                        if (found == 25)
                        {
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(pw2);
            Console.ReadLine();
        }


        //part of the 1st solution
        public static void AddToPw()
        {
            //add the 6th character to our password
            pw.Append(sb[5]);
            found++;
            sb.Clear();
        }

        //part of the 2nd solution
        public static void AddToPw2()
        {
            found++;
            Console.WriteLine("Found one! " + sb[6] + " on position " + num);
            pw2.Append(sb[6] + " on position " + num + ", " + "\n");
            sb.Clear();
        }


        public static bool CheckIfFiveZeroes()
        {
            //add the first 6 ( or 8 for part 2) characters to a checkable stringbuilder, stop when incorrect substring is encountered
            for (int i = 0; i < 4; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            //check if 5 zeroes
            if (sb.ToString().Substring(0, 5).Equals("00000"))
            {
                return true;
            }
            else
            {
                sb.Clear();
                return false;
            }
        }

        //checks if the position is a number, then if the number is between 0 and 7
        public static bool IsRealPosition()
        {
            curpos = sb[5];
            if (Char.IsDigit(curpos))
            {
                //Console.WriteLine(curpos);
                num = (int)Char.GetNumericValue(curpos);
                if (num >= 0 && num <= 7)
                {
                    //Console.WriteLine("Got a good position");
                    return true;
                }
                else
                {
                    sb.Clear();
                    return false;
                }

            }
            else
            {
                sb.Clear();
                return false;
            }
        }
    }
}