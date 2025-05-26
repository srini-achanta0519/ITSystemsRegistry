using System.Net.Http.Json;

namespace FrontEnd.Data;

public class ItSystemService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<ItSystemService> _logger;

    public ItSystemService(HttpClient httpClient, IConfiguration configuration, ILogger<ItSystemService> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<IEnumerable<ItSystem>> GetItSystemsAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ItSystem>>("api/itsystems") ?? Array.Empty<ItSystem>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching IT systems");
            return Array.Empty<ItSystem>();
        }
    }

    public async Task<ItSystem?> GetItSystemAsync(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<ItSystem>($"api/itsystems/{id}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching IT system with ID {Id}", id);
            return null;
        }
    }

    public async Task<bool> CreateItSystemAsync(ItSystem itSystem)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/itsystems", itSystem);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating IT system");
            return false;
        }
    }

    public async Task<bool> UpdateItSystemAsync(ItSystem itSystem)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/itsystems/{itSystem.Id}", itSystem);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating IT system with ID {Id}", itSystem.Id);
            return false;
        }
    }

    public async Task<bool> DeleteItSystemAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/itsystems/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting IT system with ID {Id}", id);
            return false;
        }
    }
}
