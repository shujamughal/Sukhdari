using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sukhdari.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sukhdari.Client.Service;
using Sukhdari.Client.Service.IService;
using System;
using System.Net.Http;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk1OTk5NEAzMjMzMmUzMDJlMzBpWDBMdnBNZXhhVTZ3M0hhUnJIWjkxbnQxdTFqR05BVnFROWxrV1AyQXRZPQ==");

builder.Services.AddHttpClient("IP", (options) => {
    options.BaseAddress = new Uri("https://jsonip.com");
});
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseApiUrl", "https://localhost:44353/")) });
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IUserIpService, UserIpService>();
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();
