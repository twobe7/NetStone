using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NetStone.GameData.Packs;
using NetStone.Model.Parseables.Character;
using NetStone.Search.Character;
using NetStone.Search.FreeCompany;
using NetStone.Search.Linkshell;
using NetStone.StaticData;
using NUnit.Framework;
using SortKind = NetStone.Search.Character.SortKind;

namespace NetStone.Test;

public class Tests
{
    private LodestoneClient lodestone;

    private const string TestCharacterIdFull = "24471319";
    private const string TestCharacterIdEureka = "14556736";
    private const string TestLinkshell = "18577348462979918";
    private const string TestCWLS = "097b99377634f9980eb0cf0b4ff6cf86807feb2c";
    private const string TestCharacterIdEureka2 = "6787158";
    private const string TestCharacterIdBare = "9426169";
    private const string TestCharacterIdDoH = "42256897";

    private const string TestFreeCompany = "9232379236109629819";
    private const string TestFreeCompanyRecruiting = "9232660711086374997";

    [SetUp]
    public async Task Setup()
    {
        var gameData =
            PacksGameDataProvider.Load(new DirectoryInfo("../../../../lib/lodestone-data-exports/pack"));
        this.lodestone = await LodestoneClient.GetClientAsync(gameData);
    }

    [Test]
    public void CheckDefinitions()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.lodestone.Definitions.Character, Is.Not.Null);
            Assert.That(this.lodestone.Definitions.ClassJob, Is.Not.Null);
            Assert.That(this.lodestone.Definitions.Gear, Is.Not.Null);
            Assert.That(this.lodestone.Definitions.Achievement, Is.Not.Null);
        });
    }

    [Test]
    public async Task CheckCharacterSearch()
    {
        var query = new CharacterSearchQuery
        {
            CharacterName = "Bob",
            DataCenter = "Aether",
            Role = Role.Dps,
            Race = Race.Hyur,
            GrandCompany = GrandCompany.ImmortalFlames | GrandCompany.Maelstrom | GrandCompany.OrderOfTheTwinAdder,
            Language = Language.English | Language.German | Language.French,
            SortKind = SortKind.NameZtoA,
        };

        var page = await this.lodestone.SearchCharacter(query);

        Assert.That(page, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(page.NumPages, Is.GreaterThanOrEqualTo(4));
            Assert.That(page.CurrentPage, Is.EqualTo(1));
        });

        var cResults = 0;
        var cPages = 1;

        do
        {
            Assert.That(page.CurrentPage, Is.EqualTo(cPages));

            foreach (var searchResult in page.Results)
            {
                Console.WriteLine(
                    $"{page.CurrentPage}({cPages}) - {cResults} - {searchResult.Name} - {searchResult.Id}");
                cResults++;
            }

            cPages++;

            page = await page.GetNextPage();
        } while (page != null);
    }

    [Test]
    public async Task CheckFreeCompany()
    {
        var fc = await this.lodestone.GetFreeCompany(TestFreeCompany);

        Assert.That(fc, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(fc.GrandCompany, Is.EqualTo("Maelstrom"));
            Assert.That(fc.Name, Is.EqualTo("Hell On Aura"));
            Assert.That(fc.Tag, Is.EqualTo("«Fury»"));
            Assert.That(fc.Slogan, Is.EqualTo("I EAT BABIES FOR BREAKFAST - KAIVE"));
            Assert.That(fc.Formed, Is.EqualTo(new DateTime(2019, 01, 14, 04, 22, 05)));
            Assert.That(fc.ActiveMemberCount, Is.GreaterThanOrEqualTo(35));
            Assert.That(fc.Rank, Is.EqualTo(30));
            Assert.That(fc.ActiveState, Is.EqualTo("Always"));
            Assert.That(fc.Recruitment, Is.EqualTo("Open"));
        });

        //Reputation
        Assert.That(fc.Reputation, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(fc.Reputation.Maelstrom.Name, Is.EqualTo("Maelstrom"));
            Assert.That(fc.Reputation.Maelstrom.Rank, Is.EqualTo("Allied"));
            Assert.That(fc.Reputation.Maelstrom.Progress, Is.EqualTo(100));

            Assert.That(fc.Reputation.Adders.Name, Is.EqualTo("Order of the Twin Adder"));
            Assert.That(fc.Reputation.Adders.Rank, Is.EqualTo("Neutral"));
            Assert.That(fc.Reputation.Adders.Progress, Is.EqualTo(0));

            Assert.That(fc.Reputation.Flames.Name, Is.EqualTo("Immortal Flames"));
            Assert.That(fc.Reputation.Flames.Rank, Is.EqualTo("Neutral"));
            Assert.That(fc.Reputation.Flames.Progress, Is.EqualTo(0));
        });

        //Estate
        Assert.That(fc.Estate, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(fc.Estate.Exists);
            Assert.That(fc.Estate.Name, Is.EqualTo("Aura's Kitchen Fire"));
            Assert.That(fc.Estate.Plot, Is.EqualTo("Plot 18, 17 Ward, Empyreum (Medium)"));
        });

        //Focus
        //todo: selector does not work
        Assert.That(fc.Focus, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(fc.Focus.RolePlay.Name, Is.EqualTo("Role-playing"));
            Assert.That(!fc.Focus.RolePlay.IsEnabled);
            Assert.That(fc.Focus.RolePlay.Icon?.AbsoluteUri, Is.Not.Null);

            Assert.That(fc.Focus.Leveling.Name, Is.EqualTo("Leveling"));
            Assert.That(fc.Focus.Leveling.IsEnabled);
            Assert.That(fc.Focus.Leveling.Icon?.AbsoluteUri, Is.Not.Null);

            Assert.That(fc.Focus.Casual.Name, Is.EqualTo("Casual"));
            Assert.That(fc.Focus.Casual.IsEnabled);

            Assert.That(fc.Focus.Hardcore.Name, Is.EqualTo("Hardcore"));
            Assert.That(!fc.Focus.Hardcore.IsEnabled);

            Assert.That(fc.Focus.Dungeons.Name, Is.EqualTo("Dungeons"));
            Assert.That(fc.Focus.Dungeons.IsEnabled);

            Assert.That(fc.Focus.Guildhests.Name, Is.EqualTo("Guildhests"));
            Assert.That(!fc.Focus.Guildhests.IsEnabled);

            Assert.That(fc.Focus.Trials.Name, Is.EqualTo("Trials"));
            Assert.That(fc.Focus.Trials.IsEnabled);

            Assert.That(fc.Focus.Raids.Name, Is.EqualTo("Raids"));
            Assert.That(fc.Focus.Raids.IsEnabled);

            Assert.That(fc.Focus.PvP.Name, Is.EqualTo("PvP"));
            Assert.That(!fc.Focus.PvP.IsEnabled);
        });

        //Members
        var members = await fc.GetMembers();
        Assert.That(members, Is.Not.Null);

        do
        {
            foreach (var searchResult in members.Members)
            {
                Console.WriteLine(
                    $"{members.CurrentPage} - {searchResult.Name} - {searchResult.RankIcon} - {searchResult.Id} - {searchResult.FreeCompanyRankIcon} - {searchResult.FreeCompanyRank}");
            }

            members = await members.GetNextPage();
        } while (members != null);
    }

    [Test]
    public async Task CheckFreeCompanyRecruiting()
    {
        var fc = await this.lodestone.GetFreeCompany(TestFreeCompanyRecruiting);

        Assert.That(fc, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(fc.GrandCompany, Is.EqualTo("Immortal Flames"));
            Assert.That(fc.Name, Is.EqualTo("Bedge Lords"));
            Assert.That(fc.Tag, Is.EqualTo("«BEDGE»"));
            Assert.That(fc.Slogan, Does.StartWith("Friendly FC with"));
            Assert.That(fc.Formed, Is.EqualTo(new DateTime(2022, 12, 04, 19, 47, 07)));
            Assert.That(fc.ActiveMemberCount, Is.GreaterThanOrEqualTo(50));
            Assert.That(fc.Rank, Is.EqualTo(30));
            Assert.That(fc.ActiveState, Is.EqualTo("Always"));
            Assert.That(fc.Recruitment, Is.EqualTo("Open"));
        });

        //Reputation
        Assert.That(fc.Reputation, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(fc.Reputation.Maelstrom.Name, Is.EqualTo("Maelstrom"));
            //Assert.AreEqual("Neutral", fc.Reputation.Maelstrom.Rank);
            Assert.That(fc.Reputation.Maelstrom.Progress, Is.EqualTo(0));

            Assert.That(fc.Reputation.Adders.Name, Is.EqualTo("Order of the Twin Adder"));
            Assert.That(fc.Reputation.Adders.Rank, Is.EqualTo("Neutral"));
            Assert.That(fc.Reputation.Adders.Progress, Is.EqualTo(0));

            Assert.That(fc.Reputation.Flames.Name, Is.EqualTo("Immortal Flames"));
            Assert.That(fc.Reputation.Flames.Rank, Is.EqualTo("Allied"));
            Assert.That(fc.Reputation.Flames.Progress, Is.EqualTo(100));
        });


        //Estate
        Assert.That(fc.Estate, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(fc.Estate.Exists);
            Assert.That(fc.Estate.Name, Is.EqualTo("Bedge & Breakfast"));
            Assert.That(fc.Estate.Plot, Is.EqualTo("Plot 5, 11 Ward, The Goblet (Large)"));
        });

        //Focus
        Assert.That(fc.Focus, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(fc.Focus.RolePlay.Name, Is.EqualTo("Role-playing"));
            Assert.That(fc.Focus.RolePlay.IsEnabled);
            Assert.That(fc.Focus.RolePlay.Icon?.AbsoluteUri, Is.Not.Null);

            Assert.That(fc.Focus.Leveling.Name, Is.EqualTo("Leveling"));
            Assert.That(fc.Focus.Leveling.IsEnabled);
            Assert.That(fc.Focus.Leveling.Icon?.AbsoluteUri, Is.Not.Null);

            Assert.That(fc.Focus.Casual.Name, Is.EqualTo("Casual"));
            Assert.That(fc.Focus.Casual.IsEnabled);

            Assert.That(fc.Focus.Hardcore.Name, Is.EqualTo("Hardcore"));
            Assert.That(fc.Focus.Hardcore.IsEnabled);

            Assert.That(fc.Focus.Dungeons.Name, Is.EqualTo("Dungeons"));
            Assert.That(fc.Focus.Dungeons.IsEnabled);

            Assert.That(fc.Focus.Guildhests.Name, Is.EqualTo("Guildhests"));
            Assert.That(!fc.Focus.Guildhests.IsEnabled);

            Assert.That(fc.Focus.Trials.Name, Is.EqualTo("Trials"));
            Assert.That(fc.Focus.Trials.IsEnabled);

            Assert.That(fc.Focus.Raids.Name, Is.EqualTo("Raids"));
            Assert.That(fc.Focus.Raids.IsEnabled);

            Assert.That(fc.Focus.PvP.Name, Is.EqualTo("PvP"));
            Assert.That(fc.Focus.PvP.IsEnabled);
        });

        //Members
        var members = await fc.GetMembers();
        Assert.That(members, Is.Not.Null);

        do
        {
            foreach (var searchResult in members.Members)
            {
                Console.WriteLine(
                    $"{members.CurrentPage} - {searchResult.Name} - {searchResult.RankIcon} - {searchResult.Id}");
            }

            members = await members.GetNextPage();
        } while (members != null);
    }
    
    [Test]
    public async Task TestFreeCompanySearch()
    {
        var query = new FreeCompanySearchQuery
        {
            Name = "new",
            DataCenter = "Crystal",
            Housing = Housing.EstateBuilt,
        };

        var page = await this.lodestone.SearchFreeCompany(query);

        Assert.That(page, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(page.NumPages, Is.GreaterThanOrEqualTo(1));
            Assert.That(page.CurrentPage, Is.EqualTo(1));
        });

        var cResults = 0;
        var cPages = 1;

        do
        {
            Assert.That(page.CurrentPage, Is.EqualTo(cPages));

            foreach (var searchResult in page.Results)
            {
                Console.WriteLine(
                    $"{page.CurrentPage}({cPages}) - {cResults} - {searchResult.Name} - {searchResult.ActiveMembers} - {searchResult.Id} - {searchResult.Server} - {searchResult.Formed} - {searchResult.Active} - {searchResult.RecruitmentOpen}");
                cResults++;
            }

            cPages++;

            page = await page.GetNextPage();
        } while (page != null);
    }

    [Test]
    public async Task CheckCharacterDoH()
    {
        var chara = await this.lodestone.GetCharacter(TestCharacterIdDoH);
        Assert.That(chara, Is.Not.Null);
        Assert.Multiple(() =>
        {
            var attribs = chara.Attributes;
            Assert.That(attribs.Craftsmanship, Is.EqualTo(39));
            Assert.That(attribs.Control, Is.EqualTo(7));
            Assert.That(attribs.MpGpCp, Is.EqualTo(180));
        });
    }

    [Test]
    public async Task CheckCharacterBare()
    {
        var chara = await this.lodestone.GetCharacter(TestCharacterIdBare);
        Assert.That(chara, Is.Not.Null);

        var classJob = await chara.GetClassJobInfo();

        Assert.That(classJob, Is.Not.Null);
        Assert.That(classJob.Warrior, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(classJob.Warrior.Level, Is.EqualTo(1));
            Assert.That(!classJob.Alchemist.IsUnlocked);
            Assert.That(!classJob.WhiteMage.IsUnlocked);
            Assert.That(chara.ActiveClassJobLevel, Is.EqualTo(1));
            Assert.That(chara.PvPTeam, Is.Null);
            Assert.That(chara.FreeCompany, Is.Null);
        });

        Assert.That(chara.Gear, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(chara.Gear.Body, Is.Null);
            Assert.That(chara.Gear.Mainhand, Is.Not.Null);
        });

        Assert.Multiple(async () =>
        {
            Assert.That(await chara.GetMinions(), Is.Null);
            Assert.That(await chara.GetMounts(), Is.Null);
        });
    }

    [Test]
    public async Task CheckCharacterEurekaBozja()
    {
        var chara = await this.lodestone.GetCharacter(TestCharacterIdEureka);
        Assert.That(chara, Is.Not.Null);

        var classJob = await chara.GetClassJobInfo();
        Assert.That(classJob, Is.Not.Null);

        // Eureka
        Assert.That(classJob.Eureka, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(classJob.Eureka.Exists);
            Assert.That(classJob.Eureka.Name, Is.EqualTo("Elemental Level"));
            Assert.That(classJob.Eureka.Level, Is.EqualTo(1));
            Assert.That(classJob.Eureka.ExpCurrent, Is.EqualTo(431));
            Assert.That(classJob.Eureka.ExpMax, Is.EqualTo(1_000));
        });

        // Bozja
        Assert.That(classJob.Bozja, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(classJob.Bozja.Exists);
            Assert.That(classJob.Bozja.Name, Is.EqualTo("Resistance Rank"));
            Assert.That(classJob.Bozja.Level, Is.EqualTo(6));
            Assert.That(classJob.Bozja.MettleCurrent, Is.EqualTo(13_443));
            Assert.That(classJob.Bozja.MettleMax, Is.EqualTo(18_000));
        });
    }

    [Test]
    public async Task CheckCharacterFull()
    {
        var chara = await this.lodestone.GetCharacter(TestCharacterIdFull);
        Assert.That(chara, Is.Not.Null);

        //General data
        Assert.Multiple(() =>
        {
            Assert.That(chara.ToString(), Is.EqualTo("Elya Solais on Odin"));
            Assert.That(chara.Server, Is.EqualTo("Odin"));
            Assert.That(chara.Name, Is.EqualTo("Elya Solais"));
            Assert.That(chara.Race, Is.EqualTo("Miqo'te"));
            Assert.That(chara.Tribe, Is.EqualTo("Keeper of the Moon"));
            Assert.That(chara.Gender, Is.EqualTo(LodestoneCharacter.FemaleChar));
            Assert.That(chara.Bio, Is.EqualTo("-"));
            Assert.That(chara.GuardianDeityName, Is.EqualTo("Menphina, the Lover"));
            Assert.That(chara.Nameday, Is.EqualTo("14th Sun of the 2nd Umbral Moon"));
            Assert.That(chara.Title, Is.EqualTo("Sweet Dreamer"));
            Assert.That(chara.TownName, Is.EqualTo("Limsa Lominsa"));
            Assert.That(chara.Avatar, Is.Not.Null);
            Assert.That(chara.Portrait, Is.Not.Null);
        });

        Console.WriteLine(chara.GuardianDeityIcon);

        //Free Company
        Assert.That(chara.FreeCompany, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(chara.FreeCompany.Id, Is.EqualTo("9232660711086250960"));
            Assert.That(chara.FreeCompany.Name, Is.EqualTo("Corni Licentiae"));
            Assert.That(chara.FreeCompany.Link?.AbsoluteUri,
                Is.EqualTo("https://eu.finalfantasyxiv.com/lodestone/freecompany/9232660711086250960/"));
        });

        //Gear
        var gear = chara.Gear;

        Assert.That(gear.Mainhand, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(gear.Mainhand.ItemName, Is.EqualTo("Mandervillous Wings"));
            Assert.That(!gear.Mainhand.IsHq);
            Assert.That(gear.Mainhand.StrippedItemName, Is.EqualTo("Mandervillous Wings"));

            Assert.That(gear.Mainhand.ItemDatabaseLink, Is.Not.Null);
            Assert.That(gear.Mainhand.GlamourName, Is.Empty);
            Assert.That(gear.Mainhand.Stain, Is.Empty);
        });

        Assert.Multiple(() =>
        {
            Assert.That(gear.Offhand, Is.Null);
            Assert.That(gear.Head, Is.Not.Null);
            Assert.That(gear.Body, Is.Not.Null);
            Assert.That(gear.Hands, Is.Not.Null);
            Assert.That(gear.Legs, Is.Not.Null);
            Assert.That(gear.Feet, Is.Not.Null);
            Assert.That(gear.Earrings, Is.Not.Null);
            Assert.That(gear.Necklace, Is.Not.Null);
            Assert.That(gear.Bracelets, Is.Not.Null);
            Assert.That(gear.Ring1, Is.Not.Null);
            Assert.That(gear.Ring2, Is.Not.Null);
            Assert.That(gear.Soulcrystal, Is.Not.Null);
        });

        Assert.Multiple(() =>
        {
            Assert.That(gear.Head.ItemName, Is.EqualTo("Augmented Credendum Circlet of Healing"));
            Assert.That(gear.Head.ItemLevel, Is.EqualTo(660));
            Assert.That(gear.Head.ItemDatabaseLink, Is.Not.Null);
            Assert.That(gear.Head.GlamourName, Is.EqualTo("The Emperor's New Hat"));
            Assert.That(gear.Head.GlamourDatabaseLink, Is.Not.Null);
            Assert.That(gear.Head.Materia[0], Is.EqualTo("Savage Aim Materia X"));
            Assert.That(gear.Head.Materia[1], Is.EqualTo("Heavens' Eye Materia X"));

            Assert.That(gear.Body.ItemName, Is.EqualTo("Ascension Robe of Healing"));
            Assert.That(gear.Body.ItemLevel, Is.EqualTo(660));

            Assert.That(gear.Hands.ItemName, Is.EqualTo("Augmented Credendum Gauntlets of Healing"));
            Assert.That(gear.Hands.ItemLevel, Is.EqualTo(660));

            Assert.That(gear.Legs.ItemName, Is.EqualTo("Augmented Credendum Hose of Healing"));
            Assert.That(gear.Legs.ItemLevel, Is.EqualTo(660));

            Assert.That(gear.Feet.ItemName, Is.EqualTo("Ascension Sandals of Healing"));
            Assert.That(gear.Feet.ItemLevel, Is.EqualTo(660));

            Assert.That(gear.Earrings.ItemName, Is.EqualTo("Augmented Credendum Earrings of Healing"));
            Assert.That(gear.Earrings.ItemLevel, Is.EqualTo(660));

            Assert.That(gear.Necklace.ItemName, Is.EqualTo("Ascension Necklace of Healing"));
            Assert.That(gear.Necklace.ItemLevel, Is.EqualTo(660));

            Assert.That(gear.Bracelets.ItemName, Is.EqualTo("Ascension Bracelet of Healing"));
            Assert.That(gear.Bracelets.ItemLevel, Is.EqualTo(660));

            Assert.That(gear.Ring1.ItemName, Is.EqualTo("Ascension Ring of Healing"));
            Assert.That(gear.Ring1.ItemLevel, Is.EqualTo(660));

            Assert.That(!gear.Ring1.IsHq);

            Assert.That(gear.Ring2.ItemName, Is.EqualTo("Augmented Credendum Ring of Healing"));
            Assert.That(gear.Ring2.ItemLevel, Is.EqualTo(660));

            Assert.That(gear.Soulcrystal.ItemName, Is.EqualTo("Soul of the Sage"));
        });

        //Classes/Jobs
        var classJob = await chara.GetClassJobInfo();
        Assert.That(classJob, Is.Not.Null);

        foreach (var job in Enum.GetValues<ClassJob>().Where(job => job != ClassJob.None))
        {
            var activeJob = classJob.ClassJobDict[job];
            switch (job)
            {
                case ClassJob.Culinarian:
                    Assert.That(activeJob.IsSpecialized);
                    break;
                case ClassJob.Viper or ClassJob.Pictomancer:
                    Assert.That(!activeJob.IsUnlocked, $"{job}");
                    break;
                case ClassJob.WhiteMage:
                    Assert.That(activeJob.IsJobUnlocked);
                    break;
                case ClassJob.Samurai:
                    Assert.That(activeJob.IsUnlocked);
                    Assert.That(activeJob.Level, Is.EqualTo(50));
                    Assert.That(activeJob.ExpCurrent, Is.EqualTo(11_700));
                    Assert.That(activeJob.ExpMax, Is.EqualTo(421_000));
                    break;
                default:
                    Assert.That(activeJob.IsUnlocked);
                    break;
            }
        }
        Assert.That(classJob.Bozja, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(classJob.Bozja.Level, Is.EqualTo(19));
            Assert.That(classJob.Bozja?.MettleCurrent, Is.EqualTo(4_441_657));
            Assert.That(classJob.Bozja?.MettleMax, Is.EqualTo(6_163_000));
            Assert.That(classJob.Bozja.MettleToGo, Is.EqualTo(1_721_343));
            Assert.That(classJob.Bozja.Name, Is.EqualTo("Resistance Rank"));
        });

        Assert.That(classJob.Eureka, Is.Null);

        //Attributes
        var attributes = chara.Attributes;
        Assert.Multiple(() =>
        {
            Assert.That(attributes.Strength, Is.GreaterThanOrEqualTo(233));
            Assert.That(attributes.Dexterity, Is.GreaterThanOrEqualTo(392));
            Assert.That(attributes.Vitality, Is.GreaterThanOrEqualTo(3319));
            Assert.That(attributes.Intelligence, Is.GreaterThanOrEqualTo(449));
            Assert.That(attributes.Mind, Is.GreaterThanOrEqualTo(3379));
            Assert.That(attributes.CriticalHitRate, Is.GreaterThanOrEqualTo(2397));
            Assert.That(attributes.Determination, Is.GreaterThanOrEqualTo(2040));
            Assert.That(attributes.DirectHitRate, Is.GreaterThanOrEqualTo(904));
            Assert.That(attributes.Defense, Is.GreaterThanOrEqualTo(2032));
            Assert.That(attributes.MagicDefense, Is.GreaterThanOrEqualTo(3551));
            Assert.That(attributes.AttackPower, Is.GreaterThanOrEqualTo(233));
            Assert.That(attributes.SkillSpeed, Is.GreaterThanOrEqualTo(400));
            Assert.That(attributes.AttackMagicPotency, Is.GreaterThanOrEqualTo(3379));
            Assert.That(attributes.HealingMagicPotency, Is.GreaterThanOrEqualTo(3379));
            Assert.That(attributes.SpellSpeed, Is.GreaterThanOrEqualTo(676));
            Assert.That(attributes.Tenacity, Is.GreaterThanOrEqualTo(400));
            Assert.That(attributes.Piety, Is.GreaterThanOrEqualTo(535));
            Assert.That(attributes.Hp, Is.GreaterThanOrEqualTo(74324));
            Assert.That(attributes.MpGpCp, Is.EqualTo(10000));
            Assert.That(attributes.MpGpCpParameterName, Is.EqualTo("MP"));
        });

        //Achievements
        var achieve = await chara.GetAchievement();
        Assert.That(achieve, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(achieve.AchievementPoints, Is.EqualTo(7565));
            Assert.That(achieve.TotalAchievements, Is.GreaterThanOrEqualTo(898));
            Assert.That(achieve.NumPages, Is.GreaterThanOrEqualTo(8));
            Assert.That(achieve.CurrentPage, Is.EqualTo(1));
        });

        bool found655 = false;
        bool found3303 = false;
        var found1750 = false;
        while (achieve is not null)
        {
            foreach (var achievement in achieve.Achievements)
            {
                Assert.That(achievement.Id, Is.Not.Null);
                switch (achievement.Id)
                {
                    case 655:
                        Assert.That(achievement.Name, Is.EqualTo("Mapping the Realm: Southern Thanalan"));
                        Assert.That(achievement.TimeAchieved,
                                        Is.EqualTo(new DateTime(2021, 07, 31, 12, 09, 17)));
                        found655 = true;
                        break;
                    case 3303:
                        Assert.That(achievement.Name, Is.EqualTo("Reforged: Majestic Manderville Wings"));
                        Assert.That(achievement.TimeAchieved,
                                        Is.EqualTo(new DateTime(2024, 01, 24, 18, 35, 19)));
                        found3303 = true;
                        break;
                    case 1750:
                        found1750 = true;
                        break;
                }
            }
            achieve = await achieve.GetNextPage();
        }

        Assert.Multiple(() =>
        {
            Assert.That(found655);
            Assert.That(found3303);
            Assert.That(!found1750);
        });
        
        var mount = await chara.GetMounts();
        Assert.That(mount, Is.Not.Null);
        foreach (var m in mount.Collectables)
        {
            Assert.That(m.Name, Is.Not.Null);
        }

        var minion = await chara.GetMinions();
        Assert.That(minion, Is.Not.Null);
        foreach (var m in minion.Collectables)
        {
            Assert.That(m.Name, Is.Not.Null);
        }
    }

    [Test]
    public async Task CheckCharacterPrivateAchievements()
    {
        var chara = await this.lodestone.GetCharacterAchievement("11166211");
        Assert.That(chara, Is.Not.Null);
        Assert.That(!chara.HasResults);
    }

    [Test]
    public async Task CheckCharacterCollectableNotFound()
    {
        var mounts = await this.lodestone.GetCharacterMount("0");
        Assert.That(mounts, Is.Null);

        var minions = await this.lodestone.GetCharacterMinion("0");
        Assert.That(minions, Is.Null);
    }

    [Test]
    public async Task CheckCrossworldLinkShell()
    {
        var cwls = await this.lodestone.GetCrossworldLinkshell(TestCWLS);
        Assert.That(cwls, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(cwls.Name, Is.EqualTo("COR and Friends"));
            Assert.That(cwls.DataCenter, Is.EqualTo("Light"));
            Assert.That(cwls.NumPages, Is.EqualTo(2));
        });

        while (cwls is not null)
        {
            foreach (var member in cwls.Members)
            {
                Console.WriteLine($"{member.Name} ({member.Rank}) {member.RankIcon}\n" +
                                  $"\tId: {member.Id}\n" +
                                  $"\tAvatar: {member.Avatar}\n" +
                                  $"\tServer: {member.Server}\n" +
                                  $"\tLS Rank: {member.LinkshellRank}\n" +
                                  $"\tLS Rank Icon: {member.LinkshellRankIcon}");
            }
            cwls = await cwls.GetNextPage();
        }
    }

    [Test]
    public async Task CheckCrossworldLinkShellSearch()
    {
        var emptyQuery = new CrossworldLinkshellSearchQuery()
        {
            Name = "abcedfas",
        };
        var emptyResult = await this.lodestone.SearchCrossworldLinkshell(emptyQuery);
        Assert.That(emptyResult, Is.Not.Null);
        //Assert.False(emptyResult.HasResults);
        var query = new CrossworldLinkshellSearchQuery()
        {
            Name = "Hell",
            ActiveMembers = LinkshellSizeCategory.ElevenToThirty,
            DataCenter = "Chaos",
            Sorting = LinkshellSortKind.MemberCountDesc,
        };
        bool first = true;
        var results = await this.lodestone.SearchCrossworldLinkshell(query);
        Assert.That(results, Is.Not.Null);
        Assert.That(results.HasResults);
        Assert.That(results.NumPages, Is.EqualTo(2));
        while (results is not null)
        {
            foreach (var result in results.Results)
            {
                if (first)
                {
                    first = false;
                    var shell = await result.GetCrossworldLinkshell();
                    Assert.That(shell, Is.Not.Null);
                    Assert.That(shell.Name, Is.EqualTo(result.Name));
                }
                Console.WriteLine($"{result.Name} ({result.Id}): {result.ActiveMembers}\n");
            }
            results = await results.GetNextPage();
        }
    }

    [Test]
    public async Task CheckLinkshell()
    {
        var ls = await this.lodestone.GetLinkshell(TestLinkshell);
        Assert.That(ls, Is.Not.Null);
        Assert.That(ls.Name, Is.EqualTo("CORshell"));
        Assert.That(ls.NumPages, Is.EqualTo(2));
        while (ls is not null)
        {
            foreach (var member in ls.Members)
            {
                Console.WriteLine($"{member.Name} ({member.Rank}) {member.RankIcon}\n" +
                                  $"Id: {member.Id}\n" +
                                  $"Avatar: {member.Avatar}\n" +
                                  $"Server: {member.Server}\n" +
                                  $"LS Rank: {member.LinkshellRank}\n" +
                                  $"LS Rank Icon: {member.LinkshellRankIcon}");
                
            }
            ls = await ls.GetNextPage();
        }
    }
    
    [Test]
    public async Task CheckLinkShellSearch()
    {
        var emptyQuery = new LinkshellSearchQuery()
        {
            Name = "abcedfas",
        };
        var emptyResult = await this.lodestone.SearchLinkshell(emptyQuery);
        Assert.That(emptyResult, Is.Not.Null);
        Assert.That(!emptyResult.HasResults);
        var query = new LinkshellSearchQuery()
        {
            Name = "Hell",
            ActiveMembers = LinkshellSizeCategory.ElevenToThirty,
            DataCenter = "Chaos",
        };
        bool first = true;
        var results = await this.lodestone.SearchLinkshell(query);
        Assert.That(results, Is.Not.Null);
        Assert.That(results.HasResults);
        Assert.That(results.NumPages, Is.EqualTo(2));
        while (results is not null)
        {
            foreach (var result in results.Results)
            {
                if (first)
                {
                    first = false;
                    var shell = await result.GetLinkshell();
                    Assert.That(shell, Is.Not.Null);
                    Assert.That(shell.Name, Is.EqualTo(result.Name));
                }
                Console.WriteLine($"{result.Name} ({result.Id}): {result.ActiveMembers}\n");
            }
            results = await results.GetNextPage();
        }
        query = new LinkshellSearchQuery()
        {
            Name = "Hell",
            ActiveMembers = LinkshellSizeCategory.ElevenToThirty,
            HomeWorld = "Spriggan",
        };
        results = await this.lodestone.SearchLinkshell(query);
        Assert.That(results, Is.Not.Null);
        Assert.That(results.HasResults);
        Assert.That(results.NumPages, Is.EqualTo(1));
        while (results is not null)
        {
            foreach (var result in results.Results)
            {
                Console.WriteLine($"{result.Name} ({result.Id}): {result.ActiveMembers}\n");
            }
            results = await results.GetNextPage();
        }
    }
}