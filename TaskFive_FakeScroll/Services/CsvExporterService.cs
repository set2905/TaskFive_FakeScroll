using BlazorDownloadFile;
using Microsoft.JSInterop;
using System.Net.Mime;
using System;
using TaskFive_FakeScroll.Services.Interfaces;
using CsvHelper;
using System.Globalization;

namespace TaskFive_FakeScroll.Services
{
    public class CsvExporterService : IExporterService
    {
        private readonly IBlazorDownloadFileService blazorDownloadFileService;

        public CsvExporterService(IBlazorDownloadFileService blazorDownloadFileService, IJSRuntime jSRuntime)
        {
            this.blazorDownloadFileService=blazorDownloadFileService;
        }

        public async Task DownloadExport(IEnumerable<object> records)
        {
            var memStream = new MemoryStream();
            var memStreamWriter = new StreamWriter(memStream);
            using (var csv = new CsvWriter(memStreamWriter, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }

            byte[] file = memStream.ToArray();
            await blazorDownloadFileService.DownloadFile($"FakePeopleExport_{DateTime.Now.ToString("dd_MM_HH:mm")}.csv", file, 32768, "application/octet-stream", null);
        }


    }
}
