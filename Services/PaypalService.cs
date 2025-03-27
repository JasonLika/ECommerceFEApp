using ECommerceFEApp.Models;
using System.Data.Common;
using System.Net.Http.Json;

namespace ECommerceFEApp.Services {
public class PayPalService
{
    private readonly HttpClient _httpClient;
 
    public PayPalService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

     public async Task<HttpResponseMessage> CreatePayPalOrderAsync()
    {
        return await _httpClient.PostAsync("api/paypal/create-order", null);
    }
}
}