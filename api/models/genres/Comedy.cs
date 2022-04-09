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

    public SequenceAdvices AdviceSequence
    {
        get
        {
            return new SequenceAdvices
            {
                Events = new AdviceSequence
                {
                    OpeningImage = "Establish a quirky or humorous tone.",
                    Setup = "Show the protagonist in a silly situation."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}