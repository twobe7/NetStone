using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model.CWLS;
/// <summary>
/// Definition container for one Cross World Link Shell search result entry
/// </summary>
public class CrossworldLinkshellSearchEntryDefinition : PagedEntryDefinition
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
    [JsonPropertyName("DC")] public DefinitionsPack Dc { get; set; }
    
    /// <summary>
    /// Rank Icon
    /// </summary>
    [JsonPropertyName("ACTIVE_MEMBERS")] public DefinitionsPack ActiveMembers { get; set; }
}