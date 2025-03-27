using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ECommerceFEApp;
using ECommerceFEApp.Services;
using ECommerceFEApp.AuthServices;
using ECommerceFEApp.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://jasonlikaapiwebapp-hxf4amd6fsa4fab8.eastus2-01.azurewebsites.net/") });
// Register the ProductService in the DI container
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<TicketService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<WishlistService>();


await builder.Build().RunAsync();
