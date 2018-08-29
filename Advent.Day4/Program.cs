using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = new StreamReader("input.txt").ReadToEnd();

            input = input.Trim();

            string[] passphrases = input.Split(
               new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None);

            int validCount = 0; 

            foreach (string passphrase in passphrases)
            {
                List<string> words = new List<string>(passphrase.Split(' '));

                if (words.Count() == words.Distinct().Count())
                {
                    bool foundAnagram = false; 

                    foreach (string word in words)
                    {
                        List<string> anagrams = words.FindAll(x => x != word && x.Length == word.Length && x.Except(word).Count() == 0);

                        if (anagrams != null && anagrams.Count > 0)
                        {
                            foundAnagram = true;
                            break;
                        }
                    }

                    if (!foundAnagram)
                    {
                        validCount++;
                    }

                    
                }
            }

            Console.WriteLine("Total passphrases: " + passphrases.Count());

            Console.WriteLine("Valid passphrvalidCount: " + validCount);

        }
    }
}
