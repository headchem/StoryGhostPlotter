using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class War : IGenre
{
    public string Id { get { return "war"; } }
    public string Name { get { return "War"; } }
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
                    OpeningImage = "Set a militaristic tone.",
                    Setup = "Elaborate on the war-like conflict and how it impacts the protagonist."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}