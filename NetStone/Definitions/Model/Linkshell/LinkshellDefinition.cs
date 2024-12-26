using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model.Linkshell;

/// <summary>
/// Definitions for link shell
/// </summary>
public class LinkshellDefinition : IDefinition
{
    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("NAME")]
    public DefinitionsPack Name { get; set; }
}