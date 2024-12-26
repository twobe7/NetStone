using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model.Character;

/// <summary>
/// Definitions for Bozja jobs
/// </summary>
public class ClassJobBozjaDefinition
{
    /// <summary>
    /// Level
    /// </summary>
    [JsonPropertyName("LEVEL")]
    public DefinitionsPack LEVEL { get; set; }

    /// <summary>
    /// Mettle
    /// </summary>
    [JsonPropertyName("METTLE")]
    public DefinitionsPack METTLE { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("NAME")]
    public DefinitionsPack NAME { get; set; }
}

/// <summary>
/// Definitions for Eureka jobs
/// </summary>
public class ClassJobEurekaDefinition
{
    /// <summary>
    /// Experience
    /// </summary>
    [JsonPropertyName("EXP")]
    public DefinitionsPack Exp { get; set; }

    /// <summary>
    /// Level
    /// </summary>
    [JsonPropertyName("LEVEL")]
    public DefinitionsPack Level { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("NAME")]
    public DefinitionsPack Name { get; set; }
}

/// <summary>
/// Definitions for Battle jobs, Crafter and Gatherer
/// </summary>
public class ClassJobEntryDefinition
{
    /// <summary>
    /// Level
    /// </summary>
    [JsonPropertyName("LEVEL")]
    public DefinitionsPack Level { get; set; }

    /// <summary>
    /// Indicates of the job is Unlocked
    /// </summary>
    [JsonPropertyName("UNLOCKSTATE")]
    public DefinitionsPack UnlockState { get; set; }

    /// <summary>
    /// Experience
    /// </summary>
    [JsonPropertyName("EXP")]
    public DefinitionsPack Exp { get; set; }
}

/// <summary>
/// Definition container for all classes and jobs of a character
/// </summary>
public class CharacterClassJobDefinition : IDefinition
{
    /// <summary>
    /// Bozja job
    /// </summary>
    [JsonPropertyName("BOZJA")]
    public ClassJobBozjaDefinition Bozja { get; set; }

    /// <summary>
    /// Eureka
    /// </summary>
    [JsonPropertyName("EUREKA")]
    public ClassJobEurekaDefinition Eureka { get; set; }

    /// <summary>
    /// Paladin (includes Gladiator)
    /// </summary>
    [JsonPropertyName("PALADIN")]
    public ClassJobEntryDefinition Paladin { get; set; }

    /// <summary>
    /// Warrior (includes Marauder)
    /// </summary>
    [JsonPropertyName("WARRIOR")]
    public ClassJobEntryDefinition Warrior { get; set; }

    /// <summary>
    /// Dark Knight
    /// </summary>
    [JsonPropertyName("DARKKNIGHT")]
    public ClassJobEntryDefinition DarkKnight { get; set; }

    /// <summary>
    /// Gunbreaker
    /// </summary>
    [JsonPropertyName("GUNBREAKER")]
    public ClassJobEntryDefinition Gunbreaker { get; set; }

    /// <summary>
    /// Monk (includes Pugilist)
    /// </summary>
    [JsonPropertyName("MONK")]
    public ClassJobEntryDefinition Monk { get; set; }

    /// <summary>
    /// Dragoon (include Lancer)
    /// </summary>
    [JsonPropertyName("DRAGOON")]
    public ClassJobEntryDefinition Dragoon { get; set; }

    /// <summary>
    /// Ninja (includes Rogue)
    /// </summary>
    [JsonPropertyName("NINJA")]
    public ClassJobEntryDefinition Ninja { get; set; }

    /// <summary>
    /// Samurai
    /// </summary>
    [JsonPropertyName("SAMURAI")]
    public ClassJobEntryDefinition Samurai { get; set; }

    /// <summary>
    /// Reaper
    /// </summary>
    [JsonPropertyName("REAPER")]
    public ClassJobEntryDefinition Reaper { get; set; }
    
    /// <summary>
    /// Viper
    /// </summary>
    [JsonPropertyName("VIPER")]
    public ClassJobEntryDefinition Viper { get; set; }

    /// <summary>
    /// White Mage (includes Conjurer)
    /// </summary>
    [JsonPropertyName("WHITEMAGE")]
    public ClassJobEntryDefinition Whitemage { get; set; }

    /// <summary>
    /// Scholar
    /// </summary>
    [JsonPropertyName("SCHOLAR")]
    public ClassJobEntryDefinition Scholar { get; set; }

    /// <summary>
    /// Astrologian
    /// </summary>
    [JsonPropertyName("ASTROLOGIAN")]
    public ClassJobEntryDefinition Astrologian { get; set; }

    /// <summary>
    /// Sage
    /// </summary>
    [JsonPropertyName("SAGE")]
    public ClassJobEntryDefinition Sage { get; set; }

    /// <summary>
    /// Bard
    /// </summary>
    [JsonPropertyName("BARD")]
    public ClassJobEntryDefinition Bard { get; set; }

    /// <summary>
    /// Machinist
    /// </summary>
    [JsonPropertyName("MACHINIST")]
    public ClassJobEntryDefinition Machinist { get; set; }

    /// <summary>
    /// Dancer
    /// </summary>
    [JsonPropertyName("DANCER")]
    public ClassJobEntryDefinition Dancer { get; set; }

    /// <summary>
    /// Black Mage
    /// </summary>
    [JsonPropertyName("BLACKMAGE")]
    public ClassJobEntryDefinition Blackmage { get; set; }

    /// <summary>
    /// Summoner
    /// </summary>
    [JsonPropertyName("SUMMONER")]
    public ClassJobEntryDefinition Summoner { get; set; }

    /// <summary>
    /// Red Mage
    /// </summary>
    [JsonPropertyName("REDMAGE")]
    public ClassJobEntryDefinition Redmage { get; set; }
    
    /// <summary>
    /// Pictomancer
    /// </summary>
    [JsonPropertyName("PICTOMANCER")]
    public ClassJobEntryDefinition Pictomancer { get; set; }

    /// <summary>
    /// Blue Mage
    /// </summary>
    [JsonPropertyName("BLUEMAGE")]
    public ClassJobEntryDefinition Bluemage { get; set; }

    /// <summary>
    /// Carpenter
    /// </summary>
    [JsonPropertyName("CARPENTER")]
    public ClassJobEntryDefinition Carpenter { get; set; }

    /// <summary>
    /// Blacksmith
    /// </summary>
    [JsonPropertyName("BLACKSMITH")]
    public ClassJobEntryDefinition Blacksmith { get; set; }

    /// <summary>
    /// Armorer
    /// </summary>
    [JsonPropertyName("ARMORER")]
    public ClassJobEntryDefinition Armorer { get; set; }

    /// <summary>
    /// Goldsmith
    /// </summary>
    [JsonPropertyName("GOLDSMITH")]
    public ClassJobEntryDefinition Goldsmith { get; set; }

    /// <summary>
    /// Leatherworker
    /// </summary>
    [JsonPropertyName("LEATHERWORKER")]
    public ClassJobEntryDefinition Leatherworker { get; set; }

    /// <summary>
    /// Weaver
    /// </summary>
    [JsonPropertyName("WEAVER")]
    public ClassJobEntryDefinition Weaver { get; set; }

    /// <summary>
    /// Alchemist
    /// </summary>
    [JsonPropertyName("ALCHEMIST")]
    public ClassJobEntryDefinition Alchemist { get; set; }

    /// <summary>
    /// Culinarian
    /// </summary>
    [JsonPropertyName("CULINARIAN")]
    public ClassJobEntryDefinition Culinarian { get; set; }

    /// <summary>
    /// Miner
    /// </summary>
    [JsonPropertyName("MINER")]
    public ClassJobEntryDefinition Miner { get; set; }

    /// <summary>
    ///Botanist
    /// </summary>
    [JsonPropertyName("BOTANIST")]
    public ClassJobEntryDefinition Botanist { get; set; }

    /// <summary>
    /// Fisher
    /// </summary>
    [JsonPropertyName("FISHER")]
    public ClassJobEntryDefinition Fisher { get; set; }
}