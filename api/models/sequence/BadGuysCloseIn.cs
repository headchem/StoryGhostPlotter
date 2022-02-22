using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class BadGuysCloseIn : ISequence
{
    public string Name { get { return "Bad Guys Close In"; } }
    public string Description { get { return "In-fighting, doubt and jealousy tear the Hero's team apart. The Enemy is temporarily defeated, but they are regrouping for an even stronger attack. The subplot interweaves with the main plot, building tension without resolution."; } }

    public AdviceComponents GetAdvice(string genre, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genreObj = Factory.GetGenre(genre);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genre = genreObj.AdviceSequence.BadGuysCloseIn,
            ProblemTemplate = problemTemplateObj.AdviceSequence.BadGuysCloseIn,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.BadGuysCloseIn,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.BadGuysCloseIn
        };
    }

}