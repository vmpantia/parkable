using System.Text.Json.Serialization;

namespace Parkable.Shared.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        Enabled,
        Disabled,
        Deleted
    }
}
