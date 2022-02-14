using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class Institutionalized : IProblemTemplate
{
    public string Id { get { return "institutionalized"; } }
    public string Name { get { return "Institutionalized"; } }
    public string Description { get { return "An shunned hero holds on to their identity by going against the group's efforts to force them to conform."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "group", "choice", "sacrifice"
            };
        }
    }

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                Setup = "The Hero shares a strong bond with their (Enemy) group.",
                IncitingIncident = "The Group pursues a goal that goes against what the Hero believes in.",
                FunAndGames = "The Hero tries out life separate from the group.",
                FirstPinchPoint = "The Hero is oblivious to a symbolic reminder that being separate from the group is not the same as being an individual.",
                BadGuysCloseIn = "The Hero feels independent, but the group is pulling them back in.",
                AllHopeIsLost = "The Hero contemplates giving up their individualism for the sake of being accepted by the group.",
                Climax = "The Hero finds a way to hold true to their own identity, while honoring and affecting positive change on the group."
            };
        }
    }


    public Adjectives OrphanAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Shunned",
                EnemyAdjective = "Conforming"
            };
        }
    }

    public Adjectives WandererAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Shunned",
                EnemyAdjective = "Conforming"
            };
        }
    }

    public Adjectives WarriorAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Independent",
                EnemyAdjective = "Accepting"
            };
        }
    }

    public Adjectives MartyrAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Independent",
                EnemyAdjective = "Conforming"
            };
        }
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => "At this stage in the story, the main character shares a strong bond with a group they aren't fully supportive of.",
            "wanderer" => "At this stage in the story, the main character tries out life separate from the group.",
            "warrior" => "At this stage in the story, the main character is gets pulled back in to the group, and contemplates giving up their individualism for the sake of being accepted.",
            "martyr" => "At this stage in the story, the main character finds a way to hold true to their own identity, while either rejecting or changing the group.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}