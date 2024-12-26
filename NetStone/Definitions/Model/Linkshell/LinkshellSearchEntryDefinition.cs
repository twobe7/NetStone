using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model.Linkshell;

/// <summary>
/// Definition container for one Link-Shell search result entry
/// </summary>
public class LinkshellSearchEntryDefinition : PagedEntryDefinition
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonPropertyName("ID")] public DefinitionsPack Id { get; set; }
    
    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("NAME")] public DefinitionsPack Name { get; set; }
    
    /// <summary>
    /// Rank
    /// </summary>
    [JsonPropertyName("SERVER")] public DefinitionsPack Server { get; set; }
    
    /// <summary>
    /// Rank Icon
    /// </summary>
    [JsonPropertyName("ACTIVE_MEMBERS")] public DefinitionsPack ActiveMembers { get; set; }
}