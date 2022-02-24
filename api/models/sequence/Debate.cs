using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class Debate : ISequence
{
    public string Name { get { return "Debate"; } }
    public string Description { get { return "The Hero is in shock and doubts if they have what it takes to tackle the Problem. Having realized stasis=death in the Setup, they are now explicitly confronted with what's at stake for them to lose."; } }

    public AdviceComponents GetAdvice(List<string> genres, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genresList = Factory.GetGenres(genres);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Debate)),
            ProblemTemplate = problemTemplateObj.AdviceSequence.Debate,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Debate,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.Debate
        };
    }

}