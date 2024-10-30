using Anime_API;
using System;

class Program
{
    static async Task Main(string[] args)
    {
        var client = new AnimeApiClient();

        Console.Write("Enter an anime ID to search: ");
        if (int.TryParse(Console.ReadLine(), out int animeId))
        {
            var animeTitle = await client.GetAnimeTitleByIdAsync(animeId);
            var animeSynopsis = await client.GetAnimeSynopsisByIdAsync(animeId);
            if (animeTitle != null)
            {
                Console.WriteLine("Title: " + animeTitle);
                Console.WriteLine("Synopsis: " + animeSynopsis);
            }
            else
            {
                Console.WriteLine("Anime not found or API request failed.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }
}
