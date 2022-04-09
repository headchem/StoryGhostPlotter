using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Crime : IGenre
{
    public string Id { get { return "crime"; } }
    public string Name { get { return "Crime"; } }
    public string Description { get { return "TODO description"; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "crime", "detective", "danger", "secrets", "hunt"
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
                    OpeningImage = "Hint that bad people lurk in a dangerous world.",
                    Setup = "Establish a calm setting that an upcoming crime will shatter.",
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}