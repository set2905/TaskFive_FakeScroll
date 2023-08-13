using Bogus;
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
                result.Add(new(locale, localSeed, i));
            }
            return result;
        }

        public void Refresh(IEnumerable<FakePerson> toReferesh, int seed, string locale)
        {
            //local seed в отдлельный метод!!!
            foreach (FakePerson fakePerson in toReferesh)
                fakePerson.Refresh(seed+fakePerson.Num, locale);
        }
    }
}
