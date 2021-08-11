using System;
using System.Net.Http;
using System.Threading.Tasks;
using AdminDashboard.Wasm.Helpers;
using AdminDashboard.Wasm.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace AdminDashboard.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IHttpService, HttpService>();
            builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
            builder.Services.AddScoped<IAlertService, AlertService>();

            builder.Services.AddScoped(
                sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped(
                x =>
                {
                    var apiUrl = new Uri(builder.Configuration["apiUrl"]);

                    // use fake backend if "fakeBackend" is "true" in appsettings.json
                    if (builder.Configuration["fakeBackend"] == "true")
                    {
                        var fakeBackendHandler = new FakeBackendHandler(x.GetService<ILocalStorageService>());
                        return new HttpClient(fakeBackendHandler) { BaseAddress = apiUrl };
                    }

                    return new HttpClient() { BaseAddress = apiUrl };
                });

            builder.Services.AddMudServices();
            
            var host = builder.Build();

            var accountService = host.Services.GetRequiredService<IAccountService>();
            await accountService.Initialize();


            await host.RunAsync();
        }
    }
}