using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Comedy : IGenre
{
    public string Id { get { return "comedy"; } }
    public string Name { get { return "Comedy"; } }
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