using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CarMarket.Client;
using MudBlazor.Services;
using CarMarket.Client.Services.HttpService;
using CarMarket.Client.Services.SignalR;
using CarMarket.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("WebAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WebAPI"));
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<ChatHub>();
builder.Services.AddScoped<ChatHandler>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
