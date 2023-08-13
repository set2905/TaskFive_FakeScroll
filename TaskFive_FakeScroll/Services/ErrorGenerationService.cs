using Bogus;
using System;
using System.Text;
using TaskFive_FakeScroll.Services.Interfaces;

namespace TaskFive_FakeScroll.Services
{
    public class ErrorGenerationService : IErrorGenerationService
    {
        private const int MIN_LENGTH = 5;
        private const int MAX_LENGTH = 30;
        private string? currentLocale;
        public string? CurrentLocale
        {
            get => currentLocale;
            private set
            {
                if (currentLocale == value) return;
                currentLocale= value;
                lorem=new(currentLocale);
            }
        }
        Bogus.DataSets.Lorem lorem = new();
        public Action<StringBuilder, Randomizer, string?>[] ErrorMethods => new Action<StringBuilder, Randomizer, string?>[]
        {
            RemoveRandomChar,
            SwapChars,
            AddRandomChar
        };

        public void ApplyRandomErrors(double errorFreq, int seed, string? locale, params StringBuilder[] applyTo)
        {

            if (errorFreq == 0) return;
            if (CurrentLocale!=locale) CurrentLocale = locale;
            Randomizer random = new(seed);
            var errorProbability = errorFreq - Math.Truncate(errorFreq);
            if (random.Double(0, 1)<errorProbability)
            {
                ApplyRandomError(random, locale, applyTo);
            }
            var errorCount = Math.Floor(errorFreq);
            for (int i = 0; i<errorCount; i++)
            {
                ApplyRandomError(random, locale, applyTo);
            }
        }

        private void ApplyRandomError(Randomizer random, string? locale, StringBuilder[] applyTo)
        {
            StringBuilder applyToElement = random.ArrayElement(applyTo);
            var randomErrorMethod = GetRandomErrorMethod(random);
            randomErrorMethod(applyToElement, random, locale);
        }

        private Action<StringBuilder, Randomizer, string?> GetRandomErrorMethod(Randomizer random)
        {
            return random.ArrayElement(ErrorMethods);
        }

        private void RemoveRandomChar(StringBuilder stringBuilder, Randomizer random, string? _)
        {
            if (stringBuilder.Length <= MIN_LENGTH||stringBuilder.Length <= 2) return;
            int startIndex = random.Number(0, stringBuilder.Length-2);
            stringBuilder.Remove(startIndex, 1);
        }

        private void SwapChars(StringBuilder stringBuilder, Randomizer random, string? _)
        {
            if (stringBuilder.Length <= 2) return;
            int startIndex = random.Number(0, stringBuilder.Length-2);
            char tmp = stringBuilder[startIndex];
            stringBuilder[startIndex] = stringBuilder[startIndex+1];
            stringBuilder[startIndex+1] = tmp;
        }
        private void AddRandomChar(StringBuilder stringBuilder, Randomizer random, string? locale)
        {
            if (stringBuilder.Length >= MAX_LENGTH) return;

            lorem.Random = random;
            string randomLetter = lorem.Letter();
            stringBuilder.Insert(random.Number(0, stringBuilder.Length-1), randomLetter);
        }
    }
}
