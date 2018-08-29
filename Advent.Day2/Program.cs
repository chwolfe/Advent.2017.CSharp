using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = new StreamReader("input.txt").ReadToEnd();

            input = input.Trim();

            string[] rows = input.Split(
               new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None);

            int checksum = 0;

            foreach (string row in rows)
            {
                List<int> cols = row.Split('\t').Select(x => int.Parse(x)).ToList();

                for (int count1 = 0; count1 < cols.Count; count1++ )
                {
                    for (int count2 = 0; count2 < cols.Count; count2++)
                    {
                        if (count1 != count2 && (cols[count1] % cols[count2]) == 0)
                        {
                            checksum += (cols[count1] / cols[count2]);
                            break;
                        }
                    }
                }

                //checksum += (cols.Max() - cols.Min());
            }

            Console.WriteLine(checksum);

        }
    }
}
