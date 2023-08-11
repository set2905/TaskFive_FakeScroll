namespace TaskFive_FakeScroll.Services.Interfaces
{
    public interface IErrorGenerationService
    {
        public Func<string, string>[] ErrorMethods { get; }
        public string ApplyRandomError(string applyTo);
    }
}
