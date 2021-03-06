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
            MorseCode.BeepMessage(msgTranslatedToMorse);

            Console.ReadLine();
        }
    }
}
