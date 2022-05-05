using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Western : IGenre
{
    public string Id { get { return "western"; } }
    public string Name { get { return "Western"; } }
    public string Description { get { return "Western is a genre of fiction set primarily in the latter half of the 19th century and the early 20th century in the Western United States, known as the \"Old West\" or the \"Wild West\". The Western genre sometimes portrays the conquest of the wilderness and the subordination of nature in the name of civilization or the confiscation of the territorial rights of the original, Native American, inhabitants of the frontier. The Western depicts a society organized around codes of honor and personal, direct or private justice-\"frontier justice\"-dispensed by gunfights."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "cowboy", "gunslinger", "outlaw", "Wild West", "desert", "mountains", "plains", "retribution", "gunfighter", "high noon", "revolver", "pioneers", "saloon", "gambling", "bar fight", "bounty hunter", "lawmen", "gun duel", "wilderness", "code of honor", "frontier justice", "feud", "wanderer", "horse", "desolate landscape", "frontier towns", "whiskey", "tequila", "brawling", "general store", "railroad", "telegraph", "bandanna", "trusty steed", "Union Pacific", "marshal", "remorse",

                // GPT-3 generated
                "horseback", "campfire", "cattle rustlers", "gold rush", "steam engine", "farmstead", "train robbery", "sheriff", "deputy", "town jail", "stagecoach", "shootout", "showdown", "posse", "Oregon trail", "cow wrangler", "lasso", "rodeo", "cattle branding", "homesteading", "wagon train", "Native American reservation", "frontier", "cavalry", "Sioux", "Apache",

                "town",
                "gang",
                "West",
                //"help",
                "Civil War",
                "rancher",
                "life",
                "Mexico",
                "Mexican",
                "notorious",
                //"forced",
                //"group",
                "American",
                "Texas",
                //"mysterious",
                "gold",
                "local",
                //"save",
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