namespace MorseTranslator {
    
    using System;
    using System.Collections.Generic;

    public class MorseTranslator {
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
                output += _morseMap.ContainsKey(c) ? _morseMap[c] + " " : "incorrect character ";
            }
            return output.Trim();
        }

        public static void Main(string[] args) {
            FileManager fileManager = new FileManager();
            string inputPath = "input.txt";
            string outputPath = "output.txt";
            
            if (!fileManager.Exists(inputPath)) {
                Console.WriteLine("The file input.txt not found!");
                Console.ReadKey();
                return;
            }

            string inputText = fileManager.Read(inputPath);
            string morse = Translate(inputText);
            fileManager.Write(outputPath, morse);
            Console.WriteLine("Result recorded in " + outputPath);
            Console.ReadKey();
        }
    }   
}