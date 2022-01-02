using System;
using System.Collections.Generic;
using System.Linq;
using StoryGhost.Interfaces;
using StoryGhost.Models.Genres;
using StoryGhost.Models.ProblemTemplates;
using StoryGhost.Models.Archetypes;
using StoryGhost.Models.PrimalStakes;
using StoryGhost.Models.DramaticQuestions;
using StoryGhost.Models;


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
            new FindConnection(),
            new ExactRevenge(),
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
            new Identity(),
            new Legacy(),
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

    public static string GetPrompt(GenerateRequest req)
    {
        var problemTemplate = Factory.GetProblemTemplate(req.ProblemTemplate);
        var heroArchetype = Factory.GetArchetype(req.HeroArchetype);
        var enemyArchetype = Factory.GetArchetype(req.EnemyArchetype);
        var primalStakes = Factory.GetPrimalStake(req.PrimalStakes);
        var dramaticQuestion = Factory.GetDramaticQuestion(req.DramaticQuestion);

        var genre = Factory.GetGenre(req.Genre);

        var genreContribution = genre.GetLogLineContribution(req.Seed, problemTemplate, heroArchetype, enemyArchetype, primalStakes, dramaticQuestion);
        var problemTemplateContribution = problemTemplate.GetLogLineContribution(req.Seed, genre, heroArchetype, enemyArchetype, primalStakes, dramaticQuestion);
        var heroArchetypeContribution = heroArchetype.GetHeroLogLineContribution(req.Seed, genre, problemTemplate, enemyArchetype, primalStakes, dramaticQuestion);
        var enemyArchetypeContribution = enemyArchetype.GetEnemyLogLineContribution(req.Seed, genre, problemTemplate, heroArchetype, primalStakes, dramaticQuestion);
        var primalStakesContribution = primalStakes.GetLogLineContribution(req.Seed, genre, problemTemplate, heroArchetype, enemyArchetype, dramaticQuestion);
        var dramaticQuestionContribution = dramaticQuestion.GetLogLineContribution(req.Seed, genre, problemTemplate, heroArchetype, enemyArchetype, primalStakes);

        var consolidatedContributions = $"{genreContribution} {problemTemplateContribution} The following ideas are contained in this story: {string.Join(", ", req.Keywords)}. {heroArchetypeContribution} {enemyArchetypeContribution} {primalStakesContribution} {dramaticQuestionContribution}";

        consolidatedContributions += "\n\n" + getPromptForCompletionType(req);

        return consolidatedContributions;
    }

    private static string getPromptForCompletionType(GenerateRequest req)
    {
        var separator = "\n\n";

        return req.CompletionType switch
        {
            "orphanSummary" => "",
            "orphanFull" => getPromptWithPrefix("orphanSummary", req),
            "wandererSummary" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req),
            "wandererFull" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req) + separator + getPromptWithPrefix("wandererSummary", req),
            "warriorSummary" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req) + separator + getPromptWithPrefix("wandererSummary", req) + separator + getPromptWithPrefix("wandererFull", req),
            "warriorFull" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req) + separator + getPromptWithPrefix("wandererSummary", req) + separator + getPromptWithPrefix("wandererFull", req) + separator + getPromptWithPrefix("warriorSummary", req),
            "martyrSummary" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req) + separator + getPromptWithPrefix("wandererSummary", req) + separator + getPromptWithPrefix("wandererFull", req) + separator + getPromptWithPrefix("warriorSummary", req) + separator + getPromptWithPrefix("warriorFull", req),
            "martyrFull" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req) + separator + getPromptWithPrefix("wandererSummary", req) + separator + getPromptWithPrefix("wandererFull", req) + separator + getPromptWithPrefix("warriorSummary", req) + separator + getPromptWithPrefix("warriorFull", req) + separator + getPromptWithPrefix("martyrSummary", req),
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(req.CompletionType)),
        };
    }

    private static string getPromptWithPrefix(string completionType, GenerateRequest req)
    {
        return completionType switch
        {
            "orphanSummary" => "BEGINNING SUMMARY: " + req.OrphanSummary,
            "orphanFull" => "BEGINNING FULL: " + req.OrphanFull,
            "wandererSummary" => "EARLY MIDPOINT SUMMARY: " + req.WandererSummary,
            "wandererFull" => "EARLY MIDPOINT FULL: " + req.WandererFull,
            "warriorSummary" => "LATE MIDPOINT SUMMARY: " + req.WandererFull,
            "warriorFull" => "LATE MIDPOINT SUMMARY: " + req.WarriorFull,
            "martyrSummary" => "ENDING SUMMARY: " + req.MartyrSummary,
            "martyrFull" => "ENDING FULL: " + req.MartyrFull,
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(completionType)),
        };
    }

}
