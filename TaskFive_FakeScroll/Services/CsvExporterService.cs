using BlazorDownloadFile;
using Microsoft.JSInterop;
using TaskFive_FakeScroll.Services.Interfaces;
using CsvHelper;
using System.Globalization;
using TaskFive_FakeScroll.Models;

namespace TaskFive_FakeScroll.Services
{
    public class CsvExporterService : IExporterService<FakePerson>
    {
        private readonly IBlazorDownloadFileService blazorDownloadFileService;

        public CsvExporterService(IBlazorDownloadFileService blazorDownloadFileService, IJSRuntime jSRuntime)
        {
            this.blazorDownloadFileService=blazorDownloadFileService;
        }

        /// <summary>
        /// Converts <paramref name="records"/> to list of FakePersonCsvModel then writes it to .csv file and downloads it.
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public async Task DownloadExport(IEnumerable<FakePerson> records)
        {
            List<FakePersonCsvModel> csvRecords = new();
            foreach (FakePerson r in records)
            {
                csvRecords.Add(new(r.Id, r.Num, r.FullName, r.Phone, r.FullAddress, r.Address.ZipCode));
            }
            var memStream = new MemoryStream();
            var memStreamWriter = new StreamWriter(memStream);
            using (var csv = new CsvWriter(memStreamWriter, CultureInfo.InvariantCulture))
            {
                await csv.WriteRecordsAsync(csvRecords);
            }

            byte[] file = memStream.ToArray();
            await blazorDownloadFileService.DownloadFile($"FakePeopleExport_{DateTime.Now.ToString("dd_MM_HH:mm")}.csv", file, 32768, "application/octet-stream", null);
        }


    }
    internal class FakePersonCsvModel
    {
        public FakePersonCsvModel(Guid id, int num, string fullName, string phone, string fullAddress, string zipCode)
        {
            Id=id;
            Num=num;
            FullName=fullName;
            FullAddress=fullAddress;
            Phone=phone;
            ZipCode=zipCode;
        }
        public int Num { get; set; }
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string FullAddress { get; set; }
        public string ZipCode { get; set; }
    }
}
