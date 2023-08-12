using TaskFive_FakeScroll.Models;

namespace TaskFive_FakeScroll.Services.Interfaces
{
    public interface IFakePersonGenService
    {
        public List<FakePerson> GetFakePersons(int skip, int take, string locale, int seed=0);
        public void Refresh(IEnumerable<FakePerson> toReferesh, int seed, string locale);
    }
}
