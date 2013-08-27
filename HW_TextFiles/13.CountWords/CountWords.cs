//13. Write a program that reads a list of words from a file words.txt and finds how many times each of the words is contained 
//  in another file test.txt. The result should be written in the file result.txt and the words should be sorted by the number 
//  of their occurrences in descending order. 

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class CountWords
{

    static void Main()
    {
        Console.WriteLine("The following code will count words from the file forbidenWords in the file test25.");
        List<string> wordsToBeCounted = new List<string>();
        //Save words that will be counted in a list
        StreamReader forbWords = new StreamReader(@"..\..\..\forbiddenWords.txt");
        using (forbWords)
        {
            string line = forbWords.ReadLine();
            while (line != null)
            {
                string[] words = line.Split(new char[] { ',', ':', ';', '?', '!', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    wordsToBeCounted.Add(words[i]);
                }
                line = forbWords.ReadLine();
            }

        }

        //Convert the list to an array
        string[] word = wordsToBeCounted.ToArray();
        int[] counts = new int[word.Length];
        //Count words in an original file
        StreamReader originalFile = new StreamReader(@"..\..\..\test25.txt");
        using (originalFile)
        {

            string line = originalFile.ReadLine();
            while (line != null)
            {
                for (int i = 0; i < counts.Length; i++)
                {
                    string sample = @"\b" + word[i] + @"\b";
                    Match match = Regex.Match(line, sample);
                    while (match.Success)
                    {
                        counts[i]++;
                        match = match.NextMatch();
                    }
                }

                line = originalFile.ReadLine();
            }

        }

        Array.Sort(counts, word);
        Array.Sort(counts);

        //Save the sorted words in a new file
        StreamWriter result = new StreamWriter(@"..\..\..\result.txt");
        using (result)
        {
            for (int i = counts.Length - 1; i >= 0; i--)
            {
                result.WriteLine(word[i] + " ---> " + counts[i] + " times.");
            }
        }

        Console.WriteLine("Please check files: forbidenWords, test25 and result.");

    }
}

