using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Fantasy : IGenre
{
    public string Id { get { return "fantasy"; } }
    public string Name { get { return "Fantasy"; } }
    public string Description { get { return "Fantasy typically involves magical elements, is set in a vaguely medieval universe, and is inspired by fantastical folklore myths."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "magic", "wildness", "politics", "creatures", "legends", "supernatural",

                // GPT-3 generated
                "dragons", "wizards", "floating islands", "castle", "forest", "imprisonment", "riddles", "fairies", "hobbits", "werewolves", "vampires", "zombies", "angels", "demons", "ghosts", "witches", "warlocks", "elves", "trolls", "ogres", "goblins", "dwarves", "dungeon", "enchantment", "throne",

                "evil",
                //"life",
                //"save",
                "mysterious",
                //"time",
                //"help",
                "love",
                "magical",
                "home",
                "discovers",
                "ancient",
                "battle",
                "power",
                "King",
                "discover",
                "town",
                "Earth",
                "secret",
                "school",
                //"forces",
                "powers",
                "quest",
                "adventure",
                "journey",
                "powerful",
                "night",
                "land",
                //"living",
                "war",
                "children",
                //"falls",
                "protect",
                "human",
                "beautiful",
                "dark",
                //"forced",
                //"group",
                "monsters",
                "monster",
                "fight",
                //"return",
                "city",
                //"real",
                //"meets",
                "death",
                "dreams",
                //"live",
                //"lives",
                "search",
                "dragon",
                //"year",
                "kingdom",
                "princess",
                //"chance",
                //"team",
                "child",
                "vampire",
                "warrior",
                "fairy",
                //"epic",
                //"things",
                "accidentally",
                "strange",
                "escape",
                "island",
                "lost",
                "Queen",
                //"gang",
                "hope",
                "change",
                //"place"
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
                    OpeningImage = "Briefly show a physical or symbolic element that demonstrates this is a fantasy setting.",
                    Setup = "Show the fantasy setting in action, and how it permeates the everyday lives of the characters.",
                    FunAndGames = "Show the wildest and most extreme aspects of the fantasy setting, and how the characters treat it as mundane, having grown used to it."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}