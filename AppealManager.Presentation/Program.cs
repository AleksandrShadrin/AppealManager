using AppealManager.Application;
using AppealManager.Presentation;
using AppealManager.Presentation.Services;
using AppealManager.Presentation.Utilities;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var now = DateTime.Now;
builder.Services.AddSingleton(sp => new GlobalStateService(now));

builder.Services.AddSingleton<TextFileReader>();
builder.Services.AddSingleton(sp => 
{ 
    var clock = () => DateTime.Now;
    var globalState = sp.GetService<GlobalStateService>();
    return new RKKMultipleStatsSaver(clock, globalState);
});

builder.Services.AddApplication();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
