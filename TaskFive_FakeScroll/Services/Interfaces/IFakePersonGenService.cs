using TaskFive_FakeScroll.Models;

namespace TaskFive_FakeScroll.Services.Interfaces
{
    public interface IFakePersonGenService
    {
        public Task<List<Person>> GetFakePersons(int skip, int take);
    }
}
