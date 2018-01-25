using System;
using System.Collections.Generic;
using System.Linq;

//Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M.
//Hint: use a queue.
//Example: N = 5, M = 16
//Sequence: 5 → 7 → 8 → 16

namespace LinearDataStructuresHW
{
    class Program
    {
        private static Queue<LinkedList<int>> queue = new Queue<LinkedList<int>>();
        private static int end;

        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());

            var list = new LinkedList<int>();
            list.AddLast(start);
            queue.Enqueue(list);

            end = int.Parse(Console.ReadLine());

            GetBestSequence();

            Console.WriteLine(string.Join("-", queue.Last()));
        }

        static void GetBestSequence()
        {
            var currList = queue.Dequeue();
            var currListLastEl = currList.Last.Value;

            var firstList = GetNewList(currList, currListLastEl + 1);

            if (firstList.Last.Value < end)
            {
                queue.Enqueue(firstList);
            }
            else if (firstList.Last.Value == end)
            {
                queue.Enqueue(firstList);
                return;
            }

            var secondList = GetNewList(currList, currListLastEl + 2);
           
            if (secondList.Last.Value < end)
            {
                queue.Enqueue(secondList);
            }
            else if (secondList.Last.Value == end)
            {
                queue.Enqueue(secondList);
                return;
            }

            var thirdList = GetNewList(currList, currListLastEl * 2);

            if (thirdList.Last.Value < end)
            {
                queue.Enqueue(thirdList);
            }
            else if (thirdList.Last.Value == end)
            {
                queue.Enqueue(thirdList);
                return;
            }

            GetBestSequence();
        }

        private static LinkedList<int> GetNewList(LinkedList<int> currList, int nextEl)
        {
            var nextList = new LinkedList<int>(currList);
            nextList.AddLast(nextEl);

            return nextList;
        }
    }
}
