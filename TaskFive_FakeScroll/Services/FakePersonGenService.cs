using TaskFive_FakeScroll.Models;
using TaskFive_FakeScroll.Services.Interfaces;

namespace TaskFive_FakeScroll.Services
{
    public class FakePersonGenService : IFakePersonGenService
    {
        public async Task<List<Person>> GetFakePersons(int skip, int take)
        {
            await Task.Delay(100);
            List<Person> result = new();
            for(int i = 0; i < take; i++)
            {
                result.Add(new Person($"Name {skip} {take}", "LastName", "MidName", "Addr", "Phone"));
            }
            return result;
        }
    }
}
