//1. Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.PrintOddLines
{
    class PrintOddLines
    {
        static void Main()
        {
            string fileName = @"..\..\..\test1.txt";
            StreamReader myFile = new StreamReader(fileName);

            using (myFile)
            {
                string rows = myFile.ReadLine();
                int rowNumber = 1;
                while (rows != null)
                {
                    if (rowNumber%2==1)
                    {
                        Console.WriteLine(rows);
                    }
                    rowNumber++;
                    rows = myFile.ReadLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine("The end of the program.");

        }
    }
}
