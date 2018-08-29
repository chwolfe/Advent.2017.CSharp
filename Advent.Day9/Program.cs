using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent.Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Test cases: 
                {}, score of 1.
                {{{}}}, score of 1 + 2 + 3 = 6.
                {{},{}}, score of 1 + 2 + 2 = 5.
                {{{},{},{{}}}}, score of 1 + 2 + 3 + 3 + 3 + 4 = 16.
                {<a>,<a>,<a>,<a>}, score of 1.
                {{<ab>},{<ab>},{<ab>},{<ab>}}, score of 1 + 2 + 2 + 2 + 2 = 9.
                {{<!!>},{<!!>},{<!!>},{<!!>}}, score of 1 + 2 + 2 + 2 + 2 = 9.
                {{<a!>},{<a!>},{<a!>},{<ab>}}, score of 1 + 2 = 3.
             
             */

            string characterStream = new StreamReader("input.txt").ReadToEnd();

            characterStream = characterStream.Trim();

            //remove canceled characters, as they break the usual parsing logic below. 
            characterStream = Regex.Replace(characterStream, "!.", String.Empty);

            int garbageCount = 0;

            foreach (Match match in Regex.Matches(characterStream, "<.*?>"))
            {
                garbageCount += (match.Length - 2);
            }

            Console.WriteLine(garbageCount);


            //remove garabage, lazy match via ? to get individual <> collections
            //characterStream = Regex.Replace(characterStream, "<.*?>", String.Empty);

            /*int openBracketCount = 0;
            List<int> groupScores = new List<int>();

            foreach(char character in characterStream)
            {
                if (character == '{')
                {
                    openBracketCount++;
                }
                else if (character == '}')
                {
                    groupScores.Add(openBracketCount);
                    openBracketCount--;
                }
            }

            if (openBracketCount != 0)
            {
                Console.WriteLine("Malformed input!!!!");
            }
            else
            {
                Console.WriteLine("Total score: " + groupScores.Sum());
            }*/
        }
    }
}
