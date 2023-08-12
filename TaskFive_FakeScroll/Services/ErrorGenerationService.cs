using Bogus;
using System.Text;
using TaskFive_FakeScroll.Services.Interfaces;

namespace TaskFive_FakeScroll.Services
{
    public class ErrorGenerationService : IErrorGenerationService
    {
        public Action<StringBuilder, Randomizer, string?>[] ErrorMethods => new Action<StringBuilder, Randomizer, string?>[]
        {
            RemoveRandomChar,
            SwapChars,
            AddRandomChar
        };

        public void ApplyRandomErrors(int count, Randomizer random, string? locale, params StringBuilder[] applyTo)
        {
            for (int i = 0; i<count; i++)
            {
                StringBuilder applyToElement = random.ArrayElement(applyTo);
                var randomErrorMethod = GetRandomErrorMethod(random);
                randomErrorMethod(applyToElement, random, locale);
            }
        }

        private Action<StringBuilder, Randomizer, string?> GetRandomErrorMethod(Randomizer random)
        {
            return random.ArrayElement(ErrorMethods);
        }

        private void RemoveRandomChar(StringBuilder stringBuilder, Randomizer random, string? _)
        {
            if (stringBuilder.Length <= 2) return;
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
            var lorem = new Bogus.DataSets.Lorem(locale: locale);
            string randomLetter = lorem.Letter();
            stringBuilder.Insert(random.Number(0, stringBuilder.Length-1), randomLetter);
        }
    }
}
