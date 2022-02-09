using System;
using System.Collections.Generic;
using System.Linq;
using StoryGhost.Interfaces;
using StoryGhost.Models.Genres;
using StoryGhost.Models.ProblemTemplates;
using StoryGhost.Models.Archetypes;
using StoryGhost.Models.PrimalStakes;
using StoryGhost.Models.DramaticQuestions;
using StoryGhost.Models.Sequences;
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

    /// <summary><c>sequenceName</c> is case sensitive.</summary>
    public static ISequence GetSequence(string sequenceName)
    {
        ISequence sequenceObj = GetSequences().Where(s => s.Name == sequenceName).First();

        return sequenceObj;
    }

    public static List<ISequence> GetSequences()
    {
        return new List<ISequence> {
            new OpeningImage(),
            new Setup(),
            new ThemeStated(),
            new SetupContinued(),
            new Catalyst(),
            new Debate(),
            new BStory(),
            new DebateContinued(),
            new BreakIntoTwo(),
            new FunAndGames(),
            new FirstPinchPoint(),
            new Midpoint(),
            new BadGuysCloseIn(),
            new SecondPinchPoint(),
            new AllHopeIsLost(),
            new DarkNightOfTheSoul(),
            new BreakIntoThree(),
            new Climax(),
            new Cooldown()
        };
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
    public static string GetPrompt(Plot req)
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
        var dramaticQuestionLogLineContribution = dramaticQuestion.GetLogLineContribution(req.Seed, req.CompletionType, genre, problemTemplate, heroArchetype, enemyArchetype, primalStakes);

        var keywordsContribution = getKeywordsSentence(req.Keywords);

        var primalStakesCharacterStageContribution = primalStakes.GetCharacterStageContribution(req.Seed, characterStage, genre, problemTemplate, heroArchetype, enemyArchetype, dramaticQuestion);
        var problemTemplateCharacterStageContribution = problemTemplate.GetCharacterStageContribution(req.Seed, characterStage, genre, heroArchetype, enemyArchetype, primalStakes, dramaticQuestion);
        var heroArchetypeCharacterStageContribution = heroArchetype.GetCharacterStageContribution(req.Seed, characterStage, genre, problemTemplate, enemyArchetype, primalStakes, dramaticQuestion);

        var consolidatedContributions = $"{genreContribution} {keywordsContribution} {heroArchetypeLogLineContribution} {enemyArchetypeLogLineContribution} {dramaticQuestionLogLineContribution}";

        if (req.CompletionType != "orphanSummary")
        {
            var previousEvents = "\n\nHere is a summary of the previous events in this story:\n\n" + getPreviousEvents(req.CompletionType, req);

            consolidatedContributions += previousEvents;
        }

        consolidatedContributions += $"\n\n{problemTemplateCharacterStageContribution} {heroArchetypeCharacterStageContribution} {primalStakesCharacterStageContribution}";
        consolidatedContributions += "\n\n" + getRequestToAI(req.CompletionType, req);

        consolidatedContributions += "\n\n###\n\n"; // OpenAI suggests ending each prompt with a fixed separator

        return consolidatedContributions;
    }

    private static string getKeywordsSentence(List<string> keywords)
    {
        var prefix = "The story focuses on the following concepts:";

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

    private static string getPreviousEvents(string completionType, Plot req)
    {
        var summaryPrefix = "SUMMARY: ";

        return completionType switch
        {
            "orphanSummary" => "",
            "orphanFull" => summaryPrefix + req.OrphanSummary,
            "wandererSummary" => summaryPrefix + req.OrphanSummary + "\n\n" + req.OrphanFull,
            "wandererFull" => summaryPrefix + req.OrphanSummary + "\n\n" + req.OrphanFull + "\n\n" + summaryPrefix + req.WandererSummary,
            "warriorSummary" => summaryPrefix + req.OrphanSummary + "\n\n" + req.OrphanFull + "\n\n" + summaryPrefix + req.WandererSummary + "\n\n" + req.WandererFull,
            "warriorFull" => summaryPrefix + req.OrphanSummary + "\n\n" + req.OrphanFull + "\n\n" + summaryPrefix + req.WandererSummary + "\n\n" + req.WandererFull + "\n\n" + summaryPrefix + req.WarriorSummary,
            "martyrSummary" => summaryPrefix + req.OrphanSummary + "\n\n" + req.OrphanFull + "\n\n" + summaryPrefix + req.WandererSummary + "\n\n" + req.WandererFull + "\n\n" + summaryPrefix + req.WarriorSummary + "\n\n" + req.WarriorFull,
            "martyrFull" => summaryPrefix + req.OrphanSummary + "\n\n" + req.OrphanFull + "\n\n" + summaryPrefix + req.WandererSummary + "\n\n" + req.WandererFull + "\n\n" + req.WarriorSummary + "\n\n" + req.WarriorFull + "\n\n" + summaryPrefix + req.MartyrSummary,
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(req.CompletionType)),
        };
    }

    private static string getRequestToAI(string completionType, Plot req)
    {
        return completionType switch
        {
            "orphanSummary" => "Write a concise single paragraph summarizing the status quo behaviors of the main character before they are fully confronted with the problem, and their debate about how to tackle the problem now that their life has been plunged into chaos:",
            "orphanFull" => "Based on the previous summary, write a more detailed list of story beats of the status quo behaviors of the main character before they are fully confronted with the problem, and their debate about how to tackle the problem now that their life has been plunged into chaos:",
            "wandererSummary" => "Based on the previous events, write a concise single paragraph summarizing how the main character's life is complicated by the problem, and how they are unsure how to procede, but still manage to win a minor victory against the problem:",
            "wandererFull" => "Based on the previous events, write a more detailed list of story beats summarizing how the main character's life is complicated by the problem, and how they are unsure how to procede, but still manage to win a minor victory against the problem:",
            "warriorSummary" => "Based on the previous events, write a concise single paragraph summarizing a negative twist that turns the main character's partial victory against the problem into a hollow one. Write about a crushing defeat that makes the main character nearly give up:",
            "warriorFull" => "Based on the previous events, write a more detailed list of story beats summarizing a negative twist that turns the main character's partial victory against the problem into a hollow one. Write about a crushing defeat that makes the main character nearly give up:",
            "martyrSummary" => "Based on the previous events, write a concise single paragraph summarizing a fortuitious revelation (preferably related in some way to the earlier false victory) that inspires the main character to dig down deep and effectively tackle the problem:",
            "martyrFull" => "Based on the previous events, write a more detailed list of story beats summarizing a fortuitious revelation (preferably related in some way to the earlier false victory) that inspires the main character to dig down deep and effectively tackle the problem:",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(completionType)),
        };
    }

}
