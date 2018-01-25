using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = input[0], cols = input[1], beers = input[2];

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < beers; i++)
            {
                int[] beerCoord  = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                matrix[beerCoord[0], beerCoord[1]] = -6;
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {

                }
            }
        }
    }
}
