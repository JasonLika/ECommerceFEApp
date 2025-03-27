using ECommerceFEApp.Models;
using System.Data.Common;
using System.Net.Http.Json;

namespace ECommerceFEApp.Services {
public class ReviewService
{
    private readonly HttpClient _httpClient;
 
    public ReviewService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Review>> GetReviewsByIdAsync(int id)  {
        return await _httpClient.GetFromJsonAsync<List<Review>>($"api/reviews/{id}");
    }


    public async Task<List<Review>> GetReviewsAsync()
    {
        // Makes an HTTP GET request to fetch the product list from the API.
        return await _httpClient.GetFromJsonAsync<List<Review>>("api/reviews");
    }

    public async Task CreateReviewAsync(Review review) {
        await _httpClient.PostAsJsonAsync("api/reviews", review);
    }
}
}