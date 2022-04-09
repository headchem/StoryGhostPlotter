using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class History : IGenre
{
    public string Id { get { return "history"; } }
    public string Name { get { return "History"; } }
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
                    OpeningImage = "Show some aspect of the setting that makes it clear this takes place in a historical era.",
                    Setup = "Show aspects of the historical setting that impact the protagonist's life."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}