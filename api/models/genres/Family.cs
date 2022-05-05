using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Family : IGenre
{
    public string Id { get { return "family"; } }
    public string Name { get { return "Family"; } }
    public string Description { get { return "The Family genre contains children or relates to them in the context of home and family. Often covering topics of fear, authority, and reciprocal relationships."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{

                "parents", "single parent", "sibling", "maturity",

                // GPT-3 generated
                "family dynamics", "long-lost relative", "reconciliation", "generational differences", "only child", "large family", "family secrets", "estrangement", "adoption", "multi-cultural family",

                //"life",
                //"save",
                "home",
                //"help",
                "Christmas",
                "evil",
                "adventure",
                "school",
                //"time",
                "love",
                "town",
                "secret",
                "team",
                "dog",
                "discovers",
                "meets",
                "discover",
                //"gang",
                "magical",
                "journey",
                "kids",
                "learn",
                "children",
                "Santa",
                "magic",
                //"live",
                "accidentally",
                "trip",
                //"decides",
                "quest",
                //"lives",
                //"mysterious",
                //"human",
                "city",
                "dreams",
                //"real",
                "lost",
                "plan",
                "search",
                "City",
                "mission",
                "house",
                //"return",
                "land",
                "powers",
                //"forces",
                "rescue"
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
                    // TODO
                },
                Context = new AdviceSequence
                {
                    OpeningImage = "The setting is lighthearted in tone.",
                }
            };
        }
    }

}