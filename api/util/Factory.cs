using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

    /// <summary>returns a prompt tailored for the targetSequence given the plot and preceding sequence text</summary>
    public static string GetSequencePartPrompt(string targetSequence, Plot plot, string promptSequenceText)
    {
        var sequence = GetSequence(targetSequence);
        var sequenceText = plot.Sequences.Where(s => s.SequenceName == targetSequence).First();
        var problemTemplate = Factory.GetProblemTemplate(plot.ProblemTemplate);
        var dramaticQuestion = Factory.GetDramaticQuestion(plot.DramaticQuestion);
        var genres = Factory.GetGenres(plot.Genres);

        var heroCharacter = plot.Characters.Where(c => c.IsHero == true).FirstOrDefault();
        var heroCharacterContribution = "";
        var heroPersonalityDescription = "";
        var heroShadowSide = "";

        if (heroCharacter != null)
        {
            var heroArchetype = Factory.GetArchetype(heroCharacter.Archetype);
            heroShadowSide = heroArchetype.ShadowSide;
            heroPersonalityDescription = PersonalityDescription.GetCharacterPrompt(heroCharacter);
            heroCharacterContribution = heroPersonalityDescription + $". {heroCharacter.Name} is the protagonist of the story.";
            //heroCharacterContribution += $" Their archetype can be described as: {heroArchetype.Description}";
            heroCharacterContribution += $" Additional character description: {heroCharacter.Description}";
        }
        else
        {
            throw new Exception("All plots must have a designated protagonist.");
        }

        var nonHeroCharacters = plot.Characters.Where(c => c.IsHero == false).ToList();
        var nonHeroCharacterContributions = "";

        foreach (var character in nonHeroCharacters)
        {
            var archetype = Factory.GetArchetype(character.Archetype);
            nonHeroCharacterContributions += " " + PersonalityDescription.GetCharacterPrompt(character) + $". {character.Name} is a supporting character in this story.";
            //nonHeroCharacterContributions += " Their archetype can be described as: {archetype.Description}";
            nonHeroCharacterContributions += $" Additional character description: {character.Description}";
        }

        nonHeroCharacterContributions = nonHeroCharacterContributions.Trim();

        var dramaticQuestionLogLineContribution = dramaticQuestion.GetLogLineContribution(plot.Seed, problemTemplate);
        var keywordsContribution = GetKeywordsSentence("The story involves the following key concepts:", plot.Keywords);

        var problemTemplateContribution = $"The problem template is \"{plot.ProblemTemplate}\" which can be described as: {problemTemplate.Description}";

        var sequenceAdvice = sequence.ContextDescription + " " + sequence.EventsDescription;

        var adviceWrapper = Factory.GetSequenceAdvice(sequence, new SequenceAdviceRequest
        {
            Genres = plot.Genres,
            ProblemTemplate = plot.ProblemTemplate,
            HeroArchetype = heroCharacter.Archetype,
            DramaticQuestion = plot.DramaticQuestion,
            Text = sequenceText.Text
        });


        promptSequenceText = promptSequenceText.Trim();

        var prompt = "";

        prompt = targetSequence switch
        {
            "Opening Image" => $"Plot teaser: {plot.LogLineDescription} Advice for {targetSequence}: {renderAdviceComponents(adviceWrapper.Context)} {renderAdviceComponents(adviceWrapper.Events)}",
            "Setup" => $"Plot teaser: {plot.LogLineDescription} Advice for {targetSequence}: {renderAdviceComponents(adviceWrapper.Context)} {renderAdviceComponents(adviceWrapper.Events)}\n\n. The protagonist's backstory is: {heroCharacterContribution} {nonHeroCharacterContributions} \n\n{promptSequenceText}",
            "Theme Stated" => $"Plot teaser: {plot.LogLineDescription} Advice for {targetSequence}: {renderAdviceComponents(adviceWrapper.Context)} {renderAdviceComponents(adviceWrapper.Events)}\n\n. The protagonist's backstory is: {heroCharacterContribution} The protagonist has character flaws: {heroShadowSide} The following events lead up to posing the thematic question: {promptSequenceText}",
            "Catalyst" => $"Plot teaser: {plot.LogLineDescription} Advice for {targetSequence}: {renderAdviceComponents(adviceWrapper.Context)} {renderAdviceComponents(adviceWrapper.Events)}\n\n. The protagonist's backstory is: {heroCharacterContribution} {nonHeroCharacterContributions}\n\n{promptSequenceText}",
            "Debate" => $"Plot teaser: {plot.LogLineDescription} Advice for {targetSequence}: {renderAdviceComponents(adviceWrapper.Context)} {renderAdviceComponents(adviceWrapper.Events)}\n\n. The protagonist's backstory is: {heroCharacterContribution} {nonHeroCharacterContributions}\n\n{promptSequenceText}",
            "B Story" => $"Plot teaser: {plot.LogLineDescription} Advice for {targetSequence}: {renderAdviceComponents(adviceWrapper.Context)} {renderAdviceComponents(adviceWrapper.Events)}\n\n. The protagonist's backstory is: {heroCharacterContribution} {nonHeroCharacterContributions}\n\n{promptSequenceText}",
            "Break Into Two" => $"Plot teaser: {plot.LogLineDescription} Advice for {targetSequence}: {renderAdviceComponents(adviceWrapper.Context)} {renderAdviceComponents(adviceWrapper.Events)}\n\n. The protagonist's backstory is: {heroCharacterContribution} {nonHeroCharacterContributions}\n\n{promptSequenceText}",
            "Fun And Games" => $"Plot teaser: {plot.LogLineDescription} Advice for {targetSequence}: {renderAdviceComponents(adviceWrapper.Context)} {renderAdviceComponents(adviceWrapper.Events)}\n\n. The protagonist's backstory is: {heroCharacterContribution} {nonHeroCharacterContributions}\n\n{promptSequenceText}",
            "Midpoint" => $"Plot teaser: {plot.LogLineDescription} Advice for {targetSequence}: {renderAdviceComponents(adviceWrapper.Context)} {renderAdviceComponents(adviceWrapper.Events)}\n\n. The protagonist's backstory is: {heroCharacterContribution} {nonHeroCharacterContributions}\n\n{promptSequenceText}",
            "Bad Guys Close In" => $"Plot teaser: {plot.LogLineDescription} Advice for {targetSequence}: {renderAdviceComponents(adviceWrapper.Context)} {renderAdviceComponents(adviceWrapper.Events)}\n\n. The protagonist's backstory is: {heroCharacterContribution} {nonHeroCharacterContributions}\n\n{promptSequenceText}",
            "All Hope Is Lost" => $"Advice for {targetSequence}: {renderAdviceComponents(adviceWrapper.Context)} {renderAdviceComponents(adviceWrapper.Events)}\n\n{promptSequenceText}",
            "Dark Night Of The Soul" => $"Advice for {targetSequence}: {renderAdviceComponents(adviceWrapper.Context)} {renderAdviceComponents(adviceWrapper.Events)}\n\n{promptSequenceText}",
            "Break Into Three" => $"The protagonist's backstory is: {heroCharacterContribution} Advice for {targetSequence}: {renderAdviceComponents(adviceWrapper.Context)} {renderAdviceComponents(adviceWrapper.Events)}\n\n{promptSequenceText}",
            "Climax" => $"The protagonist's backstory is: {heroCharacterContribution} Advice for {targetSequence}: {renderAdviceComponents(adviceWrapper.Context)} {renderAdviceComponents(adviceWrapper.Events)}\n\n{promptSequenceText}",
            "Cooldown" => $"The protagonist's backstory is: {heroCharacterContribution} Advice for {targetSequence}: {renderAdviceComponents(adviceWrapper.Context)} {renderAdviceComponents(adviceWrapper.Events)}\n\n{promptSequenceText}",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(targetSequence)),
        };

        prompt = cleanPrompt(prompt);

        if (targetSequence == "Opening Image")
        {
            prompt += $" As an award-winning literary author, creatively write the events of the {targetSequence.ToUpper()} moment per the given advice.";
        } else {
            prompt += $" As an award-winning literary author, creatively write the events of the {targetSequence.ToUpper()} moment per the given advice while remaining logically consistent with previous events.";
        }

        return prompt;
    }

    private static string cleanPrompt(string input)
    {
        input = input.Replace(". . ", ". ");
        input = input.Replace(".\n\n. ", ". ");
        input = Regex.Replace(input, @"\s+", " ");
        input = input.Trim();

        return input;
    }

    private static string renderAdviceComponents(AdviceComponents advice)
    {
        return (advice.Common + " " + advice.Genres + " " + advice.ProblemTemplate + " " + advice.DramaticQuestion + " " + advice.HeroArchetype).Trim();
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
    // public static string GetSequencePrompt(string sequenceName, Plot plot)
    // {
    //     // get LogLine objects
    //     var problemTemplate = Factory.GetProblemTemplate(plot.ProblemTemplate);
    //     //var heroArchetype = Factory.GetArchetype(plot.HeroArchetype);
    //     //var enemyArchetype = Factory.GetArchetype(plot.EnemyArchetype);
    //     var dramaticQuestion = Factory.GetDramaticQuestion(plot.DramaticQuestion);
    //     //var genre = Factory.GetGenre(plot.Genre);

    //     //var genreContribution = genre.GetLogLineContribution(plot.Seed, problemTemplate, dramaticQuestion);
    //     var dramaticQuestionLogLineContribution = dramaticQuestion.GetLogLineContribution(plot.Seed, problemTemplate);

    //     var keywordsContribution = GetKeywordsSentence("The story involves the following key concepts:", plot.Keywords);

    //     var consolidatedContributions = $"{keywordsContribution}. {dramaticQuestionLogLineContribution}";

    //     consolidatedContributions += "\n\n";

    //     if (sequenceName != "Opening Image")
    //     {
    //         // given the sequenceName, append all previous sequence texts with appropriate prefixes
    //         consolidatedContributions += GetPreviousSequences(sequenceName, plot);
    //         consolidatedContributions += "\n\n";
    //     }

    //     consolidatedContributions += sequenceName.ToUpper() + ":";

    //     // var primalStakesCharacterStageContribution = primalStakes.GetCharacterStageContribution(req.Seed, characterStage, genre, problemTemplate, heroArchetype, enemyArchetype, dramaticQuestion);
    //     // var problemTemplateCharacterStageContribution = problemTemplate.GetCharacterStageContribution(req.Seed, characterStage, genre, heroArchetype, enemyArchetype, primalStakes, dramaticQuestion);
    //     // var heroArchetypeCharacterStageContribution = heroArchetype.GetCharacterStageContribution(req.Seed, characterStage, genre, problemTemplate, enemyArchetype, primalStakes, dramaticQuestion);

    //     // if (completionType != "orphanSummary")
    //     // {
    //     //     var previousEvents = "\n\nHere is a summary of the previous events in this story:\n\n" + getPreviousEvents(completionType, req);

    //     //     consolidatedContributions += previousEvents;
    //     // }

    //     //consolidatedContributions += $"\n\n{problemTemplateCharacterStageContribution} {heroArchetypeCharacterStageContribution} {primalStakesCharacterStageContribution}";
    //     //consolidatedContributions += "\n\n" + getRequestToAI(completionType, req);

    //     consolidatedContributions += CreateFinetuningDataset.CompletionStopSequence; //"\n\n###\n\n"; // OpenAI suggests ending each prompt with a fixed separator

    //     return consolidatedContributions;
    // }

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

    public static AdviceComponentsWrapper GetSequenceAdvice(ISequence sequenceObj, SequenceAdviceRequest sequenceRequest)
    {
        var adviceObj = sequenceObj.GetAdvice(sequenceRequest.Genres, sequenceRequest.ProblemTemplate, sequenceRequest.HeroArchetype, sequenceRequest.DramaticQuestion);

        // swap nulls for empty strings to make it easier on the js UI

        adviceObj.Context.Common = adviceObj.Context.Common ?? "";
        adviceObj.Context.DramaticQuestion = adviceObj.Context.DramaticQuestion ?? "";
        adviceObj.Context.HeroArchetype = adviceObj.Context.HeroArchetype ?? "";
        adviceObj.Context.ProblemTemplate = adviceObj.Context.ProblemTemplate ?? "";

        adviceObj.Events.Common = adviceObj.Events.Common ?? "";
        adviceObj.Events.DramaticQuestion = adviceObj.Events.DramaticQuestion ?? "";
        adviceObj.Events.HeroArchetype = adviceObj.Events.HeroArchetype ?? "";
        adviceObj.Events.ProblemTemplate = adviceObj.Events.ProblemTemplate ?? "";

        return adviceObj;
    }

}
