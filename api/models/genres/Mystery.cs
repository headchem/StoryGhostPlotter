using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Mystery : IGenre
{
    public string Id { get { return "mystery"; } }
    public string Name { get { return "Mystery"; } }
    public string Description { get { return "Mystery explores a shocking event, usually a murder or crime. A small cast of suspects all have plausible motives. The big reveal of the true culprit is always a surprise."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "puzzle", "suspense", "crime", "motives", "suspicion",

                "mysterious",
                "life",
                "murder",
                "killer",
                "home",
                "town",
                "discover",
                "house",
                "secret",
                "detective",
                "discovers",
                "night",
                "group",
                "time",
                "lives",
                "case",
                "death",
                "dark",
                "mystery",
                "help",
                "couple",
                "gang",
                "investigate",
                "police",
                "work",
                "truth",
                "uncover",
                "murdered",
                "strange",
                "deadly",
                "game",
                "escape",
                "evil",
                "missing",
                "Dr.",
                "investigation",
                "terrifying",
                "save",
                "school",
                "sinister",
                "child",
                "serial",
                "search",
                "events",
                "disappearance",
                "FBI",
                "secrets",
                "dangerous",
                "agent",
                "crime",
                "dead",
                "murders",
                "haunted",
                "disturbing",
                "killed",
                "place",
                "film",
                "protect",
                "love",
                "series",
                "violent",
                "conspiracy",
                "hospital",
                "accident",
                "remote",
                "city",
                "job",
                "team",
                "memory",
                "forces",
                "solve",
                "crew",
                "meets",
                "survive",
                "War",
                "criminal",
                "living",
                "sent",
                "seems",
                "suspect",
                "found",
                "mental",
                "return",
                "supernatural",
                "children",
                "body",
                "inside",
                "beautiful",
                "taken",
                "horror",
                "government",
                "killing",
                "middle",
                "local",
                "investigates",
                "mysteriously",
                "community",
                "girls",
                "future",
                "fight",
                "kidnapped",
                "force",
                "trapped",
                "partner",
                "desperate",
                "perfect",
                "reporter",
                "stranger",
                "prove",
                "student",
                "victims",
                "crimes",
                "accused",
                "college",
                "real",
                "journey",
                "returns",
                "follows",
                "long",
                "officer",
                "private",
                "spirit",
                "clues",
                "isolated",
                "travels",
                "part",
                "investigating",
                "forced",
                "mission",
                "late",
                "City",
                "danger",
                "good",
                "unravel",
                "island",
                "attempt",
                "realize",
                "revenge",
                "demonic",
                "alone",
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
                    OpeningImage = "An air of intrigue fills the scene.",
                    IncitingIncident = "A mysterious event leaves the main character wanting answers.",
                    BStory = "The main character is obsessed with the mystery, even at the expense of other aspects of their life and relationships.",
                    DarkNightOfTheSoul = "The main character appears to be locked out from ever solving the mystery.",
                    Cooldown = "More mysteries await the main character, and they are eager to take them on."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}