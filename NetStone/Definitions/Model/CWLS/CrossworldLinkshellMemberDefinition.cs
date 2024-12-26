using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model.CWLS;


/// <summary>
/// 
/// </summary>
public class CrossworldLinkshellMemberEntryDefinition : PagedEntryDefinition
{
    /// <summary>
    /// Avatar
    /// </summary>
    [JsonPropertyName("AVATAR")] public DefinitionsPack Avatar { get; set; }
    
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
    [JsonPropertyName("RANK")] public DefinitionsPack Rank { get; set; }
    
    /// <summary>
    /// Rank Icon
    /// </summary>
    [JsonPropertyName("RANK_ICON")] public DefinitionsPack RankIcon { get; set; }
    
    /// <summary>
    /// Linkshell rank
    /// </summary>
    [JsonPropertyName("LINKSHELL_RANK")] public DefinitionsPack LinkshellRank { get; set; }
    
    /// <summary>
    /// Linkshell rank Icon
    /// </summary>
    [JsonPropertyName("LINKSHELL_RANK_ICON")] public DefinitionsPack LinkshellRankIcon { get; set; }
    
    /// <summary>
    /// Server
    /// </summary>
    [JsonPropertyName("SERVER")] public DefinitionsPack Server { get; set; }
}