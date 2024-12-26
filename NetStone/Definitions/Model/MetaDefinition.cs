using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model;

/// <summary>
/// Hold information about the uri for which the definition packs are valid
/// </summary>
public class ApplicableUris
{
    /// <summary>
    /// Uri that holds information about FC focus
    /// </summary>
    [JsonPropertyName("freecompany/focus.json")]
    public string? FreecompanyFocusJson { get; set; }

    /// <summary>
    /// Uri that holds information about FC
    /// </summary>
    [JsonPropertyName("freecompany/freecompany.json")]
    public string? FreecompanyFreecompanyJson { get; set; }

    /// <summary>
    /// Uri that holds information about FC members
    /// </summary>
    [JsonPropertyName("freecompany/members.json")]
    public string? FreecompanyMembersJson { get; set; }

    /// <summary>
    /// Uri that holds information about FC reputation
    /// </summary>
    [JsonPropertyName("freecompany/reputation.json")]
    public string? FreecompanyReputationJson { get; set; }

    /// <summary>
    /// Uri that holds information about FC recruitment
    /// </summary>
    [JsonPropertyName("freecompany/seeking.json")]
    public string? FreecompanySeekingJson { get; set; }

    /// <summary>
    /// Uri that holds information about Cross World Link Shells
    /// </summary>
    [JsonPropertyName("cwls/cwls.json")]
    public string? LinkshellCrossworldCwlsJson { get; set; }

    /// <summary>
    /// Uri that holds information about Cross World Link Shell members
    /// </summary>
    [JsonPropertyName("cwls/members.json")]
    public string? LinkshellCrossworldMembersJson { get; set; }


    /// <summary>
    /// Uri that holds information about Link Shells
    /// </summary>
    [JsonPropertyName("linkshell/ls.json")]
    public string? LinkshellLsJson { get; set; }


    /// <summary>
    /// Uri that holds information about Link Shell members
    /// </summary>
    [JsonPropertyName("linkshell/members.json")]
    public string? LinkshellMembersJson { get; set; }


    /// <summary>
    /// Uri that holds information about a character's achievements
    /// </summary>
    [JsonPropertyName("profile/achievements.json")]
    public string? ProfileAchievementsJson { get; set; }

    /// <summary>
    /// Uri that holds information about a character's attributes
    /// </summary>
    [JsonPropertyName("profile/attributes.json")]
    public string? ProfileAttributesJson { get; set; }

    /// <summary>
    /// Uri that holds information about a character
    /// </summary>
    [JsonPropertyName("profile/character.json")]
    public string? ProfileCharacterJson { get; set; }

    /// <summary>
    /// Uri that holds information about a character jobs/classes
    /// </summary>
    [JsonPropertyName("profile/classjob.json")]
    public string? ProfileClassjobJson { get; set; }

    /// <summary>
    /// Uri that holds information about a character's gear
    /// </summary>
    [JsonPropertyName("profile/gearset.json")]
    public string? ProfileGearsetJson { get; set; }

    /// <summary>
    /// Uri that holds information about a character's minions
    /// </summary>
    [JsonPropertyName("profile/minion.json")]
    public string? ProfileMinionJson { get; set; }

    /// <summary>
    /// Uri that holds information about a character's mounts
    /// </summary>
    [JsonPropertyName("profile/mount.json")]
    public string? ProfileMountJson { get; set; }

    /// <summary>
    /// Uri that holds information about a PVP team's members
    /// </summary>
    [JsonPropertyName("pvpteam/members.json")]
    public string? PvpteamMembersJson { get; set; }

    /// <summary>
    /// Uri that holds information about a PVP team
    /// </summary>
    [JsonPropertyName("pvpteam/pvpteam.json")]
    public string? PvpteamPvpteamJson { get; set; }

    /// <summary>
    /// Uri that let's you search characters
    /// </summary>
    [JsonPropertyName("search/character.json")]
    public string? SearchCharacterJson { get; set; }

    /// <summary>
    /// Uri that let's you search Cross World Link Shells
    /// </summary>
    [JsonPropertyName("search/cwls.json")]
    public string? SearchCwlsJson { get; set; }

    /// <summary>
    /// Uri that let's you search Free Companies
    /// </summary>
    [JsonPropertyName("search/freecompany.json")]
    public string? SearchFreecompanyJson { get; set; }

    /// <summary>
    /// Uri that let's you search Linkshells
    /// </summary>
    [JsonPropertyName("search/linkshell.json")]
    public string? SearchLinkshellJson { get; set; }

    /// <summary>
    /// Uri that let's you search PvP teams
    /// </summary>
    [JsonPropertyName("search/pvpteam.json")]
    public string? SearchPvpteamJson { get; set; }
}

/// <summary>
/// Holds meta information regarding the definitions
/// </summary>
public class MetaDefinition : IDefinition
{
    /// <summary>
    /// Version
    /// </summary>
    [JsonPropertyName("version")]
    public string Version { get; set; }

    /// <summary>
    /// User Agent used to get desktop version of Lodestone
    /// </summary>
    [JsonPropertyName("userAgentDesktop")]
    public string UserAgentDesktop { get; set; }

    /// <summary>
    /// User Agent used to get mobile version of Lodestone
    /// </summary>
    [JsonPropertyName("userAgentMobile")]
    public string UserAgentMobile { get; set; }

    /// <summary>
    /// Collection of Uris for which the definition packs are valid
    /// </summary>
    [JsonPropertyName("applicableUris")]
    public ApplicableUris ApplicableUris { get; set; }
}