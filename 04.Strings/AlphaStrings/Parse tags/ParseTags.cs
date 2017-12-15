using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parse_tags
{
    class ParseTags
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string openEl = "<upcase>";
            string closeEl = "</upcase>";

            int openElStart = text.IndexOf(openEl);
            int closeElStart = text.IndexOf(closeEl);
            int start = 0;
            int end = openElStart + openEl.Length;
            StringBuilder finalText = new StringBuilder();

            if (openElStart == -1)
            {
                Console.WriteLine(text);
                return;
            }

            while (openElStart != -1)
            {
                finalText.Append(Extract(start, openElStart, text, false));
                finalText.Append(Extract(openElStart + openEl.Length, closeElStart, text, true));

                start = closeElStart + closeEl.Length;
                openElStart = text.IndexOf(openEl, openElStart + 1);
                closeElStart = text.IndexOf(closeEl, closeElStart + 1);

                if (openElStart == -1)
                {
                    finalText.Append(Extract(start, text.Length, text, false));
                }
            }

            Console.WriteLine(finalText);
        }

        static StringBuilder Extract(int start, int end, string text, bool toUpper)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = start; i < end; i++)
            {
                if (toUpper)
                {
                    sb.Append(text[i].ToString().ToUpper());
                }
                else
                {
                    sb.Append(text[i]);
                }
            }

            return sb;
        }
    }
}
