using System;
using System.Collections.Generic;
using System.Linq;
using StoryGhost.Interfaces;
using StoryGhost.Models.Genres;
using StoryGhost.Models.ProblemTemplates;
using StoryGhost.Models.Archetypes;
using StoryGhost.Models.PrimalStakes;
using StoryGhost.Models.DramaticQuestions;


namespace StoryGhost.Util;
public static class Factory
{

    public static List<IGenre> GetGenres()
    {
        return new List<IGenre> {
            new Adventure(),
            new Drama(),
            new Fantasy(),
            new Mystery(),
            new Romance(),
            new Scifi(),
            new Sports(),
        };
    }

    public static IGenre GetGenre(string genre)
    {
        return GetGenres().Where(g => g.Id == genre).First();
    }


    public static List<IProblemTemplate> GetProblemTemplates()
    {
        return new List<IProblemTemplate> {
            new BuddyLove(),
            new FoolTriumphant(),
            new GoldenFleece(),
            new Institutionalized(),
            new MonsterInTheHouse(),
            new OutOfTheBottle(),
            new RitesOfPassage(),
            new Superhero(),
            new UnexpectedProblem(),
            new Whydunnit()
        };
    }

    public static IProblemTemplate GetProblemTemplate(string problemTemplate)
    {
        return GetProblemTemplates().Where(p => p.Id == problemTemplate).First();
    }


    public static List<IArchetype> GetArchetypes()
    {
        return new List<IArchetype> {
            new Caregiver(),
            new Creator(),
            new Explorer(),
            new Innocent(),
            new Jester(),
            new Lover(),
            new Magician(),
            new Orphan(),
            new Outlaw(),
            new Ruler(),
            new Sage(),
            new Warrior()
        };
    }

    public static IArchetype GetArchetype(string archetype)
    {
        return GetArchetypes().Where(a => a.Id == archetype).First();
    }


    public static List<IPrimalStakes> GetPrimalStakes()
    {
        return new List<IPrimalStakes> {
            new ExactRevenge(),
            new FindMate(),
            new ProtectFamily(),
            new ProtectPossession(),
            new Survive()
        };
    }

    public static IPrimalStakes GetPrimalStake(string primalStakes)
    {
        return GetPrimalStakes().Where(p => p.Id == primalStakes).First();
    }


    public static List<IDramaticQuestion> GetDramaticQuestions()
    {
        return new List<IDramaticQuestion> {
            new Bravery(),
            new Consciousness(),
            new Liberty(),
            new LoveFake(),
            new LoveSelfHate(),
            new Loyalty(),
            new Maturity(),
            new NaturalUnsanctioned(),
            new SanctionedUnnatural(),
            new OpenCommunication(),
            new Success(),
            new Truth(),
            new Wealth(),
            new Wisdom()
        };
    }

    public static IDramaticQuestion GetDramaticQuestion(string dramaticQuestion)
    {
        return GetDramaticQuestions().Where(d => d.Id == dramaticQuestion).First();
    }

}
