﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.Character;
using NetStone.Definitions.Model.CWLS;
using NetStone.Definitions.Model.FreeCompany;
using NetStone.Definitions.Model.Linkshell;
using System.Text.Json;

namespace NetStone.Definitions;

/// <summary>
/// Holds the definitions on how to find and parse values from Lodestone HTML
/// </summary>
public class XivApiDefinitionsContainer : DefinitionsContainer
{
    private const string DefinitionRepoBase = "https://raw.githubusercontent.com/xivapi/lodestone-css-selectors/main/";

    private readonly HttpClient client;

    /// <summary>
    /// Constructs this class without populating definitions
    /// </summary>
    public XivApiDefinitionsContainer()
    {
        this.client = new HttpClient
        {
            BaseAddress = new Uri(DefinitionRepoBase),
        };
    }

    /// <summary>
    /// Fetches current CSS selector definitions from xivapi/lodestone-css-selectors github repository.
    /// </summary>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="FormatException"></exception>
    /// <returns>Task for this operation</returns>
    public override async Task Reload()
    {
        this.Meta = await GetDefinition<MetaDefinition>("meta.json");

        this.Character = await GetDefinition<CharacterDefinition>("profile/character.json");
        this.ClassJob = await GetDefinition<CharacterClassJobDefinition>("profile/classjob.json");
        this.Gear = await GetDefinition<CharacterGearDefinition>("profile/gearset.json");
        this.Attributes = await GetDefinition<CharacterAttributesDefinition>("profile/attributes.json");
        this.Achievement = await GetDefinition<CharacterAchievementDefinition>("profile/achievements.json");
        this.Mount = await GetDefinition<CharacterMountDefinition>("profile/mount.json");
        this.Minion = await GetDefinition<CharacterMinionDefinition>("profile/minion.json");

        this.FreeCompany = await GetDefinition<FreeCompanyDefinition>("freecompany/freecompany.json");
        this.FreeCompanyFocus = await GetDefinition<FreeCompanyFocusDefinition>("freecompany/focus.json");
        this.FreeCompanyReputation =
            await GetDefinition<FreeCompanyReputationDefinition>("freecompany/reputation.json");

        this.FreeCompanyMembers = await GetDefinition<PagedDefinition<FreeCompanyMembersEntryDefinition>>("freecompany/members.json");

        this.CharacterSearch = await GetDefinition<PagedDefinition<CharacterSearchEntryDefinition>>("search/character.json");
        this.FreeCompanySearch = await GetDefinition<PagedDefinition<FreeCompanySearchEntryDefinition>>("search/freecompany.json");
        
        this.CrossworldLinkshell = await GetDefinition<CrossworldLinkshellDefinition>("cwls/cwls.json");
        this.CrossworldLinkshellMember = await GetDefinition<PagedDefinition<CrossworldLinkshellMemberEntryDefinition>>("cwls/members.json");
        this.CrossworldLinkshellSearch = await GetDefinition<PagedDefinition<CrossworldLinkshellSearchEntryDefinition>>("search/cwls.json");
        
        this.Linkshell = await GetDefinition<LinkshellDefinition>("linkshell/ls.json");
        this.LinkshellMember = await GetDefinition<PagedDefinition<LinkshellMemberEntryDefinition>>("linkshell/members.json");
        this.LinkshellSearch = await GetDefinition<PagedDefinition<LinkshellSearchEntryDefinition>>("search/linkshell.json");
    }

    private async Task<T> GetDefinition<T>(string path) where T : IDefinition
    {
        var json = await this.client.GetStringAsync(path);
        var result = JsonSerializer.Deserialize<T>(json);
        return result == null ? throw new FormatException($"Could not parse definitions in {path}.") : result;
    }

    /// <inheritdoc />
    public override void Dispose()
    {
        this.client.Dispose();
    }
}