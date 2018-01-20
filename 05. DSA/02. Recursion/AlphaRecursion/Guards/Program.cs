using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guards
{
    class Program
    {
        private static int[,] matrix;
        private static int rows;
        private static int cols;
        private static int bestTime = int.MaxValue;

        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            rows = matrixDimensions[0];
            cols = matrixDimensions[1];
            matrix = new int[rows, cols];
            int guardsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < guardsCount; i++)
            {
                string[] guardPosition = Console.ReadLine().Split(' ');
                int guardRow = int.Parse(guardPosition[0]);
                int guardCol = int.Parse(guardPosition[1]);
                string guardDir = guardPosition[2];
                matrix[guardRow, guardCol] = -1;

                switch (guardDir)
                {
                    case "U":
                        if (guardRow == 0)
                        {
                            break;
                        }
                        matrix[guardRow - 1, guardCol] = 2;
                        break;
                    case "D":
                        if (guardRow == rows - 1)
                        {
                            break;
                        }
                        matrix[guardRow + 1, guardCol] = 2;
                        break;
                    case "L":
                        if (guardCol == 0)
                        {
                            break;
                        }
                        matrix[guardRow, guardCol - 1] = 2;
                        break;
                    case "R":
                        if (guardCol == cols - 1)
                        {
                            break;
                        }
                        matrix[guardRow, guardCol + 1] = 2;
                        break;
                }
            }

            DFS(0, 0, 0);

            if (bestTime == int.MaxValue)
            {
                Console.WriteLine("Meow");
            }
            else
            {
                Console.WriteLine(bestTime);
            }

            bestTime = int.MaxValue;

            Iterative();

            if (bestTime == int.MaxValue)
            {
                Console.WriteLine("Meow");
            }
            else
            {
                Console.WriteLine(bestTime);
            }
        }

        static void Iterative()
        {
            var stack = new Stack<int[]>();
            stack.Push(new int[] { 0, 0, 0 });

            while (stack.Count > 0)
            {
                var cell = stack.Pop();
                var row = cell[0];
                var col = cell[1];
                var time = cell[2];

                bool outside = row < 0 || rows - 1 < row || col < 0 || cols - 1 < col;

                if (outside)
                {
                    continue;
                }

                bool exitCell = row == rows - 1 && col == cols - 1;

                if (exitCell)
                {
                    time++;
                    if (time < bestTime)
                    {
                        bestTime = time;
                    }

                    continue;
                }

                bool guardCell = matrix[row, col] < 0;

                if (guardCell)
                {
                    continue;
                }

                time += matrix[row, col] + 1;

                if (time > bestTime)
                {
                    continue;
                }

                stack.Push(new int[] { row + 1, col, time });
                stack.Push(new int[] { row, col + 1, time });
            }
        }

        static void DFS(int row, int col, int time)
        {
            bool outside = row < 0 || rows - 1 < row || col < 0 || cols - 1 < col;

            if (outside)
            {
                return;
            }

            bool exitCell = row == rows - 1 && col == cols - 1;

            if (exitCell)
            {
                time++;
                if (time < bestTime)
                {
                    bestTime = time;
                }
                return;
            }

            bool guardCell = matrix[row, col] < 0;

            if (guardCell)
            {
                return;
            }

            time += matrix[row, col] + 1;

            if (time > bestTime)
            {
                return;
            }

            DFS(row, col + 1, time);
            DFS(row + 1, col, time);
        } 
    }
}
