using TaskFive_FakeScroll.Models;
using TaskFive_FakeScroll.Services.Interfaces;
namespace TaskFive_FakeScroll.Services
{
    public class FakePersonGenService : IFakePersonGenService
    {
        /// <summary>
        /// Generates fake persons
        /// </summary>
        /// <param name="skip">How many items to skip</param>
        /// <param name="take">How many items to take/generate</param>
        /// <param name="locale"></param>
        /// <param name="seed"></param>
        public List<FakePerson> GetFakePersons(int skip, int take, string locale, int seed)
        {
            if (skip < 0|| take<0) throw new ArgumentException("skip or take values cant be negative");
            if (locale.Length==0) locale = "en";
            List<FakePerson> result = new();
            for (int i = skip; i <= skip+take; i++)
            {
                int localSeed = seed+i;
                result.Add(new(locale, localSeed, i));
            }
            return result;
        }
        /// <summary>
        /// Sets seed and locale to every instance of FakePerson in <paramref name="toReferesh"/>
        /// </summary>
        /// <param name="toReferesh"></param>
        /// <param name="seed"></param>
        /// <param name="locale"></param>
        public void Refresh(IEnumerable<FakePerson> toReferesh, int seed, string locale)
        {
            if (locale.Length==0) locale = "en";
            foreach (FakePerson fakePerson in toReferesh)
                fakePerson.Refresh(seed+fakePerson.Num, locale);
        }
    }
}
