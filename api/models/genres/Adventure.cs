using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Adventure : IGenre
{
    public string Id { get { return "adventure"; } }
    public string Name { get { return "Adventure"; } }
    public string Description { get { return "Adventure is a face-paced tale where the Hero is in a risky situation. Typically involving a difficult quest, the Hero makes numerous discoveries and encounters dangers at every step."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "danger", "excitement", "action", "travel", "quests", "discovery",

                "man",
                "woman",
                "father",
                "son",
                "mother",
                "daughter",
                "girl",
                "boy",
                "friends",
                "friend",
                "family",

                "young",
                "save",
                "life",
                "help",
                "evil",
                "mission",
                "time",
                "home",
                "mysterious",
                "adventure",
                "Earth",
                "team",
                "secret",
                "journey",
                "love",
                "dangerous",
                "group",
                "battle",
                "planet",
                "quest",
                "discovers",
                "fight",
                "forces",
                "war",
                "town",
                "island",
                "power",
                "ancient",
                "discover",
                "crew",
                "search",
                "epic",
                "school",
                "agent",
                "game",
                "gang",
                "forced",
                "magical",
                "space",
                "future",
                "escape",
                "past",
                "beautiful",
                "alien",
                "land",
                "enemy",
                "ship",
                "embark",
                "protect",
                "destroy",
                "legendary",
                "survive",
                "kidnapped",
                "threat"
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
                    OpeningImage = "Briefly show a physical or symbolic element that hints at the adventure to come.",
                    Setup = "Show how the world is full of adventure, even if the main characters haven't embarked upon their own yet.",
                    FunAndGames = "The main characters encounter danger at every step, but miraculously escape each time, making it look easy and even having a bit of fun in the process."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}