using System.Reflection;
using BravaPharm.OrderManagement.App;
using BravaPharm.OrderManagement.App.Contracts;
using BravaPharm.OrderManagement.App.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


var apiUrl = builder.Configuration["ApiUrl"];

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.AddHttpClient<IClient, Client>(client=>client.BaseAddress = new Uri("https://localhost:7077"));
builder.Services.AddHttpClient<IClient, Client>(_ => new Client(apiUrl, new HttpClient { BaseAddress = new Uri(apiUrl) }) );
builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
await builder.Build().RunAsync();
