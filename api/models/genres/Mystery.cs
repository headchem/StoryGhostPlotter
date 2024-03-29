using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

namespace StoryGhost.Models.Genres;

public class Mystery : IGenre
{
    public string Id { get { return GenresEnum.Mystery; } }
    public string Name { get { return "Mystery"; } }
    public string Description { get { return "Mystery explores a shocking event, usually a murder or crime. A small cast of suspects all have plausible motives. The big reveal of the true culprit is always a surprise."; } }
    public List<string> Keywords
    {
        get
        {
            var listWithDupes = new List<string>{
                "puzzle", "suspense", "crime", "motives", "suspicion", "sleuth", "evidence", "interview", "interrogate", "private eye",

                // GPT-3 generated
                "obession", "hidden in plain sight", "devious plan", "forensic evidence", "mysterious motive", "red herring", "alibi", "reluctant witness", "confusing clues", "unlikely suspect",

                "mysterious",
                //"life",
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
                //"group",
                //"time",
                "lives",
                "case",
                "death",
                "dark",
                "mystery",
                //"help",
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
                //"save",
                "school",
                "sinister",
                "child",
                "serial",
                "search",
                //"events",
                "disappearance",
                "FBI",
                "secrets",
                "dangerous",
                "agent",
                "dead",
                "murders",
                "haunted",
                "disturbing",
                "killed",
                "place",
                "film",
                "protect",
                //"love",
                //"series",
                "violent",
                "conspiracy",
                "hospital",
                "accident",
                "remote",
                "city",
                "job",
                //"team",
                "memory",
                //"forces",
                "solve",
                "crew",
                "meets",
                "survive",
                "War",
                "criminal",
                "living",
                //"sent",
                //"seems",
                "suspect",
                //"found",
                "mental",
                //"return",
                "supernatural",
                "children",
                "body",
                //"inside",
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
                //"force",
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
                //"real",
                //"journey",
                //"returns",
                "follows",
                //"long",
                "officer",
                "private",
                "spirit",
                "clues",
                "isolated",
                "travels",
                //"part",
                "investigating",
                //"forced",
                //"mission",
                //"late",
                "City",
                "danger",
                //"good",
                "unravel",
                "island",
                //"attempt",
                //"realize",
                "revenge",
                "demonic",
                "alone",

                // from newest KeyBERT notbook

                "detective",
                "town",
                "woman",
                "murder",
                "house",
                "gang",
                "family",
                "haunted",
                "daughter",
                "FBI",
                "murders",
                "American",
                "supernatural",
                "discover",
                "father",
                "crime",
                "Los Angeles",
                "disappearance",
                "London",
                "conspiracy",
                "killer",
                "hospital",
                "New York",
                "couple",
                "agent",
                "apartment",
                "crew",
                "professor",
                "kidnapped",
                "serial",
                "U.S.",
                "wife",
                "uncover",
                "husband",
                "island",
                "dark",
                "son",
                "doctor",
                "escape",
                "ghost",
                "life",
                "investigator",
                "missing",
                "journalist",
                "secrets",
                "nightmare",
                "mansion",
                "accused",
                "solve",
                "police",
                "sinister",
                "mother",
                "deadly",
                "journey",
                "search",
                "sister",
                "alien",
                "Chicago",
                "brutal",
                "series",
                "accident",
                "haunting",
                "World War II",
                "Paris",
                "strange",
                "death",
                "children",
                "nurse",
                "elderly",
                "thief",
                "evil",
                "friends",
                "reporter",
                "psychologist",
                "disappeared",
                "Earth",
                "mystery",
                "psychiatrist",
                "horror",
                "murdered",
                "kidnapping",
                "spirit",
                "student",
                "demonic",
                "brother",
                "novelist",
                "vigilante",
                "attorney",
                "discovery",
                "California",
                "child",
                "memory",
                "neighbors",
                "obsessed",
                "save",
                "ghosts",
                "investigate",
                "space",
                "path",
                "village",
                "night",
                "deceased",
                "crimes",
                "homicide",
                "college",
                "detectives",
                "plot",
                "students",
                "writer",
                "terrifying",
                "assassin",
                "threat",
                "obsession",
                "travel",
                "company",
                "boy",
                "disease",
                "city",
                "wake",
                "beach",
                "beautiful",
                "disturbing",
                "ransom",
                "mysterious",
                //"wakes",
                "target",
                "heist",
                "strangers",
                "girlfriend",
                "vacationing",
                "force",
                "romance",
                "returns",
                "sisters",
                "criminals",
                "horrific",
                "nightmares",
                "parents",
                "spy",
                "falls",
                "private",
                "guests",
                "suburban",
                "officer",
                "musician",
                "investigation",
                "underground",
                "hunt",
                "consequences",
                "bank",
                "protect",
                "seemingly",
                "British",
                "premonition",
                "girl",
                "inspector",
                "photographer",
                "psychic",
                "reunite",
                "innocent",
                "Hollywood",
                "girls",
                "tour",
                "apocalyptic",
                "murderer",
                "race",
                "boarding",
                "paranoia",
                "visions",
                "cop",
                "train",
                "travels",
                "assassination",
                "treasure",
                "twin",
                "CIA",
                "killers",
                "entity",
                "documentary",
                "camp",
                "Woodsboro",
                "book",
                "farm",
                "locked",
                "fate",
                "traveling",
                "Pennsylvania",
                "souls",
                "teenagers",
                "tropical",
                "deep",
                "power",
                "epidemic",
                "custody",
                "demons",
                "escort",
                "prisoner",
                "coming",
                "spirits",
                "possessed",
                "teacher",
                "officers",
                "possession",
                "law",
                "illness",
                "sidekick",
                "sergeant",
                "villain",
                "criminal",
                "trapped",
                "traumatic",
                "rescue",
                "submarine",
                "survivor",
                "sorority",
                "victims",
                "maniac",
                "singer",
                "school",
                "cops",
                "adults",
                "woods",
                "doll",
                "filming",
                "forces",
                "tail",
                "espionage",
                "suspects",
                "New England",
                "tragedy",
                "maze",
                "ritual",
                "wealthy",
                "estate",
                "died",
                "danger",
                "relationship",
                "Japan",
                "Tokyo",
                "trace",
                "New York City",
                "church",
                "witch",
                "Denmark",
                "ocean",
            };
        
            return listWithDupes.Distinct().ToList();
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