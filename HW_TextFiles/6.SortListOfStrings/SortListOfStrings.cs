//6. Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _6.SortListOfStrings
{
    class SortListOfStrings
    {
        static void Main(string[] args)
        {
            List<string> inputList = new List<string>();
            StreamReader inpFile = new StreamReader(@"..\..\..\test8.txt");
            using (inpFile)
            {
                string row = inpFile.ReadLine();
                while (row != null)
                {
                    inputList.Add(row);
                    row = inpFile.ReadLine();
                }
            }
            string[] arr = inputList.ToArray();
            Array.Sort(arr);
            StreamWriter outputfile = new StreamWriter(@"..\..\..\test9.txt");
            using (outputfile)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    outputfile.WriteLine(arr[i]);
                }
            }
            Console.WriteLine("This program has just sorted the list of the file test8 and has saved it in the file test9.txt.");
            Console.WriteLine("You could find both files in the derictory HW_TextFiles\\");
        }
    }
}
