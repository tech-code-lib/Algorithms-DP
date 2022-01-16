using System;

namespace MaximumSizeSubSquareMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] M = new int[6, 5]{
                    {0, 1, 1, 0, 1},
                    {1, 1, 0, 1, 0},
                    {0, 1, 1, 1, 0},
                    {1, 1, 1, 1, 0},
                    {1, 1, 1, 1, 1},
                    {0, 0, 0, 0, 0}};

            printMaxSizeSubSquare(M);
        }

        static void printMaxSizeSubSquare(int[,] M)
        {
            int[,] subMatrix = new int[M.GetLength(0), M.GetLength(1)];
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    subMatrix[i, j] = M[i, j];
                }
            }

            for (int i = 1; i < M.GetLength(0); i++)
            {
                for (int j = 1; j < M.GetLength(1); j++)
                {
                    if (M[i, j] == 0)
                        subMatrix[i, j] = 0;
                    else
                    {
                        var v = Math.Min(Math.Min(subMatrix[i - 1, j], subMatrix[i - 1, j - 1]), subMatrix[i, j - 1]) + 1;
                        subMatrix[i, j] = v;
                    }
                }
            }

            int maxLen = 0;
            int maxI = 0;
            int maxJ = 0;
            int maxVal = 0;
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    maxLen = Math.Max(maxLen, subMatrix[i, j]);
                    if (maxVal < maxLen)
                    {
                        maxVal = maxLen;
                        maxI = i;
                        maxJ = j;
                    }
                }
            }

            Console.WriteLine(maxVal);
            Console.WriteLine(subMatrix[maxI, maxJ]);

            for (int i = maxI-maxVal+1; i <= maxI; i++)
            {
                for (int j = maxJ - maxVal+1; j <= maxJ; j++)
                {
                    Console.Write($"{M[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
