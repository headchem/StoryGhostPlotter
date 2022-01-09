using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class OutOfTheBottle : IProblemTemplate
{
    public string Id { get { return "outOfTheBottle"; } }
    public string Name { get { return "Out of the Bottle"; } }
    public string Description { get { return "A covetous hero is granted a supernatural blessing, but it's not what they really needed, and threatens to become a curse if left unchecked."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "wish", "spell", "lesson"
            };
        }
    }

    public string OpeningImage { get { return ""; } }
    public string ThemeStated { get { return ""; } }
    public string Setup { get { return "The underdog Hero secretly makes a wish to the universe for some supernatural blessing."; } }
    public string IncitingIncident { get { return "The Hero's wish is actually fulfilled."; } }
    public string Debate { get { return "The Hero confirms the blessing is real by testing it."; } }
    public string BreakIntoTwo { get { return ""; } }
    public string FunAndGames { get { return ""; } }
    public string FirstPinchPoint { get { return ""; } }
    public string Midpoint { get { return ""; } }
    public string BadGuysCloseIn { get { return "The Hero feels entitled to their blessing and takes it for granted."; } }
    public string SecondPinchPoint { get { return ""; } }
    public string AllHopeIsLost { get { return "The Hero's blessing can't fix their flaws."; } }
    public string DarkNightOfTheSoul { get { return "The Hero admits they didn't need the blessing - what they really needed was to grow as a person."; } }
    public string BreakIntoThree { get { return "The Hero formulates a plan to defeat the Problem that doesn't rely on the blessing."; } }
    public string Climax { get { return ""; } }
    public string Cooldown { get { return ""; } }

public Adjectives OrphanAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Covetous",
                EnemyAdjective = "Trickster"
            };
        }
    }

    public Adjectives WandererAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Covetous",
                EnemyAdjective = "Trickster"
            };
        }
    }

    public Adjectives WarriorAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Generous",
                EnemyAdjective = "Bored"
            };
        }
    }

    public Adjectives MartyrAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Generous",
                EnemyAdjective = "Trickster"
            };
        }
    }

    public string GetCharacterStageContribution(int seed, string characterStage, IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => "At this stage in the story, the main character is granted a supernatural blessing.",
            "wanderer" => "At this stage in the story, the main character tests and confirms that the supernatural blessing is real.",
            "warrior" => "At this stage in the story, the main character now feels entitled to the supernatural blessing, but it's not helping fix their problem.",
            "martyr" => "At this stage in the story, the main character admits they don't need the supernatural blessing, which enables them to fix their problem without using it.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}