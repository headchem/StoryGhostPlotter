using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

namespace StoryGhost.Models.Archetypes;

public class Lover : IArchetype
{
    public string Id { get { return "lover"; } }
    public string Name { get { return "Lover"; } }
    public string Description { get { return "The Lover gushes emotional connection to others, needing reciprocation. They are passionate, loyal, and appreciate the bliss of sensual pleasures. They fear being unwanted and lonely, which can devolve into romance addictions and conquests, and loss of identity to preserve a relationship."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.OthersAndWorld; } }
    public string OrphanDesires { get { return "Be in a relationship, be surrounded by a social environment, experience bliss and intimacy."; } }
    public string WandererResponse { get { return "Love the problem back."; } }
    public string WarriorResponse { get { return "Focus on self to become physically and emotionally attractive, follow own bliss, deserved hedonism."; } }
    public List<string> GreatestFears
    {
        get
        {
            return new List<string>{
                "being alone", "being a wallflower", "unwanted", "unloved", "losing a relationship"
            };
        }
    }
    public List<string> Talents
    {
        get
        {
            return new List<string> {
                "passion", "gratitude", "appreciation and commitment", "enthusiasm", "sensual pleasure"
            };
        }
    }
    public List<string> Weaknesses
    {
        get
        {
            return new List<string> {
                "pleasing others at loss of own identity", "objectifying others"
            };
        }
    }
    public string AddictiveQuality { get { return "intimacy problems"; } }
    public List<string> Addictions
    {
        get
        {
            return new List<string>{
                "relationships", "physical romance"
            };
        }
    }
    public string ShadowSide { get { return "The Lover is a seductive siren who uses love for conquest. Unable to say no to passion, they are destroyed when a lover leaves."; } }
    public List<string> Examples
    {
        get
        {
            return new List<string>{
                "partner", "friend", "intimate", "enthusiast", "sensualist", "spouse", "team-builder"
            };
        }
    }
    public string Motto { get { return "You're the only one for me."; } }


    public string OpeningImage { get { return ""; } }
    public string ThemeStated { get { return ""; } }
    public string Setup { get { return ""; } }
    public string IncitingIncident { get { return ""; } }
    public string Debate { get { return ""; } }
    public string BStory { get { return ""; } }
    public string BreakIntoTwo { get { return ""; } }
    public string FunAndGames { get { return ""; } }
    public string FirstPinchPoint { get { return ""; } }
    public string Midpoint { get { return ""; } }
    public string BadGuysCloseIn { get { return ""; } }
    public string SecondPinchPoint { get { return ""; } }
    public string AllHopeIsLost { get { return ""; } }
    public string DarkNightOfTheSoul { get { return ""; } }
    public string BreakIntoThree { get { return ""; } }
    public string Climax { get { return ""; } }
    public string Cooldown { get { return ""; } }



    public string GetHeroLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"The main character's personality is that of a {Name.ToLower()} (for example: {string.Join(", ", Examples)}).";
    }
    public string GetEnemyLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"The personality of the secondary character (or antagonist) is that of a {Name.ToLower()} (for example: {string.Join(", ", Examples)}).";
    }

    public string GetCharacterStageContribution(int seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => $"The main character's only motivation is to be social and in a blissful and intimate relationship, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contrary.ToLower()}.",
            "wanderer" => $"The main character attempts to love the problem back, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contradiction.ToLower()}.",
            "warrior" => $"Despite the main character's attempts to love the problem back, the problem persists. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Negation.ToLower()}.",
            "martyr" => $"Finally, the main character demonstrates {dramaticQuestion.Positive.ToLower()} and successfully handles the problem by focusing on themselves to become physically and emotionally attractive, and following their own bliss, allowing themselves deserved hedonism.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }
}