using Blazored.LocalStorage;
using HamsterWarsWebAssembly.Client;
using HamsterWarsWebAssembly.Client.Auth;
using HamsterWarsWebAssembly.Client.Services.BattleService;
using HamsterWarsWebAssembly.Client.Services.HamsterService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IHamsterService, HamsterService>();
builder.Services.AddScoped<IBattleService, BattleService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
