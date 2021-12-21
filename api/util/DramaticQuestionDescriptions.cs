using System;
using StoryGhost.Models;

namespace StoryGhost.Util;
public static class DramaticQuestionDescriptions
{
    public static DramaticQuestion GetDramaticQuestionDescription(string dramaticQuestion) {
        return new DramaticQuestion{
            Name = dramaticQuestion,
            Description = $"Desc for dramatic question: {dramaticQuestion}"
        };
    }
}
