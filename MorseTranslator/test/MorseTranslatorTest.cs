namespace MorseTranslator.test {
    using NUnit.Framework;

    [TestFixture]
    public class MorseTranslatorTest {
        [Test]
        public void TestEnglishTranslation() {
            var result = MorseTranslator.Translate("SOS", "v0.1");
            Assert.That(result, Is.EqualTo("... --- ..."));
        }

        [Test]
        public void TestRussianTranslation() {
            var result = MorseTranslator.Translate("СОС", "v0.2");
            Assert.That(result, Is.EqualTo("... --- ..."));
        }

        [Test]
        public void TestLowerCaseInput() {
            var result = MorseTranslator.Translate("sos", "v0.1");
            Assert.That(result, Is.EqualTo("... --- ..."));
        }

        [Test]
        public void TestMixedLanguageInput() {
            var input = "HELLO ПРИВЕТ";
            var expected = ".... . .-.. .-.. --- / .--. .-. .. .-- . -";
            var result = MorseTranslator.Translate(input, "v0.2");
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestInvalidCharacters() {
            var result = MorseTranslator.Translate("ABC@", "v0.1");
            Assert.That(result.Trim(), Does.EndWith(Constants.InvalidCharacter));
        }

        [Test]
        public void TestEmptyString() {
            var result = MorseTranslator.Translate("", "v0.1");
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void TestWhitespaceOnly() {
            var result = MorseTranslator.Translate("   ", "v0.1");
            Assert.That(result, Is.EqualTo("/ / /"));
        }

        [Test]
        public void TestDefaultVersionFallback() {
            var result = MorseTranslator.Translate("SOS", "v0.3");
            Assert.That(result, Is.EqualTo("... --- ..."));
        }

        [Test]
        public void TestDigitsTranslation() {
            var result = MorseTranslator.Translate("123", "v0.1");
            Assert.That(result, Is.EqualTo(".---- ..--- ...--"));
        }
    }
}
