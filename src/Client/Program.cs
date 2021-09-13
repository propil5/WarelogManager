using Blazored.Toast;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WarelogManager.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            var baseApiAddress = GetBaseApiAddress(builder);
            #if DEBUG
            baseApiAddress = builder.HostEnvironment.BaseAddress;
            #endif

            builder.Services.AddHttpClient("WarelogManager.ServerAPI", client => client.BaseAddress = new Uri(baseApiAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WarelogManager.ServerAPI"));

            builder.Services.AddApiAuthorization();
            builder.Services.AddMudServices();
            builder.Services.AddBlazoredToast();

            await builder.Build().RunAsync();
        }

        private static string GetBaseApiAddress(WebAssemblyHostBuilder builder)
        {
            return builder.Configuration[$"baseWarelogApiUrl:{builder.HostEnvironment.Environment.ToLower()}"];
        }
    }
}
