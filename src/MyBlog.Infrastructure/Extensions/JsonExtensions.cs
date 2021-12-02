using System.Text.Json;

public static class JsonExtensions
{
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task<T> FromJsonAsync<T>(this string json) =>
        await JsonSerializer.DeserializeAsync<T>(json.GenerateStreamFromString(), _jsonOptions);

    public static string ToJson<T>(this T obj) => JsonSerializer.Serialize(obj, _jsonOptions);
}
