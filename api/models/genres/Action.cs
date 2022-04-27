using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Action : IGenre
{
    public string Id { get { return "action"; } }
    public string Name { get { return "Action"; } }
    public string Description { get { return "TODO description"; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "chase", "disaster", "spy",

                // GPT-3 generated
                "heist", "kidnap", "bomb", "shootout", "escape", "fugitive", "",

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

                //"life",
                //"young",
                "team",
                //"save",
                //"group",
                "mission",
                //"time",
                //"help",
                "fight",
                "mysterious",
                "agent",
                "battle",
                "war",
                "Earth",
                //"evil",
                "police",
                //"dangerous",
                "secret",
                "city",
                //"forces",
                //"deadly",
                //"death",
                "prison",
                "revenge",
                "planet",
                //"forced",
                //"gang",
                //"race",
                //"past",
                "government",
                "drug",
                "cop",
                "rescue",
                //"protect",
                "criminal",
                "town",
                "home",
                //"crew",
                //"enemy",
                //"powerful",
                //"lives",
                "killed",
                "murder",
                "job",
                //"discovers",
                //"ruthless",
                "CIA",
                //"elite",
                "kidnapped",
                "army",
                "assassin",
                //"run",
                "survive",
                //"power",
                "school",
                "killer",
                "FBI",
                //"survival",
                //"violent",
                "military",
                //"target",
                "search",
                "destroy",
                "legendary",
                //"humanity",
                "car",
                "detective",
                "international",
                "investigative journalist",
                //"control",
                "undercover",
                "operative",
                "money"
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
                    OpeningImage = "Hint at this taking place in an exciting and bombastic setting.",
                    // Setup = "The characters exist in an action-packed setting.",
                    // FunAndGames = "Show the wildest and most extreme aspects of the fantasy setting, and how the characters treat it as mundane, having grown used to it."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}