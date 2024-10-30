using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class AnimeApiClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://api.jikan.moe/v4/";

    public AnimeApiClient()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
    }

    public async Task<string?> GetAnimeTitleByIdAsync(int animeId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"anime/{animeId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialize only the title
                var document = JsonDocument.Parse(jsonResponse);
                var title = document.RootElement.GetProperty("data").GetProperty("title").GetString();

                return title;
            }
            else
            {
                Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return null;
    }

    public async Task<string?> GetAnimeSynopsisByIdAsync(int animeId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"anime/{animeId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialize only the title
                var document = JsonDocument.Parse(jsonResponse);
                var synopsis = document.RootElement.GetProperty("data").GetProperty("synopsis").GetString();

                return synopsis;
            }
            else
            {
                Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return null;
    }
}

