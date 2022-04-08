using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Thriller : IGenre
{
    public string Id { get { return "thriller"; } }
    public string Name { get { return "Thriller"; } }
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
                    OpeningImage = "Danger and intrigue permeate the mood of this setting.",
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}