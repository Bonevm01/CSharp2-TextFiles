//8. Modify the solution of the previous problem to replace only whole words (not substrings).


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace _8.ReplaceStartWord
{
    class ReplaceStartWord
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The following code will generate a big text file and will replase all occurences of the word start with finish.");
            Console.WriteLine("Please wait...");
            //Generate input file
            string[] data = { "start", "starting", "line", "race", "tour", "startdfh", "goal", "properties", "compare", "print", "divide" };
            StreamWriter inputfile = new StreamWriter(@"..\..\..\test10.txt");
            StringBuilder temporary = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 9000000; i++)
            {
                temporary.Append(data[rnd.Next(0, data.Length)]);
                temporary.Append(" ");
                if (i % 10 == 0)
                {
                    temporary.Append("\r\n");
                }
            }
            using (inputfile)
            {
                inputfile.WriteLine(temporary.ToString());
            }

            //Replace words start with word finish
            StreamReader origin = new StreamReader(@"..\..\..\test10.txt");
            StreamWriter outputFile = new StreamWriter(@"..\..\..\test11.txt");
            using (origin)
            {
                using (outputFile)
                {
                    string line = origin.ReadLine();
                    while (line != null)
                    {
                        outputFile.WriteLine(Regex.Replace(line, @"\bstart\b", "finish"));
                        line = origin.ReadLine();
                    }
                }
            }
            Console.WriteLine("Check files test10 and test11. You have to wait a while to open these files.");
        }
    }
}

