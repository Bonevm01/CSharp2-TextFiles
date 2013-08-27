//11. Write a program that deletes from a text file all words that start with the prefix "test". 
//  Words contain only the symbols 0...9, a...z, A…Z, _.


using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class DeleteTestWords
{
    static void Main()
    {
        Console.WriteLine("The following code will generate a text file (test15.txt) and will delete all words that start with \"test\".");
        //Generate input file
        string[] data = { "start", "tester", "line", "race", "tour", "testing", "goal", "properties", "compare", "test", "divide", "test09_", "testABC15_15" };
        StreamWriter inputfile = new StreamWriter(@"..\..\..\test15.txt");
        StringBuilder temporary = new StringBuilder();
        Random rnd = new Random();
        for (int i = 0; i < 1000; i++)
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

        //Delete words that start with "test"
        StreamReader origin = new StreamReader(@"..\..\..\test15.txt");
        StreamWriter outputFile = new StreamWriter(@"..\..\..\test16.txt");
        using (origin)
        {
            using (outputFile)
            {
                string line = origin.ReadLine();
                while (line != null)
                {
                    outputFile.WriteLine(Regex.Replace(line, @"\btest\w*\b", ""));
                    line = origin.ReadLine();
                }
            }
        }
        Console.WriteLine("Check files test15.txt and backup.txt.");
        //To save new list of words in the original file
        File.Replace(@"..\..\..\test16.txt", @"..\..\..\test15.txt", @"..\..\..\backup.txt");
        File.Delete(@"..\..\..\test16.txt");
    }
}
