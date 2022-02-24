using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class OpeningImage : ISequence
{
    public string Name { get { return "Opening Image"; } }
    public string Description { get { return "Present a brief snapshot of the world the Hero lives in, or the Hero's status quo life, and what they are missing. Establish the tone of the story, and hint at the problem to come."; } }

    public AdviceComponents GetAdvice(List<string> genres, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genresList = Factory.GetGenres(genres);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.OpeningImage)),
            ProblemTemplate = problemTemplateObj.AdviceSequence.OpeningImage,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.OpeningImage,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.OpeningImage
        };
    }

}