using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoryGhost.Models;
using StoryGhost.Models.Completions;

namespace StoryGhost.Interfaces;

public interface IKeywordsService
{
    public List<string> GetKeywords(List<string> genres);
}