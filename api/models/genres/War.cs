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
                "war",
                "American",
                "mission",
                "soldiers",
                "enemy",
                "German",
                "Nazi",
                "group",
                "love",
                "U.S.",
                "Vietnam",
                "British",
                "rescue",
                "lives",
                "battle",
                "team",
                "army",
                "lines",
                "fight",
                "Army",
                "forced",
                "French",
                "officer",
                "unit",
                "country",
                "Japanese",
                "military",
                "Germany",
                "home",
                "life",
                "save",
                "pilot",
                "elite",
                "France",
                "soldier"
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