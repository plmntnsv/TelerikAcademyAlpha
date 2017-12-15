using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// http://judge.telerikacademy.com/problem/30kitty
namespace Kitty
{
    class Kitty
    {
        static void Main(string[] args)
        {
            char soul = '@';
            int soulsCollected = 0;
            char food = '*';
            int foodCollected = 0;
            char deadlock = 'x';
            int deadlocksCollected = 0;

            int jumps = 0;

            char[] field = Console.ReadLine().ToCharArray();
            int[] moves = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int currPos = 0;

            for (int i = 0; i <= moves.Length; i++)
            {
                if (field[currPos] == deadlock)
                {
                    if (currPos % 2 == 0)
                    {
                        if (soulsCollected > 0)
                        {
                            deadlocksCollected++;
                            soulsCollected--;
                            field[currPos] = '@';
                        }
                        else
                        {
                            Console.WriteLine("You are deadlocked, you greedy kitty!\nJumps before deadlock: {0}", jumps);
                            return;
                        }
                    }
                    else
                    {
                        if (foodCollected > 0)
                        {
                            deadlocksCollected++;
                            foodCollected--;
                            field[currPos] = '*';
                        }
                        else
                        {
                            Console.WriteLine("You are deadlocked, you greedy kitty!\nJumps before deadlock: {0}", jumps);
                            return;
                        }
                    }
                }
                else if (field[currPos] == food)
                {
                    field[currPos] = ' ';
                    foodCollected++;
                }
                else if (field[currPos] == soul)
                {
                    field[currPos] = ' ';
                    soulsCollected++;
                }

                if (i == moves.Length)
                {
                    break;
                }

                currPos = FindNextIndex(moves[i], field.Length, currPos);
                jumps++;
            }

            Console.WriteLine("Coder souls collected: {0}\nFood collected: {1}\nDeadlocks: {2}", soulsCollected, foodCollected, deadlocksCollected);
        }

        public static int FindNextIndex(int moves, int size, int currentIndex)
        {
            int index = moves % size + currentIndex;

            if (index < 0)
            {
                index += size;
            }
            else if (index > size - 1)
            {
                index -= size;
            }

            return index;
        }
    }
}
