using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Action : IGenre
{
    public string Id { get { return "action"; } }
    public string Name { get { return "Action"; } }
    public string Description { get { return "In the Action genre, the protagonist is thrust into a series of events that typically involve violence and physical feats. Action tends to feature a mostly resourceful hero struggling against incredible odds, which include life-threatening situations, a dangerous villain, or a pursuit which usually concludes in victory for the hero."; } }
    public List<string> Keywords
    {
        get
        {
            var listWithDupes = new List<string>{
                "chase", "disaster", "spy", "nuclear", "robbery", "swashbuckler", "assemble a team", "fortress", "secret weapon", "maverick police officer", "kung fu", "shanty town", "shopping mall", "high-rise building", "serial killer", "drug kingpin", "super powers", "zombies", "vengeance", "volcano", "natural disaster", "space battle", "swordfighting",

                // GPT-3 generated
                "heist", "kidnap", "bomb", "shootout", "escape", "fugitive",

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
                "money",

                // from newest KeyBERT notbook

                "Earth",
                "agent",
                "American",
                "CIA",
                "alien",
                "cop",
                "battle",
                "prison",
                "gang",
                "assassin",
                "mission",
                "town",
                "police",
                "detective",
                "FBI",
                "U.S.",
                "crime",
                "planet",
                "Los Angeles",
                "kidnapped",
                "save",
                "heist",
                "daughter",
                "Russian",
                "soldiers",
                "soldier",
                "woman",
                "terrorist",
                "rescue",
                "father",
                "island",
                "family",
                "British",
                "crew",
                "murder",
                "thief",
                "New York City",
                "evil",
                "warrior",
                "criminal",
                "revenge",
                "London",
                "vengeance",
                "pilot",
                "city",
                "New York",
                "mercenaries",
                "protect",
                "vigilante",
                "undercover",
                "fighter",
                "America",
                "war",
                "heroes",
                "French",
                "assassins",
                "powers",
                "killers",
                "adventure",
                "officer",
                "spy",
                "martial",
                "Chinese",
                "military",
                "fight",
                "United States",
                "bond",
                "World War II",
                "track",
                "forces",
                "thieves",
                "vampire",
                "criminals",
                "brother",
                "enemy",
                "aliens",
                "hope",
                "film",
                "son",
                "plot",
                "assassination",
                "agents",
                "mob",
                "survivors",
                "journey",
                "children",
                "escape",
                "vampires",
                "driver",
                "village",
                "hostage",
                "superhero",
                "justice",
                "Mexican",
                "terrorists",
                "cops",
                "brothers",
                "Japan",
                "bank",
                "mercenary",
                "girl",
                "hitman",
                "underworld",
                "superheroes",
                "drug",
                "robbery",
                "virus",
                "future",
                "France",
                "hunter",
                "ancient",
                "school",
                "Japanese",
                "supernatural",
                "Paris",
                "return",
                "conspiracy",
                "kingpin",
                "fights",
                "superpowers",
                "Navy",
                "band",
                "shark",
                "Mexico",
                "passengers",
                "wife",
                "nuclear",
                "army",
                "beautiful",
                "Africa",
                "reunite",
                "blood",
                "secret",
                "king",
                "universe",
                "quest",
                "princess",
                "hunt",
                "framed",
                "discover",
                "Nazi",
                "apocalyptic",
                "mobster",
                "life",
                "boy",
                "uncover",
                "policeman",
                "jungle",
                "sister",
                "colonel",
                "underground",
                "mafia",
                "investigate",
                "race",
                "thriller",
                "sheriff",
                "dragon",
                "captain",
                "gangsters",
                "fate",
                "desert",
                "force",
                "zombies",
                "bounty",
                "cyborg",
                "mastermind",
                "English",
                "invasion",
                "officers",
                "Las Vegas",
                "adventures",
                "robot",
                "intergalactic",
                "veteran",
                "combat",
                "sergeant",
                "villains",
                "apes",
                "friend",
                "wilderness",
                "haunted",
                "California",
                "battles",
                "rogue",
                "espionage",
                "hacker",
                "bring",
                "Egypt",
                "ship",
                "elite",
                "nemesis",
                "deadly",
                "mouse",
                "security",
                "chaos",
                "DEA",
                "path",
                "tournament",
                "missing",
                "president",
                "trafficking",
                "teen",
                "smuggling",
                "underwater",
                "ransom",
                "government",
                "strength",
                "time",
                "kingdom",
                "kidnapping",
                "friends",
                "hero",
                "returns",
                "Vietnam",
                "Britain",
                "Detroit",
                "hunting",
                "Hong Kong",
                "LAPD",
                "racing",
                "Mars",
                "Bond",
                "fighters",
                "violence",
                "sharks",
                "professor",
                "train",
                "China",
                "Autobots",
                "chance",
                "humans",
                "streets",
                "earthquake",
                "manhunt",
                //"restore",
                "samurai",
                "killer",
                "emperor",
                "prisoners",
                "heart",
                "technology",
                "avenge",
                "fugitive",
                "dinosaurs"
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