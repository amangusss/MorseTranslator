using System;
using System.Collections.Generic;

class MorseTranslator {
    static Dictionary<char, string> _morseMap = new Dictionary<char, string> {
        {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."},
        {'E', "."}, {'F', "..-."}, {'G', "--."}, {'H', "...."},
        {'I', ".."}, {'J', ".---"}, {'K', "-.-"}, {'L', ".-.."},
        {'M', "--"}, {'N', "-."}, {'O', "---"}, {'P', ".--."},
        {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
        {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"},
        {'Y', "-.--"}, {'Z', "--.."}, {' ', "/"}
    };

    private static string Translate(string text) {
        string output = "";
        foreach (char c in text.ToUpper()) {
            output += _morseMap.ContainsKey(c) ? _morseMap[c] + " " : "? ";
        }
        return output.Trim();
    }

    static void Main(string[] args) {
        Console.WriteLine(Translate("hello world"));
        Console.ReadKey();
    }
}