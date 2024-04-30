using StarisApi.DbContexts;
using StarisApi.Handlers;
using StarisApi.Models;
using System.Text.Json;

namespace StarisApi.Repository;

public class DataBaseFeeder<TEntity> where TEntity : Entity, new()
{
    private readonly SqliteContext _context;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _urlBase = "https://swapi.py4e.com/api/";
    private readonly HttpClient _client;

    public DataBaseFeeder(SqliteContext context, IHttpClientFactory httpClientFactory)
    {
        _context = context;
        _httpClientFactory = httpClientFactory;
        _client = _httpClientFactory.CreateClient();
    }
    public async Task<string> InsertNew<T>(List<TEntity> obj)
    {
        try
        {
            _context.Set<TEntity>().AddRange(obj);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return "Bad Request 500";
        }
        return Results.Ok("Database successfully feed.").ToString()!;
    }

    public async Task<List<JsonElement>> GetInfoFromEndpoint(string entityName)
    {
        Dictionary<string, (string Endpoint, int Limit)> mapEntity = new()
        {
            { "Character", ("people/", 9) },
            { "Planet", ("planets/", 7) },
            { "Vehicle", ("vehicles/", 4) },
            { "Starship", ("starships/", 4) },
            { "Movie", ("films/", 1) }
        };

        if (!mapEntity.TryGetValue(entityName, out var entityInfo))
        {
            throw new ArgumentException($"Entity name '{entityName}' is not supported.");
        }

        var endpoint = entityInfo.Endpoint;
        var limit = entityInfo.Limit;

        List<JsonElement> infos = [];

        for (var i = 0; i < limit; i++)
        {
            var response = await _client.GetAsync($"{_urlBase}/{endpoint}?page={i + 1}");
            var stream = await response.Content.ReadAsStreamAsync();
            var bodyMessage = await JsonDocument.ParseAsync(stream);

            JsonElement resultProperty = bodyMessage.RootElement.GetProperty("results");

            if (resultProperty.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement element in resultProperty.EnumerateArray())
                {
                    infos.Add(element);
                }
            }
        }

        return infos;
    }

    public async Task<List<TEntity>> GetEntityBase<T>(List<JsonElement> infos)
    {
        var entities = new List<TEntity>();
        foreach (var info in infos)
        {
            var entity = new TEntity().ConvertFromJson<TEntity>(info);
            if (!Attribute.IsDefined(typeof(TEntity), typeof(NotProcessImageAttribute)))
            {
                entity.ImageUrl = await ScrappyUrlImage(entity.ImageUrl);

                string[] parts = [];
                if (entity.ImageUrl.Contains(".png"))
                {
                    parts = entity.ImageUrl.Split(new[] { ".png" }, StringSplitOptions.None);
                    entity.ImageUrl = parts[0] + ".png";
                }
                else
                {
                    parts = entity.ImageUrl.Split(new[] { ".jpg" }, StringSplitOptions.None);
                    entity.ImageUrl = parts[0] + ".jpg";
                }
            }

            entities.Add(entity);
        }
        await Task.CompletedTask;
        return entities;
    }

    public async Task<string> ScrappyUrlImage(string url)
    {
        string htmlContent = await _client.GetStringAsync(url);
        return DataBaseFeederHandler.ExtractImageUrl(htmlContent);
    }
}
