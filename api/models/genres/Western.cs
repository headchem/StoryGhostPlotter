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
                "cowboy", "gunslinger", "outlaw", "Wild West", "desert", "mountains", "plains",

                // GPT-3 generated
                "horseback", "campfire", "cattle rustlers", "gold rush", "steam engine", "farmstead", "train robbery", "sheriff", "deputy", "town jail", "stagecoach", "shootout", "showdown", "posse", "Oregon trail", "cow wrangler", "lasso", "rodeo", "cattle branding", "homesteading", "wagon train", "Native American reservation", "frontier", "cavalry", "Sioux", "Apache",

                "town",
                "gang",
                "West",
                "help",
                "Civil War",
                "rancher",
                "life",
                "Mexico",
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