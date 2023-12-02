using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sukhdari_Client.Service;
using Sukhdari_Client.Service.IService;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Blazor;

namespace Sukhdari_Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk1OTk5NEAzMjMzMmUzMDJlMzBpWDBMdnBNZXhhVTZ3M0hhUnJIWjkxbnQxdTFqR05BVnFROWxrV1AyQXRZPQ==");

            builder.Services.AddHttpClient("IP", (options) => {
                options.BaseAddress = new Uri("https://jsonip.com");
            });
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseApiUrl", "https://localhost:44353/")) });
            builder.Services.AddScoped<IStoreService, StoreService>();
            builder.Services.AddScoped<IUserIpService, UserIpService>();
            builder.Services.AddSyncfusionBlazor();
            await builder.Build().RunAsync();
        }
    }
}
