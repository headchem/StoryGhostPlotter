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
                    OpeningImage = "Hint at this taking place in an exciting and bombastic setting.",
                    // Setup = "The characters exist in an action-packed setting.",
                    // FunAndGames = "Show the wildest and most extreme aspects of the fantasy setting, and how the characters treat it as mundane, having grown used to it."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}