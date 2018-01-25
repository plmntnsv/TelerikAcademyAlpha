using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slogan
{
    class Program
    {
        private static List<string> finalSlogans = new List<string>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string slogan = Console.ReadLine();
                List<string> impossibleSlogans = new List<string>();

                int count = finalSlogans.Count;

                foreach (var word in words)
                {
                    if (finalSlogans.Count > count)
                    {
                        break;
                    }

                    if (slogan.StartsWith(word))
                    {
                        var currentSlogan = new List<string>();
                        currentSlogan.Add(word);
                        GetSlogan(slogan.Remove(0, word.Length), currentSlogan, impossibleSlogans, words, count);
                    }
                }

                if (count == finalSlogans.Count)
                {
                    finalSlogans.Add("NOT VALID");
                }
            }

            foreach (var s in finalSlogans)
            {
                Console.WriteLine(s);
            }
        }

        static void GetSlogan(string slogan, List<string> currentSlogan, List<string> impossibleSlogans, string[] words, int count)
        {
            if (finalSlogans.Count > count || impossibleSlogans.Contains(slogan))
            {
                return;
            }

            if (slogan.Length == 0)
            {
                finalSlogans.Add(string.Join(" ", currentSlogan));
                return;
            }

            foreach (var word in words)
            {
                if (slogan.StartsWith(word))
                {
                    currentSlogan.Add(word);
                    GetSlogan(slogan.Remove(0, word.Length), currentSlogan, impossibleSlogans, words, count);
                    currentSlogan.RemoveAt(currentSlogan.Count - 1);
                }

                if (word == words[words.Length - 1])
                {
                    impossibleSlogans.Add(slogan);
                }
            }
        }
    }
}
