using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model.Character;

/// <summary>
/// Models the definition of the achievement list
/// </summary>
public class CharacterAchievementDefinition : PagedDefinition<CharacterAchievementEntryDefinition>
{
    /// <summary>
    /// Total number of achievements earned by this character
    /// </summary>
    [JsonPropertyName("TOTAL_ACHIEVEMENTS")]
    public DefinitionsPack TotalAchievements { get; set; }

    /// <summary>
    /// Total achievement points earned by this character
    /// </summary>
    [JsonPropertyName("ACHIEVEMENT_POINTS")]
    public DefinitionsPack AchievementPoints { get; set; }

    /// <summary>
    /// Full text displayed for this achievement
    /// </summary>
    [JsonPropertyName("ACTIVITY_DESCRIPTION")]
    public DefinitionsPack ActivityDescription { get; set; }
}
/// <summary>
/// Models the definition of one achievement entry for a character
/// </summary>
public class CharacterAchievementEntryDefinition : PagedEntryDefinition
{
    /// <summary>
    /// Achievement name
    /// </summary>
    [JsonPropertyName("NAME")]
    public DefinitionsPack Name { get; set; }

    /// <summary>
    /// Id of this achievement
    /// </summary>
    [JsonPropertyName("ID")]
    public DefinitionsPack Id { get; set; }

    /// <summary>
    /// Time when this achievement was earned
    /// </summary>
    [JsonPropertyName("TIME")]
    public DefinitionsPack Time { get; set; }
}