using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ECommerceFEApp;
using ECommerceFEApp.Services;
using ECommerceFEApp.AuthServices;
using ECommerceFEApp.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7117") });
// Register the ProductService in the DI container
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<TicketService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<WishlistService>();


await builder.Build().RunAsync();
