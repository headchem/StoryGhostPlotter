using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Comedy : IGenre
{
    public string Id { get { return "comedy"; } }
    public string Name { get { return "Comedy"; } }
    public string Description { get { return "TODO description"; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
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
                "parents",
                "husband",
                "wife",
                "brother",
                "sister",

                "life",
                "friends",
                "school",
                "love",
                "young",
                "help",
                "time",
                "home",
                "save",
                "town",
                "Christmas",
                "team",
                "group",
                "lives",
                "decides",
                "meets",
                "secret",
                "discovers",
                "night",
                "discover",
                "college",
                "job",
                "gang",
                "falls",
                "kids",
                "girlfriend",
                "boyfriend",
                "dreams",
                "live",
                "couple",
                "mysterious",
                "trip",
                "work",
                "living",
                "adventure",
                "party",
                "house",
                "relationship",
                "forced",
                "wedding",
                "tries",
                "decide",
                "local",
                "chance",
                "children",
                "accidentally",
                "star",
                "plans",
                "learn",
                "business",
                "city",
                "fight",
                "band",
                "journey",
                "run",
                "beautiful",
                "money",
                "game",
                "learns",
                "romance",
                "single",
                "student",
                "prove"
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
                    OpeningImage = "Establish a quirky or humorous tone.",
                    Setup = "Show the protagonist in a silly situation."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}