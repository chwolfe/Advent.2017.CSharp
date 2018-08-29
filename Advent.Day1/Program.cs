using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Advent.Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = new StreamReader("input.txt").ReadToEnd();

            input = input.Trim();

            char[] numbers = input.ToCharArray();

            StreamWriter sw = new StreamWriter("FileForSQL.txt", false);

            foreach (char n in numbers)
            {
                sw.WriteLine(n);
            }

            sw.Close();

            //ArrayList numberList = new ArrayList(numbers.Length);

            Console.WriteLine("Length of list: " + numbers.Length);

            int stepsToTake = numbers.Length / 2; 

            int sum = 0;

            for(int index = 0; index < numbers.Length; index++)
            {
                int currentNumber = int.Parse(numbers[index].ToString());

                int nextNumberIndex = index + stepsToTake;

                if (nextNumberIndex < numbers.Length)
                {
                    if (numbers[index] == numbers[nextNumberIndex])
                    {
                        sum += currentNumber;
                    }
                }
                else
                {
                    int rollingIndex = nextNumberIndex - numbers.Length;

                    if (numbers[index] == numbers[rollingIndex])
                    {
                        sum += currentNumber;
                    }
                }
            }

            /*if (numbers[0] == numbers[numbers.Length-1])
            {
                sum += int.Parse(numbers[0].ToString());
            }*/

            Console.WriteLine("Sum is: " + sum);
        }
    }
}
