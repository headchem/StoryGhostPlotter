using System;
using System.Collections.Generic;
using System.Linq;
using StoryGhost.Interfaces;
using StoryGhost.Models.Genres;
using StoryGhost.Models.ProblemTemplates;
using StoryGhost.Models.Archetypes;
using StoryGhost.Models.DramaticQuestions;
using StoryGhost.Models.Sequences;
using StoryGhost.Models;


namespace StoryGhost.Util;
public static class Factory
{

    public static List<IGenre> GetGenres()
    {
        return new List<IGenre> {
            new Drama(),
            new Comedy(),
            new Thriller(),
            new StoryGhost.Models.Genres.Action(),
            new Adventure(),
            new Horror(),
            new Family(),
            new Romance(),
            new Crime(),
            new Scifi(),
            new Fantasy(),
            new Mystery(),
            new History(),
            new War(),
            new Music(),
            new Western(),
            new Sports(),
        };
    }

    /// <summary><c>genre</c> may be either Id or Name and is not case sensitive.</summary>
    public static List<IGenre> GetGenres(List<string> genres)
    {
        var results = new List<IGenre>();

        foreach (var curGenre in genres)
        {
            var genre = curGenre.ToLower().Trim();

            IGenre genreObj = GetGenres().Where(g => g.Id.ToLower() == genre || g.Id.ToLower() == genre.Replace(" ", "")).FirstOrDefault();

            if (genreObj == null)
            {
                genreObj = GetGenres().Where(g => g.Name.ToLower() == genre).FirstOrDefault();
            }

            results.Add(genreObj);
        }
        
        return results;
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
        if (string.IsNullOrWhiteSpace(archetype)) return new Blank();

        archetype = archetype.ToLower().Trim();

        IArchetype archetypeObj = GetArchetypes().Where(a => a.Id.ToLower() == archetype || a.Id.ToLower() == archetype.Replace(" ", "")).FirstOrDefault();

        if (archetypeObj == null)
        {
            archetypeObj = GetArchetypes().Where(a => a.Name.ToLower() == archetype).FirstOrDefault();
        }

        return archetypeObj;
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
        ISequence sequenceObj = GetSequences().Where(s => s.Name == sequenceName).FirstOrDefault();

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

    // private static string getCharacterStage(string sequenceName)
    // {
    //     return sequenceName switch
    //     {
    //         "orphanSummary" => "orphan",
    //         "orphanFull" => "orphan",
    //         "wandererSummary" => "wanderer",
    //         "wandererFull" => "wanderer",
    //         "warriorSummary" => "warrior",
    //         "warriorFull" => "warrior",
    //         "martyrSummary" => "martyr",
    //         "martyrFull" => "martyr",
    //         _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(sequenceName)),
    //     };
    // }

    /// <summary>Given a <c>Story</c>, will return the prompt for the given <c>sequenceName</c></summary>
    public static string GetSequencePrompt(string sequenceName, Plot plot)
    {
        // get LogLine objects
        var problemTemplate = Factory.GetProblemTemplate(plot.ProblemTemplate);
        //var heroArchetype = Factory.GetArchetype(plot.HeroArchetype);
        //var enemyArchetype = Factory.GetArchetype(plot.EnemyArchetype);
        var dramaticQuestion = Factory.GetDramaticQuestion(plot.DramaticQuestion);
        //var genre = Factory.GetGenre(plot.Genre);

        //var genreContribution = genre.GetLogLineContribution(plot.Seed, problemTemplate, dramaticQuestion);
        var dramaticQuestionLogLineContribution = dramaticQuestion.GetLogLineContribution(plot.Seed, problemTemplate);

        var keywordsContribution = GetKeywordsSentence("The story involves the following key concepts:", plot.Keywords);

        var consolidatedContributions = $"{keywordsContribution}. {dramaticQuestionLogLineContribution}";

        consolidatedContributions += "\n\n";

        if (sequenceName != "Opening Image")
        {
            // given the sequenceName, append all previous sequence texts with appropriate prefixes
            consolidatedContributions += GetPreviousSequences(sequenceName, plot);
            consolidatedContributions += "\n\n";
        }

        consolidatedContributions += sequenceName.ToUpper() + ":";

        // var primalStakesCharacterStageContribution = primalStakes.GetCharacterStageContribution(req.Seed, characterStage, genre, problemTemplate, heroArchetype, enemyArchetype, dramaticQuestion);
        // var problemTemplateCharacterStageContribution = problemTemplate.GetCharacterStageContribution(req.Seed, characterStage, genre, heroArchetype, enemyArchetype, primalStakes, dramaticQuestion);
        // var heroArchetypeCharacterStageContribution = heroArchetype.GetCharacterStageContribution(req.Seed, characterStage, genre, problemTemplate, enemyArchetype, primalStakes, dramaticQuestion);

        // if (completionType != "orphanSummary")
        // {
        //     var previousEvents = "\n\nHere is a summary of the previous events in this story:\n\n" + getPreviousEvents(completionType, req);

        //     consolidatedContributions += previousEvents;
        // }

        //consolidatedContributions += $"\n\n{problemTemplateCharacterStageContribution} {heroArchetypeCharacterStageContribution} {primalStakesCharacterStageContribution}";
        //consolidatedContributions += "\n\n" + getRequestToAI(completionType, req);

        consolidatedContributions += CreateFinetuningDataset.CompletionStopSequence; //"\n\n###\n\n"; // OpenAI suggests ending each prompt with a fixed separator

        return consolidatedContributions;
    }

    public static string GetKeywordsSentence(string prefix, List<string> keywords)
    {
        if (keywords == null || keywords.Count == 0)
        {
            return "";
        }
        else if (keywords.Count == 1)
        {
            return $"{prefix} {keywords[0]}".Trim();
        }
        else if (keywords.Count == 2)
        {
            return $"{prefix} {keywords[0]} and {keywords[1]}".Trim();
        }

        var joinedList = $"{prefix} ";

        for (var i = 0; i < keywords.Count - 1; i++)
        {
            joinedList += $"{keywords[i]}, ";
        }

        joinedList += $"and {keywords[keywords.Count - 1]}";

        return joinedList.Trim();
    }

    public static string GetPreviousSequences(string curSequenceName, Plot plot)
    {
        var curSeqIndex = plot.Sequences.Select(seq => seq.SequenceName).ToList().IndexOf(curSequenceName);
        var allPrevSequences = plot.Sequences.Take(curSeqIndex).ToList();
        var prevSeqTexts = "";

        foreach (var prevSeq in allPrevSequences)
        {
            prevSeqTexts += prevSeq.SequenceName.ToUpper() + ":\n\n" + prevSeq.Text + "\n\n";
        }

        prevSeqTexts = prevSeqTexts.Trim();

        return prevSeqTexts;
    }

    // private static string getRequestToAI(string completionType, Plot req)
    // {
    //     return completionType switch
    //     {
    //         "orphanSummary" => "Write a concise single paragraph summarizing the status quo behaviors of the main character before they are fully confronted with the problem, and their debate about how to tackle the problem now that their life has been plunged into chaos:",
    //         "orphanFull" => "Based on the previous summary, write a more detailed list of story beats of the status quo behaviors of the main character before they are fully confronted with the problem, and their debate about how to tackle the problem now that their life has been plunged into chaos:",
    //         "wandererSummary" => "Based on the previous events, write a concise single paragraph summarizing how the main character's life is complicated by the problem, and how they are unsure how to procede, but still manage to win a minor victory against the problem:",
    //         "wandererFull" => "Based on the previous events, write a more detailed list of story beats summarizing how the main character's life is complicated by the problem, and how they are unsure how to procede, but still manage to win a minor victory against the problem:",
    //         "warriorSummary" => "Based on the previous events, write a concise single paragraph summarizing a negative twist that turns the main character's partial victory against the problem into a hollow one. Write about a crushing defeat that makes the main character nearly give up:",
    //         "warriorFull" => "Based on the previous events, write a more detailed list of story beats summarizing a negative twist that turns the main character's partial victory against the problem into a hollow one. Write about a crushing defeat that makes the main character nearly give up:",
    //         "martyrSummary" => "Based on the previous events, write a concise single paragraph summarizing a fortuitous revelation (preferably related in some way to the earlier false victory) that inspires the main character to dig down deep and effectively tackle the problem:",
    //         "martyrFull" => "Based on the previous events, write a more detailed list of story beats summarizing a fortuitous revelation (preferably related in some way to the earlier false victory) that inspires the main character to dig down deep and effectively tackle the problem:",
    //         _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(completionType)),
    //     };
    // }

}
