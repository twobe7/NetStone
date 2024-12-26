using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model.FreeCompany;

/// <summary>
/// Definition container for one Free Company search result entry
/// </summary>
public class FreeCompanySearchEntryDefinition : PagedEntryDefinition
{
    /// <summary>
    /// Crest layers
    /// </summary>
    [JsonPropertyName("CREST_LAYERS")]
    public IconLayersDefinition CrestLayers { get; set; }

    /// <summary>
    /// FC Id
    /// </summary>
    [JsonPropertyName("ID")]
    public DefinitionsPack Id { get; set; }

    /// <summary>
    /// Grand Company
    /// </summary>
    [JsonPropertyName("GRAND_COMPANY")]
    public DefinitionsPack GrandCompany { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("NAME")]
    public DefinitionsPack Name { get; set; }

    /// <summary>
    /// World
    /// </summary>
    [JsonPropertyName("SERVER")]
    public DefinitionsPack Server { get; set; }

    /// <summary>
    /// FC active status
    /// </summary>
    [JsonPropertyName("ACTIVE")]
    public DefinitionsPack Active { get; set; }

    /// <summary>
    /// Active member count
    /// </summary>
    [JsonPropertyName("ACTIVE_MEMBERS")]
    public DefinitionsPack ActiveMembers { get; set; }

    /// <summary>
    /// Recruitment status
    /// </summary>
    [JsonPropertyName("RECRUITMENT_OPEN")]
    public DefinitionsPack RecruitmentOpen { get; set; }

    /// <summary>
    /// Estate state
    /// </summary>
    [JsonPropertyName("ESTATE_BUILT")]
    public DefinitionsPack EstateBuilt { get; set; }

    /// <summary>
    /// Formation date
    /// </summary>
    [JsonPropertyName("FORMED")]
    public DefinitionsPack Formed { get; set; }
}