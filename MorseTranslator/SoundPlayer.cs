namespace MorseTranslator {
    using System;
    using System.Threading;

    public class SoundPlayer {
        public void PlaySound(string morse) {
            foreach (char c in morse) {
                if (c == '.')
                    Console.Beep(850, 100);
                else if (c == '-')
                    Console.Beep(850, 300);
                else if (c == '/')
                    Thread.Sleep(400);
                else if (c == ' ')
                    Thread.Sleep(100);
            }
        }
    }

}