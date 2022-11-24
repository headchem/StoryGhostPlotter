using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class LetsDance : IAppealTerm
{
    public string Id { get { return "LetsDance"; } }
    public string Name { get { return "Lets dance"; } }
    public string PromptLabel { get { return "dancers"; } }
    public string Description { get { return "From class to recital, these dance stories will put you in motion."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Family, GenresEnum.Music }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}