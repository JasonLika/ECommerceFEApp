using ECommerceFEApp.Models;
using System.Data.Common;
using System.Net.Http.Json;

namespace ECommerceFEApp.Services {
public class OrderService
{
    private readonly HttpClient _httpClient;
 
    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddToOrderAsync(Order orderItem)
    {
    await _httpClient.PostAsJsonAsync("api/orders", orderItem);
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Order>>("api/orders");
    }

}
}