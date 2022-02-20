using System.Text.Json.Serialization;

namespace Cheezy.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Taste
    {
        spicy,
        sweet,
        salty,
        bitter,
        umami
    }
}
