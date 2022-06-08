using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Adventure : IGenre
{
    public string Id { get { return "adventure"; } }
    public string Name { get { return "Adventure"; } }
    public string Description { get { return "Adventure is a face-paced tale where the Hero is in a risky situation. Typically involving a difficult quest, the Hero makes numerous discoveries and encounters dangers at every step."; } }
    public List<string> Keywords
    {
        get
        {
            var listWithDupes = new List<string>{
                "danger", "excitement", "action", "travel", "quests", "discovery", "exotic locale",

                // GPT-3 generated
                "life-threatening situation", "daring feats", "suspense", "heroism", "treasure", "realm", "odyssey", "perilous journey", "traps",

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

                //"young",
                //"save",
                //"life",
                //"help",
                //"evil",
                "mission",
                "time",
                "home",
                //"mysterious",
                "adventure",
                "Earth",
                //"team",
                "secret",
                "journey",
                "love",
                //"dangerous",
                //"group",
                "battle",
                "planet",
                "quest",
                //"discovers",
                "fight",
                //"forces",
                "war",
                "town",
                "island",
                //"power",
                "ancient",
                "discover",
                //"crew",
                "search",
                //"epic",
                "school",
                "agent",
                //"game",
                //"gang",
                //"forced",
                "magical",
                "space",
                //"future",
                "escape",
                //"past",
                "beautiful",
                "alien",
                //"land",
                //"enemy",
                "ship",
                "embark",
                "protect",
                "destroy",
                //"legendary",
                "survive",
                "kidnapped",
                //"threat"


                // from newest KeyBERT notbook
                "Earth",
                "adventure",
                "island",
                "father",
                "journey",
                "save",
                "American",
                "agent",
                "evil",
                "family",
                "planet",
                "alien",
                "town",
                "quest",
                "mission",
                "gang",
                "British",
                "village",
                "battle",
                "warrior",
                "dragon",
                "princess",
                "jungle",
                "Africa",
                "rescue",
                "crew",
                "powers",
                "dog",
                "kingdom",
                "adventures",
                "children",
                "London",
                "bear",
                "kidnapped",
                "dinosaurs",
                "U.S.",
                //"restore",
                "friend",
                "New York City",
                "French",
                "World War II",
                "parents",
                "robot",
                "wizard",
                "aliens",
                "America",
                "universe",
                "discover",
                "ship",
                "reunite",
                "space",
                "beautiful",
                "Paris",
                "school",
                "vengeance",
                //"bond",
                "forces",
                "band",
                "hunter",
                "mouse",
                "ancient",
                "brother",
                "revenge",
                "England",
                "boy",
                "girl",
                "prince",
                "teenager",
                "soldiers",
                "pilot",
                "thief",
                "superpowers",
                "king",
                "heroes",
                "villains",
                "superheroes",
                "wilderness",
                "monsters",
                "force",
                "escape",
                "monster",
                "Russian",
                "city",
                "captain",
                "travel",
                "military",
                "teen",
                "destiny",
                "protect",
                "vacation",
                "plane",
                //"asterix",
                "secret",
                "enemy",
                "daughter",
                "park",
                "throne",
                "spy",
                "fate",
                "New York",
                "galaxy",
                "dreams",
                "treasure",
                "war",
                "humans",
                "uncharted",
                "Los Angeles",
                "brothers",
                "ocean",
                "emperor",
                "son",
                "mountain",
                "villain",
                "CIA",
                "voyage",
                "circus",
                "time",
                "superhero",
                "soldier",
                "mercenaries",
                "intergalactic",
                "detective",
                "United States",
                "sister",
                //"Bond",
                "Egypt",
                "teens",
                "forest",
                "life",
                "archaeologist",
                "friends",
                "travels",
                "nemesis",
                "apocalyptic",
                "tribe",
                "discovery",
                "cop",
                "submarine",
                "humanity",
                "Japan",
                "shark",
                "sisters",
                "nuclear",
                "kids",
                "series",
                "strength",
                "risk",
                "astronaut",
                "inventor",
                "fairies",
                "explorers",
                "English",
                "mercenary",
                "woman",
                "stranded",
                "orphan",
                "dragons",
                "canine",
                "apes",
                "vampire",
                "Europe",
                "peter",
                "dogs",
                "Amazon",
                "supernatural",
                "Justice League",
                "prehistoric",
                "aging",
                "FBI",
                "martial",
                "underwater",
                "ant",
                //"existence",
                "moon",
                "animal",
                //"returns",
                "normal",
                "passengers",
                "threat",
                "mother",
                "bring",
                "farmer",
                "cousin",
                "book",
                "recruits",
                "house",
                "embark",
                "cave",
                "students",
                "espionage",
                "terrorist",
                "ghost",
                "castle",
                "expedition",
                "explorer",
                "desert",
                "fighter",
                "search",
                "Nazi",
                "future",
                "agents",
                "pirate",
                "power",
                "extinction",
                "crashes",
                "path",
                "epic",
                "tropical",
                "holiday",
                "scientist",
                "send",
                "magical",
                "mankind",
                "flying",
                "Chinese",
                "child",
                "survive",
                "land",
                "love",
                "map",
                "portal",
                "uncle",
                "animals",
                "romance",
                "fortune",
                "murder",
                "Romans",
                "marry",
                "roman",
                "falls",
                "tribes",
                "ranch",
                "combat",
                "wolf",
                //"forced",
                "global",
                "hero",
                "survivors",
                "African",
                "species",
                "avenge",
                "sheriff",
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
                    OpeningImage = "Briefly show a physical or symbolic element that hints at the adventure to come.",
                    Setup = "Show how the world is full of adventure, even if the main characters haven't embarked upon their own yet.",
                    FunAndGames = "The main characters encounter danger at every step, but miraculously escape each time, making it look easy and even having a bit of fun in the process."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}