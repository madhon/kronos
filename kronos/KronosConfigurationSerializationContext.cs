namespace Kronos
{
    using System.Text.Json.Serialization;

    [JsonSourceGenerationOptions(
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.Never,
        PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    [JsonSerializable(typeof(KronosConfiguration))]
    public partial class KronosConfigurationSerializationContext : JsonSerializerContext
    {
    }
}
