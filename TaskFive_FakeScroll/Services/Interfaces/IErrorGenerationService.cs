using Bogus;
using System.Text;

namespace TaskFive_FakeScroll.Services.Interfaces
{
    public interface IErrorGenerationService
    {
        public Action<StringBuilder, Randomizer>[] ErrorMethods { get; }
        public void ApplyRandomErrors(int count,Randomizer random, params StringBuilder[] applyTo);
    }
}
