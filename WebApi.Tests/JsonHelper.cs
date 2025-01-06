using System.Text.Json;

namespace Example.CSharp.Http.WebApi.Tests;

public static class JsonHelper
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new() { WriteIndented = false };
    public static string NormalizeJson(string json)
    {
        var jsonElement = JsonSerializer.Deserialize<JsonElement>(json);
        return JsonSerializer.Serialize(jsonElement, _jsonSerializerOptions);
    }
}
