//7. Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file.
//  Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;
using System.Text;

class ReplaceStart
{
    static void Main()
    {
        Console.WriteLine("The following code will generate a big text file and will replase all occurences of the substring start with finish.");
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

        //Replace substring start with finish
        StreamReader origin = new StreamReader(@"..\..\..\test10.txt");
        StreamWriter outputFile = new StreamWriter(@"..\..\..\test11.txt");
        using (origin)
        {
            using (outputFile)
            {
                string line = origin.ReadLine();
                while (line != null)
                {
                    line = line.Replace("start", "finish");
                    outputFile.WriteLine(line);
                    line = origin.ReadLine();
                }
            }
        }
        Console.WriteLine("Check files test10 and test11. You have to wait a while to open these files.");
    }
}
