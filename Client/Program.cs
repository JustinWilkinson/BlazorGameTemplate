using BlazorGameTemplate.Client.Services;
using BlazorGameTemplate.Client.Services.SignalR;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Threading.Tasks;

namespace BlazorGameTemplate.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpService(builder.HostEnvironment.BaseAddress);
            builder.Services.AddGameStorage();
            builder.Services.AddBlazorTimer();
            builder.Services.AddHubCommunicator<GameHubCommunicator>();

            await builder.Build().RunAsync();
        }
    }
}