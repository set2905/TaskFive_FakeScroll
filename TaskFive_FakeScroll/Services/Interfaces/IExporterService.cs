namespace TaskFive_FakeScroll.Services.Interfaces
{
    public interface IExporterService<T>
    {
        public Task DownloadExport(IEnumerable<T> records);

    }
}
