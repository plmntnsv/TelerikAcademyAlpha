using System;
using System.Linq;

namespace LargesAreaInMatrix
{
    class Program
    {
        private static int max = 1;
        private static int count = 0;
        private static int[,] matrix;
        private static int[,] visited;
        private static int rows;
        private static int cols;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            rows = dimensions[0];
            cols = dimensions[1];
            matrix = new int[rows, cols];
            visited = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = nums[j];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (visited[row, col] != 1)
                    {
                        DFS(row, col, matrix[row, col]);
                    }

                    if (count > max)
                    {
                        max = count;
                    }

                    count = 0;
                }
            }

            Console.WriteLine(max);
        }

        static void DFS(int row, int col, int num)
        {
            bool outside = row < 0 || rows - 1 < row || col < 0 || cols - 1 < col;
            if (outside)
            {
                return;
            }

            if (visited[row, col] == 1)
            {
                return;
            }

            if (matrix[row, col] != num)
            {
                return;
            }

            visited[row, col] = 1;

            count++;

            DFS(row, col + 1, num);
            DFS(row + 1, col, num);
            DFS(row, col - 1, num);
            DFS(row - 1, col, num);
        }
    }
}
