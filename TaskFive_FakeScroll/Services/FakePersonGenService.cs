using TaskFive_FakeScroll.Models;
using TaskFive_FakeScroll.Services.Interfaces;
namespace TaskFive_FakeScroll.Services
{
    public class FakePersonGenService : IFakePersonGenService
    {
        public List<FakePerson> GetFakePersons(int skip, int take, string locale, int seed)
        {
            List<FakePerson> result = new();
            for (int i = skip; i <= skip+take; i++)
            {
                int localSeed = seed+i;
                result.Add(CreateFakePerson(locale, localSeed, i));
            }
            return result;
        }

        private FakePerson CreateFakePerson(string locale, int seed, int num)
        {
            return new(locale, seed, num);
        }
    }
}
