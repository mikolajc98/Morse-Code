using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorseLib
{
    public static class MorseCode
    {
        #region Settings properties
        // [Hz] - frequency of "Beep" - same for dots and lines.
        private const int BeepFrequency = 650;

        // [ms] - duration of dot char. It's the basic unit of time measurement.
        private const int DotDuration = 75;

        // [ms] - duration of line char. At least 3 times the dot duration.
        private const int LineDuration = 3 * DotDuration;

        // [ms] - duration of space - between chars
        private const int SpacePauseDuration = 3 * DotDuration;

        // [ms] duration of tab - between words
        private const int TabPauseDuration = 7 * DotDuration;

        #endregion Settings properties

        private static Dictionary<char, string> _morseCodeDictionary;
        private static Dictionary<string, char> _invertedMorseCodeDictionary;

        private static Dictionary<char, string> MorseCodeDictionary
        {
            get
            {
                if (_morseCodeDictionary is null)
                    _morseCodeDictionary = CreateDictionary();

                return _morseCodeDictionary;
            }
        }

        private static Dictionary<string, char> InvertedMorseCodeDictionary
        {
            get
            {
                if (_invertedMorseCodeDictionary is null)
                    _invertedMorseCodeDictionary = CreateInvertedDictionary();

                return _invertedMorseCodeDictionary;
            }
        }

        private static Dictionary<string, char> CreateInvertedDictionary()
        {
            return MorseCodeDictionary.ToDictionary(x => x.Value, y => y.Key);
        }

        private static Dictionary<char, string> CreateDictionary()
        {
            return new Dictionary<char, string>()
            {
                {'a',   ".-"},
                {'b',   "-..."},
                {'c',   "-.-."},
                {'d',   "-.."},
                {'e',   "."},
                {'f',   "..-."},
                {'g',   "--."},
                {'h',   "...."},
                {'i',   ".."},
                {'j',   ".---"},
                {'k',   "-.-"},
                {'l',   ".-.."},
                {'m',   "--"},
                {'n',   "-."},
                {'o',   "---"},
                {'p',   ".--."},
                {'q',   "--.-"},
                {'r',   ".-."},
                {'s',   "..."},
                {'t',   "-"},
                {'u',   "..-"},
                {'v',   "...-"},
                {'w',   ".--"},
                {'x',   "-..-"},
                {'y',   "-.--"},
                {'z',   "--.."},
                {'ą',   ".-.-"},
                {'ć',   "-.-.."},
                {'ę',   "..-.."},
                {'ł',   ".-..-"},
                {'ń',   "--.--"},
                {'ó',   "---."},
                {'ś',   "...-..."},
                {'ż',   "--..-."},
                {'ź',   "--..-"},
                {'1',   ".----"},
                {'2',   "..---"},
                {'3',   "...--"},
                {'4',   "....-"},
                {'5',   "....."},
                {'6',   "-...."},
                {'7',   "--..."},
                {'8',   "---.."},
                {'9',   "----."},
                {'0',   "-----"},
                {'.',   ".-.-.-"},
                {',',   "--..--"},
                {'\'',  ".----."},
                {'"',   ".-..-."},
                {'_',   "..--.-"},
                {':',   "---..."},
                {';',   "-.-.-"},
                {'?',   "..--.."},
                {'!',   "-.-.--"},
                {'-',   "-....-"},
                {'+',   ".-.-."},
                {'/',   "-..-."},
                {'(',   "-.--."},
                {')',   "-.--.-"},
                {'=',   "-...-"},
                {'@',   ".--.-."},
                {' ',   "\t"},
                {'\0',    "" }
            };
        }

        public static Dictionary<char, string> GetMorseDictionary()
        {
            return MorseCodeDictionary;
        }

        public static Dictionary<string, char> GetInvertedDictionary()
        {
            return InvertedMorseCodeDictionary;
        }

        private static bool ValidateTextMsg(string textMessage, bool throwException = true)
        {
            foreach (var ch in textMessage.ToLower())
            {
                if (MorseCodeDictionary.ContainsKey(ch))
                    continue;
                else
                {
                    string errorMsg = $"Char {ch} is not allowed in input string!";
                    if (throwException)
                        throw new ArgumentOutOfRangeException(errorMsg);
                    return false;
                }
            }
            return true;
        }

        private static bool ValidateMorseMessage(string morseMessage, bool throwException = true)
        {
            foreach (var ch in morseMessage)
            {
                switch (ch)
                {
                    case '.':
                    case '-':
                    case ' ':
                    case '\t':
                        continue;
                    default:
                        string errorMsg = $"Char {ch} is not allowed in input string!";
                        if (throwException)
                            throw new ArgumentOutOfRangeException(errorMsg);
                        return false;
                }
            }
            return true;
        }

        public static string TranslateToMorse(string message)
        {
            if (ValidateTextMsg(message, false) == false)
            {
                return string.Empty;
            }

            StringBuilder resultBuilder = new StringBuilder();

            foreach (var ch in message.ToLower())
            {
                resultBuilder.Append(MorseCodeDictionary[ch] + " ");
            }

            return resultBuilder.ToString();
        }

        public static string TranslateToText(string morseMessage)
        {
            if (ValidateMorseMessage(morseMessage, false) == false)
            {
                return string.Empty;
            }

            StringBuilder resultBuilder = new StringBuilder();            

            foreach (var symbol in morseMessage.Split(' '))
            {
                resultBuilder.Append(InvertedMorseCodeDictionary[symbol]);
            }

            return resultBuilder.ToString();
        }

        public static void BeepMessage(string morseCodeMessage)
        {
            if (ValidateMorseMessage(morseCodeMessage, false) == false)
            {
                return;
            }

            foreach (var ch in morseCodeMessage)
            {
                switch (ch)
                {
                    case '.':
                        Console.Beep(BeepFrequency, DotDuration);
                        System.Threading.Thread.Sleep(DotDuration);
                        break;
                    case '-':
                        Console.Beep(BeepFrequency, LineDuration);
                        System.Threading.Thread.Sleep(DotDuration);
                        break;
                    case ' ':
                        System.Threading.Thread.Sleep(SpacePauseDuration);
                        break;
                    case '\t':
                        System.Threading.Thread.Sleep(TabPauseDuration);
                        break;
                }
            }
        }
    }
}
