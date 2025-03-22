namespace MorseTranslator {
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Threading;
    
    public class MorseTranslator {
        private static readonly Dictionary<char, string> BaseMap = new Dictionary<char, string> {
            {' ', "/"}, {'0', "-----"}, {'1', ".----"}, {'2', "..---"},
            {'3', "...--"}, {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."}, 
            {'8', "---.."}, {'9', "----."},
        };
        
        private static readonly Dictionary<char, string> EnglishMap = new Dictionary<char, string>(BaseMap) {
            {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
            {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
            {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"}, 
            {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
            {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"}, 
            {'Z', "--.."}
        };
        
        private static readonly Dictionary<char, string> RussianMap = new Dictionary<char, string>(BaseMap) {
            {'А', ".-"}, {'Б', "-..."}, {'В', ".--"}, {'Г', "--."}, {'Д', "-.."},
            {'Е', "."}, {'Ж', "...-"}, {'З', "--.."}, {'И', ".."}, {'Й', ".---"},
            {'К', "-.-"}, {'Л', ".-.."}, {'М', "--"}, {'Н', "-."}, {'О', "---"},
            {'П', ".--."}, {'Р', ".-."}, {'С', "..."}, {'Т', "-"}, {'У', "..-"},
            {'Ф', "..-."}, {'Х', "...."}, {'Ц', "-.-."}, {'Ч', "---."}, {'Ш', "----"},
            {'Щ', "--.-"}, {'Ы', "-.--"}, {'Э', "..-.."}, {'Ю', "..--"}, {'Я', ".-.-"}
        };

        public static string Translate(string text, string version) {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            if (string.IsNullOrEmpty(version)) return text;
            
            var upper = text.ToUpper();
            var selectedMap = version == "v0.2" || version == "v1.0" ? RussianMap : EnglishMap;
            var builder = new System.Text.StringBuilder();
            foreach (var c in upper) {
                if (selectedMap.TryGetValue(c, out var morse)) {
                    builder.Append(morse).Append(" ");
                }
                else if ((version == "v0.2" || version == "v1.0") && EnglishMap.TryGetValue(c, out morse)) {
                    builder.Append(morse).Append(" ");
                }
                else {
                    builder.Append(Constants.InvalidCharacter);
                }
            }
            return builder.ToString().Trim();
        }

        public static void Main(string[] args) {
            var fileManager = new FileManager();
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var inputPath = Path.Combine(baseDirectory, "input.txt");
            var outputPath = Path.Combine(baseDirectory, "output.txt");
            
            if (!fileManager.Exists(inputPath)) {
                Console.WriteLine(Constants.ErrorInputFile);
                Console.ReadKey();
                return;
            }

            var inputText = fileManager.Read(inputPath);
            Console.WriteLine(Constants.VersionPrompt);
            var version = Console.ReadLine();
            if (version != "v0.1" && version != "v0.2" && version != "v1.0") {
                Console.WriteLine(Constants.InvalidVersion);
                version = "v0.1";
            }
            var morse = Translate(inputText, version);
            fileManager.Write(outputPath, morse);
            Console.WriteLine(Constants.OutputCreated + outputPath);
            
            if (version == "v1.0") {
                var soundPlayer = new SoundPlayer();
                var soundThread = new Thread(() => soundPlayer.PlaySound(morse));
                soundThread.Start();
                soundThread.Join();
            }
            
            Console.ReadKey();
        }
    }   
}