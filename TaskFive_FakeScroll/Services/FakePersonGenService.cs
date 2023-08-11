using TaskFive_FakeScroll.Models;
using TaskFive_FakeScroll.Services.Interfaces;
using Bogus;
namespace TaskFive_FakeScroll.Services
{
    public class FakePersonGenService : IFakePersonGenService
    {

        public List<FakePerson> GenerateFakePersons(int skip, int take, string locale, int seed)
        {
            List<FakePerson> result = new();
            for (int i = skip; i < skip+take; i++)
            {
                int localSeed = seed+i;
                result.Add(Generate(locale, localSeed, i));
            }
            return result;
        }


        private FakePerson Generate(string locale, int seed, int num)
        {
            FakePerson result = new(locale, seed, num);
            return result;
        }
    }
}
