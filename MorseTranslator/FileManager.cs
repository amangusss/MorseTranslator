namespace MorseTranslator {

    using System.IO;

    public class FileManager
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public string Read(string path)
        {
            return File.ReadAllText(path);
        }

        public void Write(string path, string content)
        {
            File.WriteAllText(path, content);
        }
    }
}