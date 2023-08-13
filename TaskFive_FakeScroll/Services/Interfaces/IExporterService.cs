namespace TaskFive_FakeScroll.Services.Interfaces
{
    public interface IExporterService
    {
        public Task DownloadExport(IEnumerable<object> records);

    }
}
