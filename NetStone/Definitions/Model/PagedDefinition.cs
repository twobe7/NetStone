using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model;

/// <summary>
/// Base definition for paged results
/// </summary>
public class PagedDefinition<TEntry> : IDefinition where TEntry : PagedEntryDefinition
{
    /// <summary>
    /// Root node
    /// </summary>
    [JsonPropertyName("ROOT")]
    public DefinitionsPack Root { get; set; }

    /// <summary>
    /// Definition for one entry
    /// </summary>
    [JsonPropertyName("ENTRY")]
    public TEntry Entry { get; set; }

    /// <summary>
    /// Info about pages
    /// </summary>
    [JsonPropertyName("PAGE_INFO")]
    public DefinitionsPack PageInfo { get; set; }

    /// <summary>
    /// Button for next page
    /// </summary>
    [JsonPropertyName("LIST_NEXT_BUTTON")]
    public DefinitionsPack ListNextButton { get; set; }

    /// <summary>
    /// DEfinition for node for empty results
    /// </summary>
    [JsonPropertyName("NO_RESULTS_FOUND")]
    public DefinitionsPack? NoResultsFound { get; set; }
}

/// <summary>
/// Base definition of a paged entry
/// </summary>
public class PagedEntryDefinition
{
    /// <summary>
    /// Root node of entry
    /// </summary>
    [JsonPropertyName("ROOT")]
    public DefinitionsPack Root { get; set; }
}