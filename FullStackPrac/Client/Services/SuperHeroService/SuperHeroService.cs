using System.Net.Http.Json;

namespace FullStackPrac.Client.Services.SuperHeroService;

public class SuperHeroService : ISuperHeroService
{
    private readonly HttpClient _http;

    public SuperHeroService(HttpClient http)
    {
        _http = http;
    }

    public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();

    public List<Comic> Comics { get; set; } = new List<Comic>();

    public Task GetComics()
    {
        throw new NotImplementedException();
    }

    public async Task GetSuperHeroes()
    {
        var response = await _http.GetFromJsonAsync<List<SuperHero>>("api/SuperHero");
        if (response != null)
            Heroes = response;
    }

    public Task<SuperHero> GetSuperHero(int id)
    {
        throw new NotImplementedException();
    }
}