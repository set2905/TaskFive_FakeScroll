using TaskFive_FakeScroll.Services.Interfaces;

namespace TaskFive_FakeScroll.Services
{
    public class ErrorGenerationService : IErrorGenerationService
    {
        private readonly Random random = new Random();
        public Func<string, string>[] ErrorMethods => new Func<string, string>[]
        {
            RemoveRandomChar,
        };
        public string ApplyRandomError(string applyTo)
        {
            return ErrorMethods[random.Next(0, ErrorMethods.Length)](applyTo);
        }

        private string RemoveRandomChar(string removeFrom)
        {
            int startIndex = random.Next(0, removeFrom.Length-1);
            return removeFrom.Remove(startIndex, 1);
        }

    }
}
