using System.Reflection;
using BravaPharm.OrderManagement.App;
using BravaPharm.OrderManagement.App.Contracts;
using BravaPharm.OrderManagement.App.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.AddHttpClient<IClient, Client>(client=>client.BaseAddress = new Uri("https://localhost:7077"));
builder.Services.AddHttpClient<IClient, Client>(_ => new Client("https://localhost:7077", new HttpClient { BaseAddress = new Uri("https://localhost:7077") }) );
builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
await builder.Build().RunAsync();
