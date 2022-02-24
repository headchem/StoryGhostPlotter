using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class ThemeStated : ISequence
{
    public string Name { get { return "Theme Stated"; } }
    public string Description { get { return ""; } } // this is covered by the Dramatic Question description

    public AdviceComponents GetAdvice(List<string> genres, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genresList = Factory.GetGenres(genres);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.ThemeStated)),
            ProblemTemplate = problemTemplateObj.AdviceSequence.ThemeStated,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.ThemeStated,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.ThemeStated
        };
    }

}