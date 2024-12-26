﻿using System.Text.Json.Serialization;

namespace NetStone.Definitions.Model.Character;

/// <summary>
/// General class for a category of collectables
/// </summary>
public interface CharacterCollectableDefinition : IDefinition
{
    /// <summary>
    /// Get node definition for and entry
    /// </summary>
    /// <returns>Node definition</returns>
    public CollectableNodeDefinition GetDefinitions();
}

/// <summary>
/// Definition pack for a character's mounts
/// </summary>
public class CharacterMountDefinition : CharacterCollectableDefinition
{
    /// <summary>
    /// Node definition for mounts
    /// </summary>
    [JsonPropertyName("MOUNTS")]
    public CollectableNodeDefinition Mounts { get; set; }

    ///<inheritdoc />
    public CollectableNodeDefinition GetDefinitions() => this.Mounts;
}

/// <summary>
/// Definition pack for a character's minions
/// </summary>
public class CharacterMinionDefinition : CharacterCollectableDefinition
{
    /// <summary>
    /// Noe definition for minions
    /// </summary>
    [JsonPropertyName("MINIONS")]
    public CollectableNodeDefinition Minions { get; set; }

    ///<inheritdoc />
    public CollectableNodeDefinition GetDefinitions() => this.Minions;
}

/// <summary>
/// General definition for a collectable
/// </summary>
public class CollectableNodeDefinition
{
    /// <summary>
    /// Root node of collectable entry
    /// </summary>
    [JsonPropertyName("ROOT")]
    public DefinitionsPack Root { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("NAME")]
    public DefinitionsPack Name { get; set; }
}