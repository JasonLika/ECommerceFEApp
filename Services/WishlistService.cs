using ECommerceFEApp.Models;
using System.Data.Common;
using System.Net.Http.Json;

namespace ECommerceFEApp.Services {
public class WishlistService
{
    private readonly HttpClient _httpClient;
 
    public WishlistService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddToWishlistAsync(Wishlist wishlistItem)
    {
    await _httpClient.PostAsJsonAsync("api/wishlists", wishlistItem);
    }
    
    
    public async Task<List<Wishlist>> GetWishlistsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Wishlist>>("api/wishlists");
    }

    public async Task DeleteWishlistItemAsync(int id) {
        await _httpClient.DeleteAsync($"api/wishlists/{id}");
    }

    public async Task UpdateCartItemAsync(Wishlist wishlistItem)
    {
        await _httpClient.PutAsJsonAsync($"api/wishlists/{wishlistItem.Id}", wishlistItem);
    }

    // to add exiting product to cart increments quantity
    public async Task<Wishlist?> GetWishlistItemByProductIdAsync(int productId)
    {
    return await _httpClient.GetFromJsonAsync<Wishlist>($"api/wishlists/product/{productId}");
    }
    //

    public async Task<UserProfile?> GetCurrentUserProfileAsync()
    {
    // Call the API endpoint to retrieve the current user's profile
    return await _httpClient.GetFromJsonAsync<UserProfile>("api/userprofiles/me");
    }
    
}
}