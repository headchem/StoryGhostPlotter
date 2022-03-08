using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Action : IGenre
{
    public string Id { get { return "action"; } }
    public string Name { get { return "Action"; } }
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
                    // TODO
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}