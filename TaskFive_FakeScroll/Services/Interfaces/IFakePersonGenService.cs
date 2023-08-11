using TaskFive_FakeScroll.Models;

namespace TaskFive_FakeScroll.Services.Interfaces
{
    public interface IFakePersonGenService
    {
        public List<FakePerson> GenerateFakePersons(int skip, int take, string locale, int seed=0);
    }
}
