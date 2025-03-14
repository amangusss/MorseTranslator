using System;
using System.Collections.Generic;

class MorseTranslator {
    private static Dictionary<char, string> _morseMap = new Dictionary<char, string> {
        {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."},
        {'E', "."}, {'F', "..-."}, {'G', "--."}, {'H', "...."},
        {'I', ".."}, {'J', ".---"}, {'K', "-.-"}, {'L', ".-.."},
        {'M', "--"}, {'N', "-."}, {'O', "---"}, {'P', ".--."},
        {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
        {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"},
        {'Y', "-.--"}, {'Z', "--.."}, {' ', "/"}
    };

    public static void Main(string[] args) { 
        string input = "hello world !3 asd";
        string output = "";
        foreach (char c in input.ToUpper()) {
            output += _morseMap.ContainsKey(c) ? _morseMap[c] + " " : "incorrect symbol ";
        }
        Console.WriteLine(output.Trim());
        Console.ReadKey();
    }
}