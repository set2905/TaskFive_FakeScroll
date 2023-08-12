using Bogus;
using System.Text;
using TaskFive_FakeScroll.Services.Interfaces;

namespace TaskFive_FakeScroll.Services
{
    public class ErrorGenerationService : IErrorGenerationService
    {
        public Action<StringBuilder, Randomizer>[] ErrorMethods => new Action<StringBuilder, Randomizer>[]
        {
            RemoveRandomChar,
            SwapChars
        };

        public void ApplyRandomErrors(int count, Randomizer random, params StringBuilder[] applyTo)
        {
            for (int i = 0; i<count; i++)
            {
                StringBuilder applyToElement = random.ArrayElement(applyTo);
                Action<StringBuilder, Randomizer> randomErrorMethod = GetRandomErrorMethod(random);
                randomErrorMethod(applyToElement, random);
            }
        }

        private Action<StringBuilder, Randomizer> GetRandomErrorMethod(Randomizer random)
        {
            return random.ArrayElement(ErrorMethods);
        }

        private void RemoveRandomChar(StringBuilder stringBuilder, Randomizer random)
        {
            if (stringBuilder.Length <= 2) return;
            int startIndex =  random.Number(0, stringBuilder.Length-2);
            stringBuilder.Remove(startIndex, 1);
        }

        private void SwapChars(StringBuilder stringBuilder, Randomizer random)
        {
            if (stringBuilder.Length <= 2) return;
            int startIndex = random.Number(0, stringBuilder.Length-2);
            char tmp = stringBuilder[startIndex];
            stringBuilder[startIndex] = stringBuilder[startIndex+1];
            stringBuilder[startIndex+1] = tmp;
        }
    }
}
