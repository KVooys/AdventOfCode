﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode
{
    class Day7
    {
        static string[] lines = File.ReadAllLines(@"C: \Users\Kurt\Documents\Visual Studio 2015\Projects\AdventOfCode\input7.txt");
        //static string test = "uxpvoytxfazjjhi[qogwhtzmwxvjwxreuz]zduoybbzxigwggwu[lamifchqqwbphhsqnf]qrjdjwtnhsjqftnqsk[bsqinwypsnnvougrs]wfmhtjkysqffllakru";
        static string betweenbracks = "";
        static string nobracks = "";
        static string substr1 = "";
        static string substr2 = "";
        static int count = 0;

        public static void Main()
        {
            foreach (string s in lines)
            {
                //put the part between brackets in betweenbracks
                RemoveBrackets(s);
                //put the rest in nobracks
                nobracks = Regex.Replace(s, @"\[(\w+)\]", "");
                Console.WriteLine(nobracks);
                
                //only count occurrences where the betweenbracks do not produce abba, but the entire string does
                if (CheckIfAbba(betweenbracks) == false)
                {
                    if (CheckIfAbba(s))
                    {
                        count++;
                    }
                }
                betweenbracks = "";
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }

        public static string RemoveBrackets(string s)
        {
            //find the part(s) between bracks and put them in betweenbracks
            MatchCollection bracks = Regex.Matches(s, @"\[(\w+)\]");
            foreach (Match m in bracks)
            {
                betweenbracks += m.ToString();                               
            }
            return s;           
        }

        public static bool CheckIfAbba(string s)
        {
            for (int i = 0; i < s.Length - 3; i++)
            {
                //make 2 substrings out of the first 4 characters to compare
                substr1 = s.Substring(i, 2);
                substr2 = s.Substring(i + 2, 2);

                //check if the substrings are inverse of one another and are not all the same letter
                if (substr1[0].Equals(substr2[1]) && (substr2[0].Equals(substr1[1])) && !(substr1[0].Equals(substr1[1])))
                {
                    Console.WriteLine(substr1 + substr2);
                    return true;
                }
            }
            return false;
        }

        public static bool CheckAba(string s)
        {
            for (int i = 0; i < s.Length - 3; i++)
            {
                //make 2 substrings out of the first 3 characters to compare
                substr1 = s.Substring(i, 2);
                substr2 = ""+ s[i + 2];

                //check if the substrings are inverse of one another and are not all the same letter
                if (substr1[0].Equals(substr2[1]) && (substr2[0].Equals(substr1[1])) && !(substr1[0].Equals(substr1[1])))
                {
                    Console.WriteLine(substr1 + substr2);
                    return true;
                }
            }
                

            return false;
        }
    }
}