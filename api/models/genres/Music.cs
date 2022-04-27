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
                "stage", "production",

                // GPT-3 generated
                "school production", "struggling to learn an instrument", "singing competition", "dance-off", "repairing an instrument", "forming a band", "music festival", "busking", "attending a concert", "music video", "cover band", "nightclub", "record store", "bonding over a song", "musical that mirrors life",

                //"life",
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
                //"help",
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