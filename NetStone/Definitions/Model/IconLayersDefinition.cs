using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model;

/// <summary>
/// Definition for an icon with multiple layers
/// </summary>
public class IconLayersDefinition : IDefinition
{
    /// <summary>
    /// Bottom layer
    /// </summary>
    [JsonPropertyName("BOTTOM")]
    public DefinitionsPack Bottom { get; set; }

    /// <summary>
    /// Middle layer
    /// </summary>
    [JsonPropertyName("MIDDLE")]
    public DefinitionsPack Middle { get; set; }

    /// <summary>
    /// Top layer
    /// </summary>
    [JsonPropertyName("TOP")]
    public DefinitionsPack Top { get; set; }
}