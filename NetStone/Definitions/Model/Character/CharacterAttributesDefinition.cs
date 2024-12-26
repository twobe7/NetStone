using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model.Character;

/// <summary>
/// Node definitions for a character's attributes
/// </summary>
public class CharacterAttributesDefinition : IDefinition
{
    /// <summary>
    /// Strength
    /// </summary>
    [JsonPropertyName("STRENGTH")]
    public DefinitionsPack Strength { get; set; }

    /// <summary>
    /// Dexterity
    /// </summary>
    [JsonPropertyName("DEXTERITY")]
    public DefinitionsPack Dexterity { get; set; }

    /// <summary>
    /// Vitality
    /// </summary>
    [JsonPropertyName("VITALITY")]
    public DefinitionsPack Vitality { get; set; }

    /// <summary>
    /// Intelligence
    /// </summary>
    [JsonPropertyName("INTELLIGENCE")]
    public DefinitionsPack Intelligence { get; set; }

    /// <summary>
    /// Mind
    /// </summary>
    [JsonPropertyName("MIND")]
    public DefinitionsPack Mind { get; set; }

    /// <summary>
    /// Critical Hit
    /// </summary>
    [JsonPropertyName("CRITICAL_HIT_RATE")]
    public DefinitionsPack CriticalHitRate { get; set; }

    /// <summary>
    /// Determination
    /// </summary>
    [JsonPropertyName("DETERMINATION")]
    public DefinitionsPack Determination { get; set; }

    /// <summary>
    /// Direct Hit
    /// </summary>
    [JsonPropertyName("DIRECT_HIT_RATE")]
    public DefinitionsPack DirectHitRate { get; set; }

    /// <summary>
    /// Defense
    /// </summary>
    [JsonPropertyName("DEFENSE")]
    public DefinitionsPack Defense { get; set; }

    /// <summary>
    /// Magic Defense
    /// </summary>
    [JsonPropertyName("MAGIC_DEFENSE")]
    public DefinitionsPack MagicDefense { get; set; }

    /// <summary>
    /// Attack Power
    /// </summary>
    [JsonPropertyName("ATTACK_POWER")]
    public DefinitionsPack AttackPower { get; set; }

    /// <summary>
    /// Skill Speed
    /// </summary>
    [JsonPropertyName("SKILL_SPEED")]
    public DefinitionsPack SkillSpeed { get; set; }

    /// <summary>
    /// Attack Magic Potency
    /// </summary>
    [JsonPropertyName("ATTACK_MAGIC_POTENCY")]
    public DefinitionsPack AttackMagicPotency { get; set; }

    /// <summary>
    /// Healing Magic Potency
    /// </summary>
    [JsonPropertyName("HEALING_MAGIC_POTENCY")]
    public DefinitionsPack HealingMagicPotency { get; set; }

    /// <summary>
    /// Spell Speed
    /// </summary>
    [JsonPropertyName("SPELL_SPEED")]
    public DefinitionsPack SpellSpeed { get; set; }

    /// <summary>
    /// Tenacity
    /// </summary>
    [JsonPropertyName("TENACITY")]
    public DefinitionsPack Tenacity { get; set; }

    /// <summary>
    /// Piety
    /// </summary>
    [JsonPropertyName("PIETY")]
    public DefinitionsPack Piety { get; set; }

    /// <summary>
    /// Hit Points
    /// </summary>
    [JsonPropertyName("HP")]
    public DefinitionsPack Hp { get; set; }

    /// <summary>
    /// MP, GP or CP depending on Job
    /// </summary>
    [JsonPropertyName("MP_GP_CP")]
    public DefinitionsPack MpGpCp { get; set; }

    /// <summary>
    /// Name of <see cref="MpGpCp"/>
    /// </summary>
    [JsonPropertyName("MP_GP_CP_PARAMETER_NAME")]
    public DefinitionsPack MpGpCpParameterName { get; set; }
}