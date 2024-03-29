using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class AAA_Template : IAppealTerm
{
    public string Id { get { return "AcademiesOfMagic"; } }
    public string Name { get { return "Academies Of Magic"; } }
    public string PromptLabel { get { return ""; } }
    public string Description { get { return "These are VERY special schools for the gifted."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Categories { get { return new List<string> { "setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        // A [short description of main character] wants a [goal] but [faces conflict/an antagonist] that causes [something disastrous to happen aka death stakes]
        // When a [inciting incident], a [short description of main character] wants a [goal] he struggles against a [conflict/an antagonist] that causes [death stakes]
        // In a world where [interesting setting], [hero description] has to [goal], otherwise [consequences] will happen.
        // When [inciting incident], [hero description] takes action to [accomplish goal] in the face of [complication/antagonist]

        var specialLocation = $"a special school for the magically gifted";
        var keywordsStr = string.Join(", ", keywords);

        return $"Set in {eras.FirstOrDefault()} {locations.FirstOrDefault()}, at {specialLocation},  <hero description> wants <goal>, but finds <complication> requiring them to apply what they've learned outside of class.";
    }
}