//12. Write a program that removes from a text file all words listed in given another text file.
//  Handle all possible exceptions in your methods.


using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class RemoveListOfWords
{
    static List<string> wordsToBeDeleted = new List<string>();
    static void Main()
    {
        Console.WriteLine("The following code will remove all words from the file forbiddenWords in the text saved in file - test21.");
        //Save forbiden words in a list
        try
        {
            SaveWordsInAList();
        }
        catch (Exception exp)
        {

            Console.WriteLine(exp.Message);
        }

        //Remove forbiden words from a text file
        try
        {
            RemoveForbWords();
        }
        catch (Exception exp)
        {

            Console.WriteLine(exp.Message);
        }


        Console.WriteLine("Please check the files forbiddenWords, test21 and test22.");
    }

    private static void RemoveForbWords()
    {
        StreamReader originalFile = new StreamReader(@"..\..\..\test21.txt");
        StreamWriter outputFile = new StreamWriter(@"..\..\..\test22.txt");
        using (originalFile)
        {
            using (outputFile)
            {
                string line = originalFile.ReadLine();
                while (line != null)
                {
                    foreach (string words in wordsToBeDeleted)
                    {
                        string sample = @"\b" + words + @"\b";
                        line = Regex.Replace(line, sample, "");
                    }
                    outputFile.WriteLine(line);
                    line = originalFile.ReadLine();
                }
            }

        }
    }


    private static void SaveWordsInAList()
    {
        StreamReader forbWords = new StreamReader(@"..\..\..\forbiddenWords.txt");
        using (forbWords)
        {
            string line = forbWords.ReadLine();
            while (line != null)
            {
                string[] words = line.Split(new char[] { ',', ':', ';', '?', '!', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    wordsToBeDeleted.Add(words[i]);
                }
                line = forbWords.ReadLine();
            }

        }
    }
}
