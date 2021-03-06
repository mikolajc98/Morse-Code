# Morse-Code Library

Morse Code Lib is small project that allows to convert ASCII text to morse code and vice versa.

Specs:<br/>
.NET Framework version: 3.5 



There are few information about Morse code "standards" - according to [International Morse code PDF](https://www.itu.int/dms_pubrec/itu-r/rec/m/R-REC-M.1677-1-200910-I!!PDF-E.pdf):

Dot duration - basic unit of time. The only one configurable. [In code it is marked as "DotDuration" set to 75 miliseconds]<br/>
Dash is equal to three dots. [In code it is marked as "LineDuration"]<br/>
Space between the signals forming the same letter is equal to one dot. [Simply - "DotDuration" in code]<br/>
Space between two letters is equal to three dots. [In code it is marked as "SpacePauseDuration"]<br/>
Space between two words is equal to seven dots. [In code it is marked as "TabPauseDuration"]<br/>
There is no distinction between 'a' and 'A'. So, for simplification - everything inside library is modified by "ToLower()" method


## Basics:
```
string msg = "Hello World";
string msgTranslatedToMorse = MorseCode.TranslateToMorse(msg);

Console.WriteLine(msg);
Console.WriteLine(msgTranslatedToMorse);

Console.WriteLine();

string msgMorse = "... --- ... \t ... --- ..."; // < '\t' is treated as space between word. This string will be converted into "sos sos". The same rule applies when using TranslateToMorse(string).

string msgTranslatedToASCII = MorseCode.TranslateToText(msgMorse);

Console.WriteLine(msgMorse); 
Console.WriteLine(msgTranslatedToASCII);

// This example displays following output:
//Hello World
//.... . .-.. .-.. ---     .-- --- .-. .-.. -..
//
//... --- ...      ... --- ...
//sos sos

```
