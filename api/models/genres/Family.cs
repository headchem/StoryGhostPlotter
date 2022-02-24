using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Family : IGenre
{
    public string Id { get { return "family"; } }
    public string Name { get { return "Family"; } }
    public string Description { get { return "TODO description"; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "TODO keywords"
            };
        }
    }

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                // TODO
            };
        }
    }

}