//5. Write a program that reads a text file containing a square matrix of numbers and finds in the matrix
//  an area of size 2 x 2 with a maximal sum of its elements. The first line in the input file contains the size of matrix N.
//  Each of the next N lines contain N numbers separated by space. The output should be a single number in a separate text file. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _5.ReadMatrix
{
    class ReadMatrix
    {
        static void Main(string[] args)
        {
            StreamReader input = new StreamReader(@"..\..\..\test6.txt");
            int[,] matrix = new int[1, 1];
            using (input)
            {
                int matrixSize = int.Parse(input.ReadLine());
                matrix = new int[matrixSize, matrixSize];
                string nextLines = input.ReadLine();
                int row = 0;
                while (nextLines != null)
                {
                    string[] elements = nextLines.Split(' ');
                    for (int i = 0; i < matrixSize; i++)
                    {
                        matrix[row, i] = int.Parse(elements[i]);
                    }
                    row++;
                    nextLines = input.ReadLine();
                }

            }
            int bestSum = int.MinValue;
            int bestStartsAtX = 0;
            int bestStartsAtY = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = 0;
                    sum += matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestStartsAtX = row;
                        bestStartsAtY = col;

                    }
                }
            }
            Console.WriteLine("The matrix looks:");
            PrintMatrix(matrix);

            Console.WriteLine();
            Console.WriteLine("The zone 2x2 in you matrix with best sum is:");
            for (int i = bestStartsAtX; i < bestStartsAtX + 2; i++)
            {
                for (int j = bestStartsAtY; j < bestStartsAtY + 2; j++)
                {
                    Console.Write("{0,4}", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("The sum of this subMatrix is {0} and it was saved in the file test7.txt", bestSum);
            Console.WriteLine("You could find it in HW_TextFiles\\");
            StreamWriter outputFile = new StreamWriter(@"..\..\..\test7.txt");
            using (outputFile)
            {
                outputFile.WriteLine(bestSum);
            }

        }

        static void PrintMatrix(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0,4}", arr[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
