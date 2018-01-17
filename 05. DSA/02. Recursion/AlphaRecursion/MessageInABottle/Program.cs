using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageInABottle
{
    class Program
    {
        private static Dictionary<string, string> messageCypher;
        private static List<string> result = new List<string>();        

        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string code = Console.ReadLine();

            messageCypher = new Dictionary<string, string>();

            var currLetterCode = new StringBuilder();
            string currLetter = "A";
            bool shouldAdd = false;
            int index = 0;

            while (index < code.Length)
            {
                if (char.IsLetter(code[index]) && !shouldAdd)
                {
                    currLetter = code[index].ToString();
                    shouldAdd = true;
                    index++;
                }
                else if (char.IsDigit(code[index]))
                {
                    currLetterCode.Append(code[index]);
                    index++;
                }
                else if (shouldAdd)
                {
                    messageCypher.Add(currLetterCode.ToString(), currLetter);
                    currLetterCode.Clear();
                    shouldAdd = false;
                }
            }

            if (shouldAdd)
            {
                messageCypher.Add(currLetterCode.ToString(), currLetter);
            }

            foreach (var cypherElement in messageCypher)
            {
                if (message.StartsWith(cypherElement.Key))
                {
                    GetMessage(message.Remove(0, cypherElement.Key.Length), cypherElement.Value);
                }
            }

            Console.WriteLine(result.Count);
            result.Sort();
            foreach (var res in result)
            {
                Console.WriteLine(res);
            }
        }

        static void GetMessage(string restOfMessage, string decodedMessage)
        {
            if (restOfMessage.Length == 0)
            {
                result.Add(decodedMessage);
            }

            foreach (var messageElement in messageCypher)
            {
                if (restOfMessage.StartsWith(messageElement.Key))
                {
                    GetMessage(restOfMessage.Remove(0, messageElement.Key.Length), decodedMessage + messageElement.Value);
                }
            }
        }
    }
}
