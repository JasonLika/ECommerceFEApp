using ECommerceFEApp.Models;
using Microsoft.AspNetCore.Components.Forms;
using System.Data.Common;
using System.Net.Http.Json;

namespace ECommerceFEApp.Services {
public class ProductService
{
    private readonly HttpClient _httpClient;
 
    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
 
    public async Task<List<Product>> GetProductsAsync()
    {
        // Makes an HTTP GET request to fetch the product list from the API.
        return await _httpClient.GetFromJsonAsync<List<Product>>("api/products");
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
    return await _httpClient.GetFromJsonAsync<Product>($"api/products/{id}");
    }

    public async Task UpdateProductAsync(int id, Product product) {
        await _httpClient.PutAsJsonAsync($"api/products/{id}", product);
    }

    public async Task CreateProductAsync(Product product) {
        await _httpClient.PostAsJsonAsync("api/products", product);
    }

     public async Task DeleteProductAsync(int id) {
        await _httpClient.DeleteAsync($"api/products/{id}");
    }

    /* delete cart stuff
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
    */

    //image stuff
    public async Task UploadProductImageAsync(int productId, IBrowserFile file)
    {
    var content = new MultipartFormDataContent();
    var streamContent = new StreamContent(file.OpenReadStream(maxAllowedSize: 1024 * 1024 * 15)); // e.g., 15 MB max
    content.Add(streamContent, "file", file.Name);
    await _httpClient.PostAsync($"api/products/{productId}/upload-image", content);
    }
    //

    public async Task<Product> CreateProductIdAsync(Product product)
    {
    var response = await _httpClient.PostAsJsonAsync("api/products", product);

    if (response.IsSuccessStatusCode)
    {
        // Deserialize and return the created product from the response
        return await response.Content.ReadFromJsonAsync<Product>();
    }

    throw new Exception("Failed to create product");
    }   
}
}