using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Mystery : IGenre
{
    public string Id { get { return "mystery"; } }
    public string Name { get { return "Mystery"; } }
    public string Description { get { return "Mystery explores a shocking event, usually a murder or crime. A small cast of suspects all have plausible motives. The big reveal of the true culprit is always a surprise."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "puzzle", "suspense", "crime", "motives", "suspicion"
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
                    OpeningImage = "An air of intrigue fills the scene.",
                    IncitingIncident = "A mysterious event leaves the main character wanting answers.",
                    BStory = "The main character is obsessed with the mystery, even at the expense of other aspects of their life and relationships.",
                    DarkNightOfTheSoul = "The main character appears to be locked out from ever solving the mystery.",
                    Cooldown = "More mysteries await the main character, and they are eager to take them on."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}