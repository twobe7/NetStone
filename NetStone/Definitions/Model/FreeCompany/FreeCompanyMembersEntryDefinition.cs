using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model.FreeCompany;

/// <summary>
/// Definition for one FC member
/// </summary>
public class FreeCompanyMembersEntryDefinition : PagedEntryDefinition
{
    /// <summary>
    /// Avatar of member character
    /// </summary>
    [JsonPropertyName("AVATAR")]
    public DefinitionsPack Avatar { get; set; }

    /// <summary>
    /// ID of character
    /// </summary>
    [JsonPropertyName("ID")]
    public DefinitionsPack Id { get; set; }

    /// <summary>
    /// Name of character
    /// </summary>
    [JsonPropertyName("NAME")]
    public DefinitionsPack Name { get; set; }

    /// <summary>
    /// Grand company rank
    /// </summary>
    [JsonPropertyName("RANK")]
    public DefinitionsPack Rank { get; set; }

    /// <summary>
    /// GC rank icon
    /// </summary>
    [JsonPropertyName("RANK_ICON")]
    public DefinitionsPack RankIcon { get; set; }

    /// <summary>
    /// Free company rank
    /// </summary>
    [JsonPropertyName("FC_RANK")]
    public DefinitionsPack FreeCompanyRank { get; set; }

    /// <summary>
    /// FC rank icon
    /// </summary>
    [JsonPropertyName("FC_RANK_ICON")]
    public DefinitionsPack FreeCompanyRankIcon { get; set; }

    /// <summary>
    /// Homeworld
    /// </summary>
    [JsonPropertyName("SERVER")]
    public DefinitionsPack Server { get; set; }
}