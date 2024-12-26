using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model.FreeCompany;

/// <summary>
/// Definitions for FC estate
/// </summary>
public class EstateDefinition : IDefinition
{
    /// <summary>
    /// Definition for empty estate
    /// </summary>
    [JsonPropertyName("NO_ESTATE")]
    public DefinitionsPack NoEstate { get; set; }

    /// <summary>
    /// Greeting
    /// </summary>
    [JsonPropertyName("GREETING")]
    public DefinitionsPack Greeting { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("NAME")]
    public DefinitionsPack Name { get; set; }

    /// <summary>
    /// Plot
    /// </summary>
    [JsonPropertyName("PLOT")]
    public DefinitionsPack Plot { get; set; }
}

/// <summary>
/// Ranking definitions
/// </summary>
public class Ranking
{
    /// <summary>
    /// Weekly ranking
    /// </summary>
    [JsonPropertyName("WEEKLY")]
    public DefinitionsPack Weekly { get; set; }

    /// <summary>
    /// Monthly ranking
    /// </summary>
    [JsonPropertyName("MONTHLY")]
    public DefinitionsPack Monthly { get; set; }
}

/// <summary>
/// Definitions for free company profile
/// </summary>
public class FreeCompanyDefinition : IDefinition
{
    /// <summary>
    /// Is Active
    /// </summary>
    [JsonPropertyName("ACTIVE_STATE")]
    public DefinitionsPack Activestate { get; set; }

    /// <summary>
    /// Active member count
    /// </summary>
    [JsonPropertyName("ACTIVE_MEMBER_COUNT")]
    public DefinitionsPack ActiveMemberCount { get; set; }

    /// <summary>
    /// Layers of the crest
    /// </summary>
    [JsonPropertyName("CREST_LAYERS")]
    public IconLayersDefinition CrestLayers { get; set; }

    /// <summary>
    /// Information about estate
    /// </summary>
    [JsonPropertyName("ESTATE")]
    public EstateDefinition EstateDefinition { get; set; }

    /// <summary>
    /// Foundation date
    /// </summary>
    [JsonPropertyName("FORMED")]
    public DefinitionsPack Formed { get; set; }

    /// <summary>
    /// Grand company
    /// </summary>
    [JsonPropertyName("GRAND_COMPANY")]
    public DefinitionsPack GrandCompany { get; set; }

    /// <summary>
    /// Id
    /// </summary>
    [JsonPropertyName("ID")]
    public DefinitionsPack Id { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("NAME")]
    public DefinitionsPack Name { get; set; }

    /// <summary>
    /// Rank
    /// </summary>
    [JsonPropertyName("RANK")]
    public DefinitionsPack Rank { get; set; }

    /// <summary>
    /// Rankings
    /// </summary>
    [JsonPropertyName("RANKING")]
    public Ranking Ranking { get; set; }

    /// <summary>
    /// Recruitment info
    /// </summary>
    [JsonPropertyName("RECRUITMENT")]
    public DefinitionsPack Recruitment { get; set; }

    /// <summary>
    /// World
    /// </summary>
    [JsonPropertyName("SERVER")]
    public DefinitionsPack Server { get; set; }

    /// <summary>
    /// Slogan
    /// </summary>
    [JsonPropertyName("SLOGAN")]
    public DefinitionsPack Slogan { get; set; }

    /// <summary>
    /// Tags
    /// </summary>
    [JsonPropertyName("TAG")]
    public DefinitionsPack Tag { get; set; }
}