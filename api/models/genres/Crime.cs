using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Crime : IGenre
{
    public string Id { get { return "crime"; } }
    public string Name { get { return "Crime"; } }
    public string Description { get { return "The Crime genre centers on criminal acts and especially on the investigation, either by an amateur or a professional detective, of a serious crime, often a murder. The investigator puts themselves in harm's way as they obsess about the criminal's motives, caring more about the \"why\" than the \"what\". Most crime drama focuses on crime investigation and does not feature the courtroom."; } }
    public List<string> Keywords
    {
        get
        {
            var listWithDupes = new List<string>{
                "crime", "detective", "danger", "secrets", "hunt", "locked chest", "bank safe", "expert witness", "witness", "methodical detective", "Scotland Yard", "corruption", "inept police", "forensic", "locked room", "clues", "intruder", "medical examiner", "morgue", "lawyer", "red herring", "justice",

                // GPT-3 generated
                "cybercrime", "vandalism", "surveillance", "evidence", "alibi", "prosecutor", "defense attorney", "jury", "testimony", "confession", "FBI", "CIA", "Secret Service", "treasury", "insurance fraud", "money laundering", "forgery", "counterfeiting", "hacking", "identity theft",

                //"life",
                //"young",
                "police",
                "drug",
                "killer",
                "murder",
                "agent",
                "criminal",
                //"help",
                "gang",
                "cop",
                "heist",
                "prison",
                "death",
                //"time",
                "case",
                //"lives",
                "job",
                "bank",
                //"team",
                "local",
                "town",
                "city",
                "partner",
                "past",
                "dangerous",
                "mysterious",
                "revenge",
                //"behind",
                "money",
                "boss",
                "violent",
                "save",
                //"forced",
                //"work",
                "mob",
                "plan",
                "deadly",
                "serial",
                "game",
                "thief",
                "criminals",
                "school",
                //"group",
                "car",
                "run",

                // from newest KeyBERT notbook

                "detective",
                "FBI",
                "crime",
                "cop",
                "agent",
                "prison",
                "gang",
                "heist",
                "police",
                "New York",
                "family",
                "Los Angeles",
                "town",
                "assassin",
                "murder",
                "thief",
                "daughter",
                "drug",
                "American",
                "bank",
                "robbery",
                "criminal",
                "killers",
                "U.S.",
                "woman",
                "mob",
                "undercover",
                "kidnapped",
                "underworld",
                "London",
                "vigilante",
                "Russian",
                "officer",
                "New York City",
                "father",
                "kingpin",
                "gangster",
                "officers",
                "thieves",
                "serial",
                "criminals",
                "cops",
                "mafia",
                "plot",
                "city",
                "ransom",
                "mobster",
                "Chicago",
                "brothers",
                "brother",
                "gangsters",
                "son",
                "crew",
                "killer",
                "neighborhood",
                "wife",
                "law",
                "cartel",
                "Las Vegas",
                "revenge",
                "murders",
                "school",
                "Paris",
                "CIA",
                "suburban",
                "vengeance",
                "investigation",
                "justice",
                "terrorist",
                "detectives",
                "casino",
                "Mexican",
                "assassination",
                "violence",
                "steal",
                "homicide",
                "robbers",
                "street",
                "America",
                "driver",
                "France",
                "corruption",
                "California",
                "life",
                "inspector",
                "children",
                "beautiful",
                "murdered",
                "kidnapping",
                "Mafia",
                "hitman",
                "investigate",
                "mission",
                "disappearance",
                "brutal",
                "conspiracy",
                "diamond",
                "LAPD",
                "gangs",
                "lawyer",
                "United States",
                "path",
                "Mexico",
                "framed",
                "professor",
                "students",
                "DEA",
                "track",
                "escape",
                "girl",
                "trafficking",
                "Miami",
                "heists",
                //"Batman",
                "Detroit",
                "Chinese",
                "teenagers",
                "hostage",
                "victims",
                "accused",
                "sheriff",
                "L.A.",
                "entangled",
                //"mouse",
                "Italy",
                "policeman",
                "boss",
                "house",
                "Texas",
                "Manhattan",
                "district",
                "seemingly",
                "secret",
                "killing",
                "save",
                //"wrong",
                "parents",
                "robber",
                "attorney",
                "deadly",
                "series",
                "Brooklyn",
                "band",
                "crimes",
                "drugs",
                //"stay",
                "witness",
                "protect",
                "hunt",
                "smuggling",
                "Hollywood",
                "testify",
                "border",
                "uncover",
                "secrets",
                "assassins",
                "friends",
                "Boston",
                "aging",
                "investigating",
                "NYPD",
                "rescue",
                "marshal",
                "tragic",
                "investigator",
                "president",
                "outlaw",
                "dealer",
                "analyst",
                "sinister",
                "risk",
                "bodyguard",
                "informant",
                "lieutenant",
                "sergeant",
                "solve",
                //"Gotham City",
                "returns",
                "named",
                "cargo",
                "convicts",
                "Southern",
                "murderer",
                "released",
                "banks",
                "haunted",
                "Irish",
                "violent",
                "reunites",
                "child",
                "dead",
                "death",
                "supernatural",
                "debt",
                "dog",
                "streets",
                "apartment",
                "French",
                "jewel",
                "hospital",
                "manhunt",
                "college",
                "rob",
                "narcotics",
                "boxer",
                "empire",
                "evidence",
                "avenge",
                "forced",
                "deal",
                "couple",
                "engineer",
                "Harlem",
                "heroin",
                "bars",
                "fall",
                "executive",
                "wealthy",
                "teenage",
                "heart",
                "Marseille",
                "security",
                "discovery",
                "prisoner",
                "novelist",
                "forces",
                "cyber",
                "profiler",
                "childhood",
                "waitress",
                "husband",
                "sentenced",
                "partners",
                "bosses",
                "worth",
                "suspects",
                "crooks",
                "Florida",
                "hacker",
                "doctor",
                "psychopath",
                "bounty",
                "Hong Kong",
                "real",
                "haunt",
                "vacation",
                "hotel",
                "drama",
                "game",
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
                    OpeningImage = "Hint that bad people lurk in a dangerous world.",
                    Setup = "Establish a calm setting that an upcoming crime will shatter.",
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}