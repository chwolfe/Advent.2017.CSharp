using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent.Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = new StreamReader("input.txt").ReadToEnd();

            input = input.Trim();
            
            List<int> bankConfig = input.Split('\t').Select(x => int.Parse(x)).ToList();
            //List<int> bankConfig = new List<int>()
            //{
            //    0,
            //    2,
            //    7,
            //    0
            //};

            List<string> configSnapshots = new List<string>();

            configSnapshots.Add(String.Join("|", bankConfig));

            int cycleCount = 0;

            bool TwoRuns = true;

            while (true)
            {
                int largestValue = bankConfig.Max();
                int largestIndex = bankConfig.IndexOf(largestValue);

                //clear out largest bank 
                bankConfig[largestIndex] = 0;

                int currentIndex = largestIndex + 1;

                while (largestValue > 0)
                {
                    if (currentIndex < bankConfig.Count)
                    {
                        bankConfig[currentIndex]++;
                        largestValue--;

                        currentIndex++;
                    }
                    else
                    {
                        currentIndex = 0;
                    }
                }

                cycleCount++;

                string bankSnapshot = String.Join("|", bankConfig);

                if (configSnapshots.Contains(bankSnapshot))
                {
                    if (TwoRuns)
                    {
                        configSnapshots.Clear();
                        configSnapshots.Add(bankSnapshot);
                        cycleCount = 0;
                        TwoRuns = false;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    configSnapshots.Add(bankSnapshot);
                }

            }

            Console.WriteLine("# of cycles until duplicate state: " + cycleCount);


        }
    }
}
