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

    /// <summary><c>genre</c> may be either Id or Name and is not case sensitive.</summary>
    public static IGenre GetGenre(string genre)
    {
        genre = genre.ToLower().Trim();

        IGenre genreObj = GetGenres().Where(g => g.Id.ToLower() == genre || g.Id.ToLower() == genre.Replace(" ", "")).FirstOrDefault();

        if (genreObj == null)
        {
            genreObj = GetGenres().Where(g => g.Name.ToLower() == genre).FirstOrDefault();
        }

        return genreObj;
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

    /// <summary><c>problemTemplate</c> may be either Id or Name and is not case sensitive.</summary>
    public static IProblemTemplate GetProblemTemplate(string problemTemplate)
    {
        problemTemplate = problemTemplate.ToLower().Trim();

        IProblemTemplate problemTemplateObj = GetProblemTemplates().Where(p => p.Id.ToLower() == problemTemplate || p.Id.ToLower() == problemTemplate.Replace(" ", "")).FirstOrDefault();

        if (problemTemplateObj == null)
        {
            problemTemplateObj = GetProblemTemplates().Where(p => p.Name.ToLower() == problemTemplate).FirstOrDefault();
        }

        return problemTemplateObj;
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

    /// <summary><c>archetype</c> may be either Id or Name and is not case sensitive.</summary>
    public static IArchetype GetArchetype(string archetype)
    {
        archetype = archetype.ToLower().Trim();

        IArchetype archetypeObj = GetArchetypes().Where(a => a.Id.ToLower() == archetype || a.Id.ToLower() == archetype.Replace(" ", "")).FirstOrDefault();

        if (archetypeObj == null)
        {
            archetypeObj = GetArchetypes().Where(a => a.Name.ToLower() == archetype).FirstOrDefault();
        }

        return archetypeObj;
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

    /// <summary><c>primalStakes</c> may be either Id or Name and is not case sensitive.</summary>
    public static IPrimalStakes GetPrimalStake(string primalStakes)
    {
        primalStakes = primalStakes.ToLower().Trim();

        IPrimalStakes primalStakesObj = GetPrimalStakes().Where(p => p.Id.ToLower() == primalStakes || p.Id.ToLower() == primalStakes.Replace(" ", "")).FirstOrDefault();

        if (primalStakesObj == null)
        {
            primalStakesObj = GetPrimalStakes().Where(p => p.Name.ToLower() == primalStakes).FirstOrDefault();
        }

        return primalStakesObj;
    }


    public static List<IDramaticQuestion> GetDramaticQuestions()
    {
        return new List<IDramaticQuestion> {
            new Bravery(),
            new Consciousness(),
            new EffortlessPeace(),
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

    /// <summary><c>dramaticQuestion</c> may be either Id or Name and is not case sensitive.</summary>
    public static IDramaticQuestion GetDramaticQuestion(string dramaticQuestion)
    {
        dramaticQuestion = dramaticQuestion.ToLower().Trim();

        IDramaticQuestion dramaticQuestionObj = GetDramaticQuestions().Where(d => d.Id.ToLower() == dramaticQuestion || d.Id.ToLower() == dramaticQuestion.Replace(" ", "")).FirstOrDefault();

        if (dramaticQuestionObj == null)
        {
            dramaticQuestionObj = GetDramaticQuestions().Where(d => d.Name.ToLower() == dramaticQuestion).FirstOrDefault();
        }

        return dramaticQuestionObj;
    }

    /// <summary>Given a <c>Story</c>, based off of the <c>CompletionType</c> property, will return the entire prompt for the given CompletionType</summary>
    public static string GetPrompt(Story req)
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

        var consolidatedContributions = $"Here is an overview of the elements of this award winning story: {genreContribution} {problemTemplateContribution} The following important topics take center stage in this story: {string.Join(", ", req.Keywords)}. {heroArchetypeContribution} {enemyArchetypeContribution} {primalStakesContribution} {dramaticQuestionContribution}";

        consolidatedContributions += getPromptForCompletionType(req);

        consolidatedContributions += "\n\n###\n\n"; // OpenAI suggests ending each prompt with a fixed separator

        return consolidatedContributions;
    }

    private static string getPromptForCompletionType(Story req)
    {
        var separator = "\n\n";

        return req.CompletionType switch
        {
            "orphanSummary" => "", // there is no prompt for orphanSummary besides the global Log Line prompt, which is added before this method is called
            "orphanFull" => separator + getPromptWithPrefix("orphanSummary", req),
            "wandererSummary" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req),
            "wandererFull" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req) + separator + getPromptWithPrefix("wandererSummary", req),
            "warriorSummary" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req) + separator + getPromptWithPrefix("wandererSummary", req) + separator + getPromptWithPrefix("wandererFull", req),
            "warriorFull" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req) + separator + getPromptWithPrefix("wandererSummary", req) + separator + getPromptWithPrefix("wandererFull", req) + separator + getPromptWithPrefix("warriorSummary", req),
            "martyrSummary" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req) + separator + getPromptWithPrefix("wandererSummary", req) + separator + getPromptWithPrefix("wandererFull", req) + separator + getPromptWithPrefix("warriorSummary", req) + separator + getPromptWithPrefix("warriorFull", req),
            "martyrFull" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req) + separator + getPromptWithPrefix("wandererSummary", req) + separator + getPromptWithPrefix("wandererFull", req) + separator + getPromptWithPrefix("warriorSummary", req) + separator + getPromptWithPrefix("warriorFull", req) + separator + getPromptWithPrefix("martyrSummary", req),
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(req.CompletionType)),
        };
    }

    private static string getPromptWithPrefix(string completionType, Story req)
    {
        return completionType switch
        {
            "orphanSummary" => "Here is a high-level summary of the beginning of this award winning story:\n\n" + req.OrphanSummary,
            "orphanFull" => "Here is a detailed summary of the beginning of this award winning story:\n\n" + req.OrphanFull,
            "wandererSummary" => "Here is a high-level summary of how the main character's life is complicated:\n\n" + req.WandererSummary,
            "wandererFull" => "Here is a detailed summary of how the main character's life is complicated:\n\n" + req.WandererFull,
            "warriorSummary" => "Here is a high-level summary of how the main character is pushed to breaking point:\n\n" + req.WarriorSummary,
            "warriorFull" => "Here is a detailed summary of how the main character is pushed to breaking point:\n\n" + req.WarriorFull,
            "martyrSummary" => "Here is a high-level summary of how the main character digs deep to overcome the problem, but with a surprising twist:\n\n" + req.MartyrSummary,
            "martyrFull" => "Here is a detailed summary of how the main character digs deep to overcome the problem, but with a surprising twist:\n\n" + req.MartyrFull,
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(completionType)),
        };
    }

}
