namespace MorseTranslator {
    using System;
    using System.Threading;

    public class SoundPlayer {
        public void PlaySound(string morse) {
            foreach (var c in morse) {
                switch (c) {
                    case '.' : Console.Beep(850, 100); break;
                    case '-' : Console.Beep(850, 300); break;
                    case '/' : Thread.Sleep(350); break;
                    case ' ' : Thread.Sleep(100); break;
                }
            }
        }
    }
}