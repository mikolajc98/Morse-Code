using System;
using MorseLib;

namespace MorseConsoleShowcase
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = "Hello World";
            string msgTranslatedToMorse = MorseCode.TranslateToMorse(msg);

            Console.WriteLine(msg);
            Console.WriteLine(msgTranslatedToMorse);

            Console.WriteLine();

            string msgMorse = "... --- ... \t ... --- ..."; // < '\t' is treated as space between word. This string will be converted into "sos sos". The same rule applies when using TranslateToMorse(string).

            string msgTranslatedToASCII = MorseCode.TranslateToText(msgMorse);

            Console.WriteLine(msgMorse);
            Console.WriteLine(msgTranslatedToASCII);

            Console.ReadLine();
        }
    }
}
