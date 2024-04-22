using System.Net.Http;
using System.Text.Json;

namespace StarisApi.Repository;

public class DataBaseFeeder
{
    private readonly IHttpClientFactory _httpClientFactory;
    private string _url = "https://swapi.py4e.com/api/";

    public DataBaseFeeder(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<JsonElement>> GetInfoFromPeopleEndpoint(int page)
    {
        var endpoint = "people/?page=" + page + 1;
        var client = _httpClientFactory.CreateClient();

        List<JsonElement> infos = [];

        var response = await client.GetAsync($"{_url}/{endpoint}");
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

        return infos;
    }
}
