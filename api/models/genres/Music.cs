using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Music : IGenre
{
    public string Id { get { return "music"; } }
    public string Name { get { return "Music"; } }
    public string Description { get { return "TODO description"; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "life",
                "music",
                "school",
                "band",
                "love",
                "dreams",
                "rock",
                "show",
                "star",
                "musical",
                "dance",
                "singer",
                "competition",
                "help",
                "dancer",
                "talent",
                "group",
                "home",
                "musician",
                "career"
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
                    OpeningImage = "Involve music in establishing the mood of the setting.",
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}