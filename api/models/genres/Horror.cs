using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Horror : IGenre
{
    public string Id { get { return "horror"; } }
    public string Name { get { return "Horror"; } }
    public string Description { get { return "Horror is intended to shock, frighten, or induce a feeling of disgust, repulsion, or loathing. It intends to create an eerie atmosphere, focusing on either psychological or supernatural aspects."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "dread", "ghosts", "psychological", "cult", "dark magic", "chains", "gloomy castle", "madness", "cruelty", "living dead", "graveyard", "exorcism","grotesque monster", "abyss", "unblinking", "hunted", "maggots", "psychotic",

                // GPT-3 generated
                "dark basement", "demonic possession", "creepy children", "fears coming to life", "doors that lock themselves", "hallucinations", "whispering gravestones", "nightmares", "buried alive", "being followed", "unsuspected serial killer", "premonitions", "cursed objects", "cannibalism", "spreading infection", "claustrophobic",

                "group",
                "mysterious",
                "home",
                "town",
                "house",
                "life",
                "evil",
                "night",
                "discover",
                //"time",
                "terrifying",
                "killer",
                "dark",
                "dead",
                "deadly",
                "survive",
                //"team",
                "school",
                "secret",
                "lives",
                "escape",
                "fight",
                "help",
                "couple",
                "supernatural",
                "discovers",
                "death",
                //"save",
                "strange",
                "remote",
                "trapped",
                "game",
                "series",
                "sinister",
                "human",
                "children",
                "child",
                "murder",
                "haunted",
                "killed",
                "students",
                "living",
                "Dr.",
                //"crew",
                //"inside",
                "city",
                //"something",
                "horror",
                //"events",
                "ancient",
                "college",
                "vampire",
                //"forces",
                "alien",
                "forced",
                "creature",
                "search",
                "film",
                //"sent",
                //"returns",
                "dangerous",
                "zombies",
                "spirit",
                "survivors",
                "victims",
                "kill",
                "accident",
                "vampires",
                "teenage",
                "killing",
                //"return",
                "serial",
                "survival",
                "force",
                "within",
                "nightmare",
                //"seems",
                "battle",
                "revenge",
                "student",
                "secrets",
                "murders",
                //"car",
                "encounter",
                "investigate",
                "monster",
                "police",
                "curse",
                "mission",
                "alone",
                "protect",
                "demonic",
                //"place",
                "violent",
                "deep",
                "apartment",
                "blood",
                "power",
                "truth",
                "lost",
                "woods",
                "community",
                "horrific",
                "body",
                "creatures",
                "reality",
                "virus",
                "disturbing",
                "hunt",
                "alive",
                "party",
                "Halloween",
                "local",
                "suspect",
                //"love",
                "isolated",
                "weekend",
                "hospital",
                "zombie",
                "terror",
                "presence",
                "shark",
                "missing",
                "hunter",
                "demon",
                "rural",
                "abandoned",
                "island",
                "hell",
                "fears",
                "teenagers",
                "die",
                "path",
                "entity",
                "taken",
                "ship",
                "cabin",
                "desperate",
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
                    OpeningImage = "Symbolize a safe and happy mood, but with horror lurking under the surface.",
                    Setup = "Things appear too good to be true for the protagonist."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}