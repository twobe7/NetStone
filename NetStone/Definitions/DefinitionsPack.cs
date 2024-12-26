using System;
using System.Text.Json.Serialization;

namespace NetStone.Definitions;

/// <summary>
/// Models the definition on how to extract information from the Lodestone HTML document
/// </summary>
public class DefinitionsPack
{
    /// <summary>
    /// Hold a CSS selector to get the relevant html node from the DOM
    /// </summary>
    [JsonPropertyName("selector")]
    public string Selector { get; set; }

    /// <summary>
    /// A perl regex to extract the relevant information from the inner text of the relevant node
    /// </summary>
    [JsonPropertyName("regex")]
    public string? PerlBasedRegex { get; set; }

    /// <summary>
    /// C# usable regex based on <see cref="PerlBasedRegex"/>
    /// </summary>
    public string? Regex => this.PerlBasedRegex?.Replace("(?P<", "(?<", StringComparison.InvariantCulture);

    //Never used
    //[JsonPropertyName("or")] public string Description { get; set; }

    /// <summary>
    /// HTML attribute that holds information. Only set if data is not in the inner text
    /// </summary>
    [JsonPropertyName("attribute")]
    public string? Attribute { get; set; }
}