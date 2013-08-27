//4. Write a program that compares two text files line by line and prints the number of lines
//  that are the same and the number of lines that are different. Assume the files have equal number of lines.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4.CompareLineByLine
{
    class CompareLineByLine
    {
        static void Main(string[] args)
        {
            StreamReader inputFile1 = new StreamReader(@"..\..\..\test3.txt");
            StreamReader inputFile2 = new StreamReader(@"..\..\..\test5.txt");
            List<int> sameLines = new List<int>();
            List<int> diffLines = new List<int>();

            try
            {
                string linesInFile1 = inputFile1.ReadLine();
                string linesInFile2 = inputFile2.ReadLine();
                int row = 1;
                while (linesInFile1 != null)
                {
                    if (linesInFile1 == linesInFile2)
                    {
                        sameLines.Add(row);
                    }
                    else
                    {
                        diffLines.Add(row);
                    }
                    row++;
                    linesInFile1 = inputFile1.ReadLine();
                    linesInFile2 = inputFile2.ReadLine();
                }

            }
            finally
            {

                inputFile1.Close();
                inputFile2.Close();
            }
            Console.Write("Same lines in files test3 and test5 are: ");
            PrintList(sameLines);
            Console.Write("Different lines in files test3 and test5 are: ");
            PrintList(diffLines);

        }
        static void PrintList(List<int> lst)
        {
            foreach (var num in lst)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
