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
                "crime", "detective", "danger", "secrets", "hunt",

                "life",
                "young",
                "police",
                "drug",
                "killer",
                "murder",
                "agent",
                "criminal",
                "help",
                "FBI",
                "gang",
                "cop",
                "heist",
                "prison",
                "death",
                "time",
                "case",
                "lives",
                "job",
                "bank",
                "team",
                "local",
                "town",
                "city",
                "partner",
                "past",
                "dangerous",
                "mysterious",
                "revenge",
                "behind",
                "money",
                "boss",
                "violent",
                "save",
                "forced",
                "work",
                "mob",
                "plan",
                "deadly",
                "serial",
                "game",
                "thief",
                "criminals",
                "school",
                "group",
                "car",
                "run"
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