using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Horror : IGenre
{
    public string Id { get { return "horror"; } }
    public string Name { get { return "Horror"; } }
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
                    OpeningImage = "Symbolize a safe and happy mood, but with horror lurking under the surface.",
                    Setup = "Things appear too good to be true for the protagonist."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}