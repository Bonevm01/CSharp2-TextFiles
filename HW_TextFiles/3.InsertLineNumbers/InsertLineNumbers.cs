//3. Write a program that reads a text file and inserts line numbers in front of each of its lines.
//  The result should be written to another text file.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3.InsertLineNumbers
{
    class InsertLineNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The following program is going to add line numbers in front of each line of the file tset3.");
            StreamReader inputFile = new StreamReader(@"..\..\..\test3.txt");
            StreamWriter outputFile = new StreamWriter(@"..\..\..\test4.txt");
            try
            {
                string line = inputFile.ReadLine();
                int row = 1;
                while (line != null)
                {
                    outputFile.WriteLine(AddLineNumber(row, line));
                    row++;
                    line = inputFile.ReadLine();
                }
            }
            finally
            {

                inputFile.Close();
                outputFile.Close();
            }
            Console.WriteLine();
            Console.WriteLine("The line numbers have just been added. Please check file test4.txt in HW_TextFiles\\");


        }

        static string AddLineNumber(int a, string str)
        {
            string newLine = a + " - " + str;
            return newLine;
        }
    }
}
