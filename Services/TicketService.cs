using ECommerceFEApp.Models;
using System.Data.Common;
using System.Net.Http.Json;

namespace ECommerceFEApp.Services {
public class TicketService
{
    private readonly HttpClient _httpClient;
 
    public TicketService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Ticket>> GetTicketsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Ticket>>("api/tickets");
    }

    public async Task CreateTicketAsync(Ticket ticket) {
        await _httpClient.PostAsJsonAsync("api/tickets", ticket);
    }
}
}