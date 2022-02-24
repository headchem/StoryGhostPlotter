using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class Midpoint : ISequence
{
    public string Name { get { return "Midpoint"; } }
    public string Description { get { return "Hidden info about the Problem or a character is revealed, recontextualizing the situation, further raising the stakes for the Hero. The Hero, or their perfectly in sync team, wins a victory, but it's a false victory because the Hero still lacks personal growth."; } }

    public AdviceComponents GetAdvice(List<string> genres, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genresList = Factory.GetGenres(genres);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Midpoint)),
            ProblemTemplate = problemTemplateObj.AdviceSequence.Midpoint,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Midpoint,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.Midpoint
        };
    }

}