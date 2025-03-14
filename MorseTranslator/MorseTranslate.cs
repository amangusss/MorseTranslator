namespace MorseTranslator {
    
    using System;
    using System.Collections.Generic;
    using System.Threading;
    
    public class MorseTranslator {
        private static Dictionary<char, string> _englishMap = new Dictionary<char, string> {
            {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."},
            {'E', "."}, {'F', "..-."}, {'G', "--."}, {'H', "...."},
            {'I', ".."}, {'J', ".---"}, {'K', "-.-"}, {'L', ".-.."},
            {'M', "--"}, {'N', "-."}, {'O', "---"}, {'P', ".--."},
            {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
            {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"},
            {'Y', "-.--"}, {'Z', "--.."}, {' ', "/"}
        };
        
        private static Dictionary<char, string> _russianMap = new Dictionary<char, string> {
            {'А', ".-"}, {'Б', "-..."}, {'В', ".--"}, {'Г', "--."}, {'Д', "-.."},
            {'Е', "."}, {'Ж', "...-"}, {'З', "--.."}, {'И', ".."}, {'Й', ".---"},
            {'К', "-.-"}, {'Л', ".-.."}, {'М', "--"}, {'Н', "-."}, {'О', "---"},
            {'П', ".--."}, {'Р', ".-."}, {'С', "..."}, {'Т', "-"}, {'У', "..-"},
            {'Ф', "..-."}, {'Х', "...."}, {'Ц', "-.-."}, {'Ч', "---."}, {'Ш', "----"},
            {'Щ', "--.-"}, {'Ы', "-.--"}, {'Э', "..-.."}, {'Ю', "..--"}, {'Я', ".-.-"},
            {' ', "/"}
        };

        private static string Translate(string text, string version) {
            string output = "";
            string upper = text.ToUpper();
            if (version == "v0.2" || version == "v1.0") {
                foreach (char c in upper) {
                    if (_russianMap.ContainsKey(c))
                        output += _russianMap[c] + " ";
                    else if (_englishMap.ContainsKey(c))
                        output += _englishMap[c] + " ";
                    else
                        output += Constants.InvalidCharacter;
                }
            }
            else {
                foreach (char c in upper) {
                    output += _englishMap.ContainsKey(c) ? _englishMap[c] + " " : Constants.InvalidCharacter;
                }
            }
            return output.Trim();
        }

        public static void Main(string[] args) {
            FileManager fileManager = new FileManager();
            string inputPath = "input.txt";
            string outputPath = "output.txt";
            
            if (!fileManager.Exists(inputPath)) {
                Console.WriteLine(Constants.ErrorInputFile);
                Console.ReadKey();
                return;
            }

            string inputText = fileManager.Read(inputPath);
            Console.WriteLine(Constants.VersionPrompt);
            string version = Console.ReadLine();
            if (version != "v0.1" && version != "v0.2" && version != "v1.0") {
                Console.WriteLine(Constants.InvalidVersion);
                version = "v0.1";
            }
            string morse = Translate(inputText, version);
            fileManager.Write(outputPath, morse);
            Console.WriteLine(Constants.OutputCreated + outputPath);
            
            if (version == "v1.0") {
                SoundPlayer soundPlayer = new SoundPlayer();
                Thread soundThread = new Thread(() => soundPlayer.PlaySound(morse));
                soundThread.Start();
                soundThread.Join();
            }
            
            Console.ReadKey();
        }
    }   
}