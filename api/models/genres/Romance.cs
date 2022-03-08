using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Romance : IGenre
{
    public string Id { get { return "romance"; } }
    public string Name { get { return "Romance"; } }
    public string Description { get { return "Romance focuses on the relationship and courtship between two people."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "love", "longing"
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
                    Setup = "Establish the complicated emotional (possibly romantic?) connections between the main characters.",
                    Debate = "Things get complicated as the emotional connections between characters shift.",
                    Midpoint = "The main character achieves what they think is the romantic connection they deeply desired, but it's fleeting.",
                    AllHopeIsLost = "The main character's romantic prospects are over.",
                    DarkNightOfTheSoul = "The main character accepts responsibility for the ruined relationship.",
                    BreakIntoThree = "The main character springs into action to attempt to make things right in their relationship.",
                    Cooldown = "Show how the main character's relationship is strong and healthy."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}