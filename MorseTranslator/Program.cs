using System;
using System.Collections.Generic;
using System.IO;

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

    public static void Main(string[] args) {
        string inputPath = "input.txt";
        string outputPath = "output.txt";
        
        if (!File.Exists(inputPath)) {
            Console.WriteLine("The file input.txt not found!");
            Console.ReadKey();
            return;
        }

        string inputText = File.ReadAllText(inputPath);
        string morse = Translate(inputText);
        File.WriteAllText(outputPath, morse);
        Console.WriteLine("Result recorded in " + outputPath);
        Console.ReadKey();
    }
}