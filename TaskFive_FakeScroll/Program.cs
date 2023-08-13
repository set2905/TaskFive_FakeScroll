using BlazorDownloadFile;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using TaskFive_FakeScroll;
using TaskFive_FakeScroll.Services;
using TaskFive_FakeScroll.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTransient<IFakePersonGenService, FakePersonGenService>();
builder.Services.AddTransient<IErrorGenerationService, ErrorGenerationService>();
builder.Services.AddTransient<IExporterService, CsvExporterService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddBlazorDownloadFile(ServiceLifetime.Scoped);

await builder.Build().RunAsync();
