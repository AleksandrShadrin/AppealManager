using AppealManager.Application;
using AppealManager.Presentation;
using AppealManager.Presentation.Services;
using AppealManager.Presentation.Utilities;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<TextFileReader>();
builder.Services.AddSingleton<RKKStatsSaverFacade>();
builder.Services.AddApplication();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
