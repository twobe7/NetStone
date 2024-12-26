using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model.FreeCompany;

/// <summary>
/// Definition for one type of FC foc
/// us
/// </summary>
public class FreeCompanyFocusEntryDefinition : IDefinition
{
    /// <summary>
    /// Name of type
    /// </summary>
    [JsonPropertyName("NAME")]
    public DefinitionsPack NAME { get; set; }

    /// <summary>
    /// Icon for type
    /// </summary>
    [JsonPropertyName("ICON")]
    public DefinitionsPack ICON { get; set; }

    /// <summary>
    /// Status (if company focuses on this)
    /// </summary>
    [JsonPropertyName("STATUS")]
    public DefinitionsPack STATUS { get; set; }
}

/// <summary>
/// Definition container for all FC focus types
/// </summary>
public class FreeCompanyFocusDefinition : IDefinition
{
    /// <summary>
    /// No focus specified
    /// </summary>
    [JsonPropertyName("NOT_SPECIFIED")]
    public DefinitionsPack NOTSPECIFIED { get; set; }

    /// <summary>
    /// Role play
    /// </summary>
    [JsonPropertyName("RP")]
    public FreeCompanyFocusEntryDefinition RolePlay { get; set; }

    /// <summary>
    /// Leveling
    /// </summary>
    [JsonPropertyName("LEVELING")]
    public FreeCompanyFocusEntryDefinition Leveling { get; set; }

    /// <summary>
    /// Casual
    /// </summary>
    [JsonPropertyName("CASUAL")]
    public FreeCompanyFocusEntryDefinition Casual { get; set; }

    /// <summary>
    /// Hardcore
    /// </summary>
    [JsonPropertyName("HARDCORE")]
    public FreeCompanyFocusEntryDefinition Hardcore { get; set; }

    /// <summary>
    /// Dungeons
    /// </summary>
    [JsonPropertyName("DUNGEONS")]
    public FreeCompanyFocusEntryDefinition Dungeons { get; set; }

    /// <summary>
    /// Guild hests
    /// </summary>
    [JsonPropertyName("GUILDHESTS")]
    public FreeCompanyFocusEntryDefinition Guildhests { get; set; }

    /// <summary>
    /// Trials
    /// </summary>
    [JsonPropertyName("TRIALS")]
    public FreeCompanyFocusEntryDefinition Trials { get; set; }

    /// <summary>
    /// Raids
    /// </summary>
    [JsonPropertyName("RAIDS")]
    public FreeCompanyFocusEntryDefinition Raids { get; set; }

    /// <summary>
    /// PvP
    /// </summary>
    [JsonPropertyName("PVP")]
    public FreeCompanyFocusEntryDefinition PvP { get; set; }
}