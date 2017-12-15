using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
//http://judge.telerikacademy.com/problem/31bitshiftmatrix
namespace Task1
{
    class BitShiftMatrix
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int moves = int.Parse(Console.ReadLine());
            int[] codes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int coef = Math.Max(rows, cols);
            int[,] field = new int[rows, cols];
            int row = rows - 1;
            int col = 0;
            BigInteger result = 0;

            for (int i = 0; i < moves; i++)
            {
                int targetRow = codes[i] / coef;
                int targetCol = codes[i] % coef;
                int steps = Math.Abs((targetRow - row)) + Math.Abs((targetCol - col));

                for (int j = 0; j < steps + 1; j++)
                {
                    if (field[row, col] == 0)
                    {
                        result += (BigInteger)Math.Pow(2, rows - 1 - row + col);
                        field[row, col] = 1;
                    }

                    if (targetCol > col)
                    {
                        col++;
                    }
                    else if (targetCol < col)
                    {
                        col--;
                    }
                    else if (targetRow > row)
                    {
                        row++;
                    }
                    else if (targetRow < row)
                    {
                        row--;
                    }
                }
            }

            //Console.WriteLine(result);
            PrintMatrix(field);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(string.Format("{0, -5}", matrix[row, col]));
                }
                Console.WriteLine();
            }
        }
    }
}
