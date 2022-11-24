using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WesternsBadMenAndGood : IAppealTerm
{
    public string Id { get { return "WesternsBadMenAndGood"; } }
    public string Name { get { return "Bad Men and Good"; } }
    public string PromptLabel { get { return "morally grey characters in the Wild West"; } }
    public string Description { get { return "The color of the Stetson does not tell it all. Bad men may have a hidden core of goodness, while those on the side of the law may be evil through and through."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}