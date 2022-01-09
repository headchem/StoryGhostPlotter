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

    private static string getCharacterStage(string completionType)
    {
        return completionType switch
        {
            "orphanSummary" => "orphan",
            "orphanFull" => "orphan",
            "wandererSummary" => "wanderer",
            "wandererFull" => "wanderer",
            "warriorSummary" => "warrior",
            "warriorFull" => "warrior",
            "martyrSummary" => "martyr",
            "martyrFull" => "martyr",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(completionType)),
        };
    }

    /// <summary>Given a <c>Story</c>, based off of the <c>CompletionType</c> property, will return the entire prompt for the given CompletionType</summary>
    public static string GetPrompt(Story req)
    {
        var characterStage = getCharacterStage(req.CompletionType);

        var problemTemplate = Factory.GetProblemTemplate(req.ProblemTemplate);
        var heroArchetype = Factory.GetArchetype(req.HeroArchetype);
        var enemyArchetype = Factory.GetArchetype(req.EnemyArchetype);
        var primalStakes = Factory.GetPrimalStake(req.PrimalStakes);
        var dramaticQuestion = Factory.GetDramaticQuestion(req.DramaticQuestion);
        var genre = Factory.GetGenre(req.Genre);

        var genreContribution = genre.GetLogLineContribution(req.Seed, problemTemplate, heroArchetype, enemyArchetype, primalStakes, dramaticQuestion);
        var heroArchetypeLogLineContribution = heroArchetype.GetHeroLogLineContribution(req.Seed, genre, problemTemplate, enemyArchetype, primalStakes, dramaticQuestion);
        var enemyArchetypeLogLineContribution = enemyArchetype.GetEnemyLogLineContribution(req.Seed, genre, problemTemplate, heroArchetype, primalStakes, dramaticQuestion);
        var primalStakesLogLineContribution = primalStakes.GetLogLineContribution(req.Seed, genre, problemTemplate, heroArchetype, enemyArchetype, dramaticQuestion);
        var dramaticQuestionLogLineContribution = dramaticQuestion.GetLogLineContribution(req.Seed, req.CompletionType, genre, problemTemplate, heroArchetype, enemyArchetype, primalStakes);

        var keywordsContribution = getKeywordsSentence(req.Keywords);

        var problemTemplateCharacterStageContribution = problemTemplate.GetCharacterStageContribution(req.Seed, characterStage, genre, heroArchetype, enemyArchetype, primalStakes, dramaticQuestion);
        var heroArchetypeCharacterStageContribution = heroArchetype.GetCharacterStageContribution(req.Seed, characterStage, genre, problemTemplate, enemyArchetype, primalStakes, dramaticQuestion);

        var consolidatedContributions = $"{genreContribution} {keywordsContribution} {heroArchetypeLogLineContribution} {enemyArchetypeLogLineContribution} {primalStakesLogLineContribution} {dramaticQuestionLogLineContribution}";

        //consolidatedContributions += getPromptForCompletionType(req);

        if (req.CompletionType != "orphanSummary")
        {
            var previousEvents = "\n\nHere is a summary of the previous events in this story:\n\n" + getPreviousEvents(req.CompletionType, req);

            consolidatedContributions += previousEvents;
        }

        consolidatedContributions += $"\n\n{problemTemplateCharacterStageContribution} {heroArchetypeCharacterStageContribution}";
        consolidatedContributions += "\n\n" + getRequestToAI(req.CompletionType, req);

        consolidatedContributions += "\n\n###\n\n"; // OpenAI suggests ending each prompt with a fixed separator

        return consolidatedContributions;
    }

    private static string getKeywordsSentence(List<string> keywords)
    {
        var prefix = "The story focuses on";

        if (keywords == null || keywords.Count == 0)
        {
            return "";
        }
        else if (keywords.Count == 1)
        {
            return $"{prefix} {keywords[0]}.";
        }
        else if (keywords.Count == 2)
        {
            return $"{prefix} {keywords[0]} and {keywords[1]}.";
        }

        var joinedList = $"{prefix} ";

        for (var i = 0; i < keywords.Count - 1; i++)
        {
            joinedList += $"{keywords[i]}, ";
        }

        joinedList += $"and {keywords[keywords.Count - 1]}.";

        return joinedList;
    }

    private static string getPreviousEvents(string completionType, Story req)
    {
        return completionType switch
        {
            "orphanSummary" => "",
            "orphanFull" => req.OrphanSummary,
            "wandererSummary" => req.OrphanSummary + "\n\n" + req.OrphanFull,
            "wandererFull" => req.OrphanSummary + "\n\n" + req.OrphanFull + "\n\n" + req.WandererSummary,
            "warriorSummary" => req.OrphanSummary + "\n\n" + req.OrphanFull + "\n\n" + req.WandererSummary + "\n\n" + req.WandererFull,
            "warriorFull" => req.OrphanSummary + "\n\n" + req.OrphanFull + "\n\n" + req.WandererSummary + "\n\n" + req.WandererFull + "\n\n" + req.WarriorSummary,
            "martyrSummary" => req.OrphanSummary + "\n\n" + req.OrphanFull + "\n\n" + req.WandererSummary + "\n\n" + req.WandererFull + "\n\n" + req.WarriorSummary + "\n\n" + req.WarriorFull,
            "martyrFull" => req.OrphanSummary + "\n\n" + req.OrphanFull + "\n\n" + req.WandererSummary + "\n\n" + req.WandererFull + "\n\n" + req.WarriorSummary + "\n\n" + req.WarriorFull + "\n\n" + req.MartyrSummary,
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(req.CompletionType)),
        };
    }

    // private static string getPromptForCompletionType(Story req)
    // {
    //     var separator = "\n\n";

    //     return req.CompletionType switch
    //     {
    //         "orphanSummary" => "", // there is no prompt for orphanSummary besides the global Log Line prompt, which is added before this method is called
    //         "orphanFull" => separator + getPromptWithPrefix("orphanSummary", req),
    //         "wandererSummary" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req),
    //         "wandererFull" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req) + separator + getPromptWithPrefix("wandererSummary", req),
    //         "warriorSummary" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req) + separator + getPromptWithPrefix("wandererSummary", req) + separator + getPromptWithPrefix("wandererFull", req),
    //         "warriorFull" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req) + separator + getPromptWithPrefix("wandererSummary", req) + separator + getPromptWithPrefix("wandererFull", req) + separator + getPromptWithPrefix("warriorSummary", req),
    //         "martyrSummary" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req) + separator + getPromptWithPrefix("wandererSummary", req) + separator + getPromptWithPrefix("wandererFull", req) + separator + getPromptWithPrefix("warriorSummary", req) + separator + getPromptWithPrefix("warriorFull", req),
    //         "martyrFull" => getPromptWithPrefix("orphanSummary", req) + separator + getPromptWithPrefix("orphanFull", req) + separator + getPromptWithPrefix("wandererSummary", req) + separator + getPromptWithPrefix("wandererFull", req) + separator + getPromptWithPrefix("warriorSummary", req) + separator + getPromptWithPrefix("warriorFull", req) + separator + getPromptWithPrefix("martyrSummary", req),
    //         _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(req.CompletionType)),
    //     };
    // }

    private static string getRequestToAI(string completionType, Story req)
    {
        return completionType switch
        {
            "orphanSummary" => "Write a concise single paragraph summarizing the status quo behaviors of the main character before they are fully confronted with the problem:",
            "orphanFull" => "Based on the previous summary, write a more detailed list of story beats of the status quo behaviors of the main character before they are fully confronted with the problem:",
            "wandererSummary" => "Based on the previous events, write a concise single paragraph summarizing how the main character's life is complicated by the problem, and how they are unsure how to procede:",
            "wandererFull" => "Based on the previous events, write a more detailed list of story beats summarizing how the main character's life is complicated by the problem, and how they are unsure how to procede:",
            "warriorSummary" => "Based on the previous events, write a concise single paragraph summarizing how the main character discovers how to effectively tackle the problem, but they are held back from a lack of personal growth:",
            "warriorFull" => "Based on the previous events, write a more detailed list of story beats summarizing how the main character discovers how to effectively tackle the problem, but they are held back from a lack of personal growth:",
            "martyrSummary" => "Based on the previous events, write a concise single paragraph summarizing how the main character is pushed to their breaking point, but they dig down deep to overcome the problem, with a surprising twist:",
            "martyrFull" => "Based on the previous events, write a more detailed list of story beats summarizing how the main character is pushed to their breaking point, but they dig down deep to overcome the problem, with a surprising twist:",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(completionType)),
        };
    }

}
