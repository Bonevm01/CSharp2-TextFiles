//9. Write a program that deletes from given text file all odd lines. The result should be in the same file.


using System;
using System.IO;

class DeleteOddLines
{
    static void Main()
    {
        Console.WriteLine("The following code will delete odd lines from the file test12.txt.");
        Console.WriteLine("Initially test12.txt is a copy of test4.txt");
        if (File.Exists(@"..\..\..\test12.txt"))//Delete the file if exist
        {
            File.Delete(@"..\..\..\test12.txt");
        }
        File.Copy(@"..\..\..\test4.txt", @"..\..\..\test12.txt");//Create new file - test12.txt - a copy of test4.txt

        StreamReader origin = new StreamReader(@"..\..\..\test12.txt");
        StreamWriter temporary = new StreamWriter(@"..\..\..\test13.txt");

        using (origin)
        {
            using (temporary)
            {
                string line = origin.ReadLine();
                int lineNum = 1;
                while (line != null)
                {
                    if (lineNum % 2 == 0)
                    {
                        temporary.WriteLine(line);
                    }
                    line = origin.ReadLine();
                    lineNum++;
                }


            }
        }
        File.Replace(@"..\..\..\test13.txt", @"..\..\..\test12.txt", @"..\..\..\backup.txt");
        File.Delete(@"..\..\..\backup.txt");
        File.Delete(@"..\..\..\test13.txt");
        Console.WriteLine("Now look again the file test12.txt compare to test4.txt. All odd lines have disappeared");

    }
}
