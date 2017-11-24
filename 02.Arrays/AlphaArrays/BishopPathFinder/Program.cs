using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BishopPathFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] field = new int[rows, cols];

            long result = 0;
            int row = field.GetLength(0) - 1;
            int col = 0;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ');
                string direction = command[0];
                int moves = int.Parse(command[1]);

                if (direction == "RU" || direction == "UR")
                {
                    for (int j = 0; j < moves; j++)
                    {
                        if (row < 0 || col > cols - 1)
                        {
                            row++;
                            col--;
                            break;
                        }

                        if (field[row, col] == 0)
                        {
                            result += (col + (rows - row - 1)) * 3;
                            field[row, col] = -1;
                        }

                        if (j != moves - 1)
                        {
                            row--;
                            col++;
                        }

                        
                    }
                }

                if (direction == "LU" || direction == "UL")
                {
                    for (int j = 0; j < moves; j++)
                    {
                        if (row < 0 || col < 0)
                        {
                            row++;
                            col++;
                            break;
                        }

                        if (field[row, col] == 0)
                        {
                            result += (col + (rows - row - 1)) * 3;
                            field[row, col] = -1;
                        }

                        if (j != moves - 1)
                        {
                            row--;
                            col--;
                        }
                    }
                }

                if (direction == "LD" || direction == "DL")
                {
                    for (int j = 0; j < moves; j++)
                    {
                        if (row > rows - 1 || col < 0)
                        {
                            row--;
                            col++;
                            break;
                        }

                        if (field[row, col] == 0)
                        {
                            result += (col + (rows - row - 1)) * 3; 
                            field[row, col] = -1;
                        }

                        if (j != moves - 1)
                        {
                            row++;
                            col--;
                        }
                    }
                }

                if (direction == "RD" || direction == "DR")
                {
                    for (int j = 0; j < moves; j++)
                    {
                        if (row > rows - 1 || col > cols - 1)
                        {
                            row--;
                            col--;
                            break;
                        }

                        if (field[row, col] == 0)
                        {
                            result += (col + (rows - row - 1)) * 3;
                            field[row, col] = -1;
                        }

                        if (j != moves - 1)
                        {
                            row++;
                            col++;
                        }
                    }
                }
            }

            Console.WriteLine(result);
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == matrix.GetLength(1) - 1)
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
