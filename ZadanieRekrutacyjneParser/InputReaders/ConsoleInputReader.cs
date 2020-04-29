using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZadanieRekrutacyjneParser.InputReaders
{
    class ConsoleInputReader : IInputReader
    {
        public string Read()
        {
            Console.WriteLine("Enter One or more lines of text, when ready hit enter, hit ctrl+Z and hit enter again");
            StringBuilder stringBuilder = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                if (!line.Any())
                {
                    continue;
                }
                if (stringBuilder.Length != 0)
                {
                    stringBuilder.Append("\r\n");
                }
                stringBuilder.Append(line);
            }

            var input = stringBuilder.ToString();
            return input;
        }
    }
}
