using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class FoolTriumphant : IProblemTemplate
{
    public string Id { get { return "foolTriumphant"; } }
    public string Name { get { return "Fool Triumphant"; } }
    public string Description { get { return "An innocent hero must defeat the prejudices of a group while maintaining their identity and avoiding the easy path of conformity."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "fool", "establishment", "transmutation"
            };
        }
    }

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                Setup = "The underdog Hero appears to be the Village Idiot, but there is a spark of wisdom within them.",
                IncitingIncident = "A bigger, more powerful, \"establishment\" Enemy is cruel to the Hero and discounts them due to the Hero's uniqueness.",
                BreakIntoTwo = "The Hero decides they have had enough of society deeming them to be a loser because of their uniqueness.",
                FunAndGames = "The Hero has a friendly accomplice who watches in disbelief as the Hero takes on the Enemy.",
                Midpoint = "The Hero suceeds at shaming the Enemy establishment that shunned them.",
                BadGuysCloseIn = "The Hero may have succeeded, but they did so by sacrificing or downplaying their uniqueness.",
                DarkNightOfTheSoul = "The Hero admits they have become no better than the Enemy establishment that shunned them in the first place.",
                Climax = "The Hero embraces their uniqueness and uses it to overcome the Problem."
            };
        }
    }


    public Adjectives OrphanAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Innocent",
                EnemyAdjective = "Ridiculing"
            };
        }
    }

    public Adjectives WandererAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Innocent",
                EnemyAdjective = "Ridiculing"
            };
        }
    }

    public Adjectives WarriorAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Confident",
                EnemyAdjective = "Respectful"
            };
        }
    }

    public Adjectives MartyrAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Confident",
                EnemyAdjective = "Ridiculing"
            };
        }
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => "At this stage in the story, the main character is disrespected for being incompetent and they've had enough of society deeming them to be a loser.",
            "wanderer" => "At this stage in the story, a friendly accomplice watches in disbelief as the main character takes on the establishment that shunned them.",
            "warrior" => "At this stage in the story, the main character may have succeeded, but they did so by sacrificing what makes them unique.",
            "martyr" => "At this stage in the story, the main character embraces their uniqueness and uses it to overcome the problem.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}