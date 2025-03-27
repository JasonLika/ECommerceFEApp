using ECommerceFEApp.Models;
using System.Data.Common;
using System.Net.Http.Json;

namespace ECommerceFEApp.Services {
public class CartService
{
    private readonly HttpClient _httpClient;
 
    public CartService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddToCartAsync(Cart cartItem)
    {
    await _httpClient.PostAsJsonAsync("api/carts", cartItem);
    }
    
    
    public async Task<List<Cart>> GetCartsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Cart>>("api/carts");
    }

    public async Task DeleteCartItemAsync(int id) {
        await _httpClient.DeleteAsync($"api/carts/{id}");
    }

    public async Task UpdateCartItemAsync(Cart cartItem)
    {
        await _httpClient.PutAsJsonAsync($"api/carts/{cartItem.Id}", cartItem);
    }

    // to add exiting product to cart increments quantity
    public async Task<Cart?> GetCartItemByProductIdAsync(int productId)
    {
    return await _httpClient.GetFromJsonAsync<Cart>($"api/carts/product/{productId}");
    }
    //

    public async Task<UserProfile?> GetCurrentUserProfileAsync()
    {
    // Call the API endpoint to retrieve the current user's profile
    return await _httpClient.GetFromJsonAsync<UserProfile>("api/userprofiles/me");
    }
}
}