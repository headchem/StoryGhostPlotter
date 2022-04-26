using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Western : IGenre
{
    public string Id { get { return "western"; } }
    public string Name { get { return "Western"; } }
    public string Description { get { return "TODO description"; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "town",
                "gang",
                "outlaw",
                "West",
                "help",
                "Civil War",
                "rancher",
                "life",
                "Mexico",
                "sheriff",
                "Mexican",
                "notorious",
                "forced",
                "group",
                "American",
                "Texas",
                "mysterious",
                "gold",
                "local",
                "save",
                "land",
                "brothers",
                "farm",
                "job",
                "Army",
                "home",
                "ranch",
                "Apache",
                "frontier",
                "posse",
                "fight",
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
                    OpeningImage = "Show it's the wild west."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}