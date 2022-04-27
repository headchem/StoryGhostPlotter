using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Scifi : IGenre
{
    public string Id { get { return "science fiction"; } }
    public string Name { get { return "Science Fiction"; } }
    public string Description { get { return "Science Fiction is packed full of futuristic ideas, extrapolating from what's possible today into advanced science and technology. It examines the consequences of these innovations, and seeks to inspire a sense of forward-thinking wonder."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "technology", "future", "space", "aliens", "innovation", "time travel", "space travel", "scientific advances",

                // GPT-3 generated
                "AI", "premonitions", "parallel universe", "mind control", "clones", "alien invation", "robots", "cyborgs", "nanotechnology", "genetic engineering", "cybernetics", "virtual reality", "biotechnology", "machine learning", "genetic modification",

                "Earth",
                "planet",
                "alien",
                "life",
                "time",
                //"save",
                "mysterious",
                //"team",
                "mission",
                //"group",
                "human",
                "crew",
                //"help",
                "discover",
                "battle",
                "fight",
                "secret",
                //"evil",
                "home",
                "discovers",
                "war",
                "dangerous",
                "city",
                "Dr.",
                "government",
                "humans",
                "scientist",
                "humanity",
                "power",
                "powers",
                "force",
                "universe",
                "forces",
                //"lives",
                "deadly",
                "powerful",
                "escape",
                "survivors",
                //"year",
                "City",
                "virus",
                "ship",
                "sent",
                "survive",
                "creatures",
                "ancient",
                "attack",
                "love",
                //"town",
                "destroy",
                "robot",
                "strange",
                "threat",
                "protect",
                //"living",
                "mankind",
                "hope",
                //"series",
                "military",
                "control",
                "rescue",
                "search",
                "death",
                "game",
                "travel",
                //"plans"
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
                    OpeningImage = "Briefly show a physical or symbolic element that demonstrates this is a futuristic scifi setting.",
                    Setup = "Show the scifi setting in action, and how it permeates the everyday lives of the characters.",
                    FunAndGames = "Show the most high-tech aspects of the fantasy setting, and how the characters treat it as mundane, having grown used to it."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}