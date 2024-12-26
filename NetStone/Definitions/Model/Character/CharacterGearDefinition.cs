using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model.Character;

/// <summary>
/// Definitions for a slot of gear in character profile
/// </summary>
public class GearEntryDefinition
{
    /// <summary>
    /// Name of the item
    /// </summary>
    [JsonPropertyName("NAME")]
    public DefinitionsPack Name { get; set; }

    /// <summary>
    /// Link to Eorzea Database for item
    /// </summary>
    [JsonPropertyName("DB_LINK")]
    public DefinitionsPack DbLink { get; set; }

    /// <summary>
    /// Name of glamour
    /// </summary>
    [JsonPropertyName("MIRAGE_NAME")]
    public DefinitionsPack MirageName { get; set; }

    /// <summary>
    /// Link to Eorzea Database for glamour item
    /// </summary>
    [JsonPropertyName("MIRAGE_DB_LINK")]
    public DefinitionsPack MirageDbLink { get; set; }

    /// <summary>
    /// Die of the item
    /// </summary>
    [JsonPropertyName("STAIN")]
    public DefinitionsPack Stain { get; set; }

    /// <summary>
    /// Materia Slot 1
    /// </summary>
    [JsonPropertyName("MATERIA_1")]
    public DefinitionsPack Materia1 { get; set; }

    /// <summary>
    /// Materia Slot 2
    /// </summary>
    [JsonPropertyName("MATERIA_2")]
    public DefinitionsPack Materia2 { get; set; }

    /// <summary>
    /// Materia Slot 3
    /// </summary>
    [JsonPropertyName("MATERIA_3")]
    public DefinitionsPack Materia3 { get; set; }

    /// <summary>
    /// Materia Slot 4
    /// </summary>
    [JsonPropertyName("MATERIA_4")]
    public DefinitionsPack Materia4 { get; set; }

    /// <summary>
    /// Materia Slot 5
    /// </summary>
    [JsonPropertyName("MATERIA_5")]
    public DefinitionsPack Materia5 { get; set; }

    /// <summary>
    /// Name of creator/crafter of this item (if applicable)
    /// </summary>
    [JsonPropertyName("CREATOR_NAME")]
    public DefinitionsPack CreatorName { get; set; }
    
    /// <summary>
    /// Item level of the item
    /// </summary>
    [JsonPropertyName("ITEM_LEVEL")]
    public DefinitionsPack ItemLevel { get; set; }
}

/// <summary>
/// Definition for Soul Crystal slot
/// </summary>
public class SoulcrystalEntryDefinition
{
    /// <summary>
    /// Name of the item
    /// </summary>
    [JsonPropertyName("NAME")]
    public DefinitionsPack Name { get; set; }
}

/// <summary>
/// Definition for all gear of the character
/// </summary>
public class CharacterGearDefinition : IDefinition
{
    /// <summary>
    /// Main hand weapon
    /// </summary>
    [JsonPropertyName("MAINHAND")]
    public GearEntryDefinition Mainhand { get; set; }

    /// <summary>
    /// Off hand weapon
    /// </summary>
    [JsonPropertyName("OFFHAND")]
    public GearEntryDefinition Offhand { get; set; }

    /// <summary>
    /// Head piece
    /// </summary>
    [JsonPropertyName("HEAD")]
    public GearEntryDefinition Head { get; set; }

    /// <summary>
    /// Chest piece
    /// </summary>
    [JsonPropertyName("BODY")]
    public GearEntryDefinition Body { get; set; }

    /// <summary>
    /// Hand piece
    /// </summary>
    [JsonPropertyName("HANDS")]
    public GearEntryDefinition Hands { get; set; }

    /// <summary>
    /// Waist
    /// </summary>
    [JsonPropertyName("WAIST")]
    public GearEntryDefinition Waist { get; set; }

    /// <summary>
    /// Legs
    /// </summary>
    [JsonPropertyName("LEGS")]
    public GearEntryDefinition Legs { get; set; }

    /// <summary>
    /// Feet
    /// </summary>
    [JsonPropertyName("FEET")]
    public GearEntryDefinition Feet { get; set; }

    /// <summary>
    /// Earrings
    /// </summary>
    [JsonPropertyName("EARRINGS")]
    public GearEntryDefinition Earrings { get; set; }

    /// <summary>
    /// Necklace
    /// </summary>
    [JsonPropertyName("NECKLACE")]
    public GearEntryDefinition Necklace { get; set; }

    /// <summary>
    /// Braccelets
    /// </summary>
    [JsonPropertyName("BRACELETS")]
    public GearEntryDefinition Bracelets { get; set; }

    /// <summary>
    /// Right ring
    /// </summary>
    [JsonPropertyName("RING1")]
    public GearEntryDefinition Ring1 { get; set; }

    /// <summary>
    /// Left ring
    /// </summary>
    [JsonPropertyName("RING2")]
    public GearEntryDefinition Ring2 { get; set; }

    /// <summary>
    /// Soul Crystal
    /// </summary>
    [JsonPropertyName("SOULCRYSTAL")]
    public SoulcrystalEntryDefinition Soulcrystal { get; set; }
}