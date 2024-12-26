using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model.Character;

/// <summary>
/// Definition pack for character search results
/// </summary>
public class CharacterSearchEntryDefinition : PagedEntryDefinition
{
    /// <summary>
    /// Avatar of character
    /// </summary>
    [JsonPropertyName("AVATAR")]
    public DefinitionsPack Avatar { get; set; }

    /// <summary>
    /// Lodestone Id
    /// </summary>
    [JsonPropertyName("ID")]
    public DefinitionsPack Id { get; set; }

    /// <summary>
    /// Language
    /// </summary>
    [JsonPropertyName("LANG")]
    public DefinitionsPack Lang { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("NAME")]
    public DefinitionsPack Name { get; set; }

    /// <summary>
    /// Grand Company rank
    /// </summary>
    [JsonPropertyName("RANK")]
    public DefinitionsPack Rank { get; set; }

    /// <summary>
    /// Grand Company rank icon
    /// </summary>
    [JsonPropertyName("RANK_ICON")]
    public DefinitionsPack RankIcon { get; set; }

    /// <summary>
    /// Homeworld
    /// </summary>
    [JsonPropertyName("SERVER")]
    public DefinitionsPack Server { get; set; }
}