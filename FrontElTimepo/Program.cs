using BlazorApp.Services;
using FrontElTimepo;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddScoped<ArticleService>();


            // Register HttpClient with the base address of your API
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5071/api") });

            await builder.Build().RunAsync();
        }
    }
}
