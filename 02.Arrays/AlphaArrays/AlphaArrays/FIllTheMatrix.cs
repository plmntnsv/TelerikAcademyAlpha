using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaArrays
{
    class FIllTheMatrix
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int ch = Console.Read();

            switch (ch)
            {
                case 'a':
                    FillMatrixCaseA(n);
                    break;
                case 'b':
                    FillMatrixCaseB(n);
                    break;
                case 'c':
                    FillMatrixCaseC(n);
                    break;
                case 'd':
                    FillMatrixCaseD(n);
                    break;
                default:
                    break;
            }
        }

        static void FillMatrixCaseA(int n)
        {
            int[,] matrix = new int[n, n];
            int counter = 1;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    matrix[col, row] = counter;
                    counter++;
                }
            }

            DisplayMatrix(matrix);
        }

        static void FillMatrixCaseB(int n)
        {
            int[,] matrix = new int[n, n];
            int counter = 1;

            for (int col = 0; col < n; col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < n; row++)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
                else
                {
                    for (int row = n - 1; 0 <= row; row--)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
            }

            DisplayMatrix(matrix);
        }

        static void FillMatrixCaseC(int n)
        {
            int[,] matrix = new int[n, n];
            int counter = 1;
            int col = 0;
            int row = n - 1;
            int edge = n - 1;

            while (counter <= n * n)
            {
                matrix[row, col] = counter;
                counter++;

                if (row + 1 > edge && col + 1 <= edge)
                {
                    row = (n - 1) - (col + 1);
                    col = 0;
                }
                else if ((row + 1 > edge || row + 1 <= edge) && col + 1 > edge)
                {
                    col = (n - 1 - row) + 1;
                    row = 0;
                }
                else
                {
                    row++;
                    col++;
                }
            }

            DisplayMatrix(matrix);
        }

        static void FillMatrixCaseD(int n)
        {
            int[,] matrix = new int[n, n];
            int counter = 1;
            int rotations = n * n;
            string dir = "down";
            int edge = n - 1;
            int row = 0;
            int col = 0;

            while(counter <= rotations)
            {
                if (dir == "down" && row <= edge && matrix[row, col] == 0)
                {
                    matrix[row, col] = counter;
                    counter++;
                    row++;
                }
                else if (dir == "down")
                {
                    row--;
                    col++;
                    dir = "right";
                }

                if (dir == "right" && col <= edge && matrix[row, col] == 0)
                {
                    matrix[row, col] = counter;
                    counter++;
                    col++;
                }
                else if (dir == "right")
                {
                    col--;
                    row--;
                    dir = "up";
                }

                if (dir == "up" && row >= 0 && matrix[row, col] == 0)
                {
                    matrix[row, col] = counter;
                    counter++;
                    row--;
                }
                else if (dir == "up")
                {
                    row++;
                    col--;
                    dir = "left";
                }

                if (dir == "left" && col >= 0 && matrix[row, col] == 0)
                {
                    matrix[row, col] = counter;
                    counter++;
                    col--;
                }
                else if (dir == "left")
                {
                    col++;
                    row++;
                    dir = "down";
                }
            }

            DisplayMatrix(matrix);
        }

        static void DisplayMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == matrix.GetLength(1)-1)
                    {
                        Console.Write(matrix[i, j]);
                        continue;
                    }
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
