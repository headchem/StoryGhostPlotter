using System;
using StoryGhost.Models;

namespace StoryGhost.Util;
public static class ProblemTemplateDescriptions
{
    public static ProblemTemplate GetProblemTemplateDescription(string problemTemplate) {
        return new ProblemTemplate{
            Name = problemTemplate,
            Description = $"Desc for problemTemplate: {problemTemplate}"
        };
    }
}
