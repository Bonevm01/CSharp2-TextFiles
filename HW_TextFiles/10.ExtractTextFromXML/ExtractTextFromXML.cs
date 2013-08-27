//10. Write a program that extracts from given XML file all the text without the tags. 

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ExtractTextFromXML
{
    static void Main(string[] args)
    {
        StreamReader originalFile = new StreamReader(@"..\..\..\XML.txt");
        using (originalFile)
        {
            Console.WriteLine("The text from the file XML.txt without the tags is:");
            string text = originalFile.ReadLine();
            string pattern = @">[^<]+</";
            Match match = Regex.Match(text, pattern);
            while (match.Success)
            {
                string textToPrint = match.ToString();
                textToPrint = textToPrint.Remove(textToPrint.Length - 2, 2);
                textToPrint = textToPrint.Remove(0, 1);
                Console.WriteLine(textToPrint);
                match = match.NextMatch();
            }
            
        }
    }
}
