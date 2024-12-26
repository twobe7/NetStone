using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model.CWLS;

/// <summary>
/// Definitions for cross world link shell
/// </summary>
public class CrossworldLinkshellDefinition : IDefinition
{
    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("NAME")]
    public DefinitionsPack Name { get; set; }
    
    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("DC")]
    public DefinitionsPack DataCenter { get; set; }
}