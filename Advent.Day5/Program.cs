using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = new StreamReader("input.txt").ReadToEnd();

            input = input.Trim();

            int[] jumpOffsets = input.Split(
               new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None).Select(x => int.Parse(x)).ToArray();

            /*int[] jumpOffsets = new List<int>()
            {
                0,
                3,
                0,
                1,
                -3
            }.ToArray();*/

            int currentIndex = 0;

            int stepCount = 0;

            while (currentIndex >= 0 && currentIndex < jumpOffsets.Length)
            {
                int holdCurrentIndex = currentIndex;

                int currentOffset = jumpOffsets[holdCurrentIndex];

                currentIndex = holdCurrentIndex + currentOffset;

                if (currentOffset < 3)
                {
                    jumpOffsets[holdCurrentIndex]++;
                }
                else
                {
                    jumpOffsets[holdCurrentIndex]--;
                }

                stepCount++;
            }

            Console.WriteLine(stepCount);


        }
    }
}
