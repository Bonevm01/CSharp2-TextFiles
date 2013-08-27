//2. Write a program that concatenates two text files into another text file.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.ConcatenateTextFiles
{
    class ConcatenateTextFiles
    {
        static void Main(string[] args)
        {

            StreamReader file1 = new StreamReader(@"..\..\..\test1.txt");
            StreamReader file2 = new StreamReader(@"..\..\..\test2.txt");
            StringBuilder newFile = new StringBuilder();
            string textOfFile;
            using (file1)
            {
                textOfFile = file1.ReadToEnd();
            }
            newFile.Append(textOfFile);
            newFile.Append("\r\n");
            
            using (file2)
            {
                textOfFile = file2.ReadToEnd();
            }
            newFile.Append(textOfFile);
            string combinedText = newFile.ToString();

            StreamWriter myNewFile = new StreamWriter(@"..\..\..\test3.txt");
            using (myNewFile)
            {
                myNewFile.Write(combinedText);
            }
            Console.WriteLine("Files test1 and test2 have just been concatenated to a new file - test3.");
            Console.WriteLine("Please checked in the derictory HW_TextFiles\\");
        }
    }
}
