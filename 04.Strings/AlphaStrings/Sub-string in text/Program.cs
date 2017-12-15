using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sub_string_in_text
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine().ToLower();
            string text = Console.ReadLine().ToLower();

            int count = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == pattern[0])
                {
                    bool same = true;

                    for (int j = 1; j < pattern.Length; j++)
                    {
                        if (i + pattern.Length > text.Length)
                        {
                            same = false;
                            break;
                        }

                        if (text[i + j] != pattern[j])
                        {
                            same = false;
                        }
                    }

                    if (same)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
