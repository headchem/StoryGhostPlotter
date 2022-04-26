using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Thriller : IGenre
{
    public string Id { get { return "thriller"; } }
    public string Name { get { return "Thriller"; } }
    public string Description { get { return "TODO description"; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "life",
                "mysterious",
                "group",
                "home",
                "murder",
                "time",
                "help",
                "town",
                "lives",
                "killer",
                "secret",
                "agent",
                "police",
                "death",
                "deadly",
                "house",
                "save",
                "discovers",
                "team",
                "night",
                "dangerous",
                "crime",
                "mission",
                "escape",
                "American",
                "game",
                "revenge",
                "city",
                "forced",
                "job",
                "drug",
                "dead",
                "discover",
                "prison",
                "fight",
                "John",
                "dark",
                "couple",
                "car",
                "survive",
                "crew",
                "government",
                "forces",
                "war",
                "future",
                "violent",
                "work",
                "gang",
                "murdered",
                "detective",
                "FBI",
                "cop",
                "child",
                "killed",
                "criminal",
                "kill",
                "attempt",
                "living",
                "local",
                "school",
                "evil",
                "officer",
                "kidnapped",
                "protect",
                "case",
                "truth",
                "series",
                "remote",
                "CIA",
                "children",
                "desperate",
                "search",
                "accident",
                "human",
                "terrifying",
                "survival",
                "investigate",
                "force",
                "sinister",
                "love",
                "uncover",
                "battle",
                "Dr.",
                "money",
                "powerful",
                "plan",
                "serial",
                "heist",
                "City",
                "rescue",
                "body",
                "beautiful",
                "strange",
                "attack",
                "trapped",
                "assassin",
                "missing",
                "partner",
                "secrets",
                "War",
                "bank",
                "U.S.",
                "control",
                "power",
                "suspect",
                "criminals",
                "real",
                "haunted",
                "killing",
                "Earth",
                "terrorist",
                "college",
                "killers",
                "teenage",
                "security",
                "supernatural",
                "target",
                "live",
                "taken",
                "girlfriend",
                "murders",
                "London",
                "investigation",
                "ruthless",
                "reality",
                "elite",
                "alive",
                "boss",
                "lost",
                "military",
                "international",
                "Russian",
                "personal",
                "community",
                "trip",
                "student",
                "space",
                "conspiracy",
                "brutal",
                "trail",
                "perfect",
                "British",
                "terrorists",
                "mob",
                "disturbing",
                "hospital",
                "plans",
                "year",
                "members"
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
                    OpeningImage = "Danger and intrigue permeate the mood of this setting.",
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}