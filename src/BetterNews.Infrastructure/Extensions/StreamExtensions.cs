using System.Text;

public static class StreamExtensions
{
    public static MemoryStream GenerateStreamFromString(this string source) => new(Encoding.UTF8.GetBytes(source));
}