using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

namespace StoryGhost.Models.Genres;

public class History : IGenre
{
    public string Id { get { return GenresEnum.History; } }
    public string Name { get { return "History"; } }
    public string Description { get { return "An essential element of historical fiction is that it is set in the past and pays attention to the manners, social conditions and other details of the depicted period. Authors also frequently choose to explore notable historical figures in these settings, allowing readers to better understand how these individuals might have responded to their environments."; } }
    public List<string> Keywords
    {
        get
        {
            var listWithDupes = new List<string>{
                "royalty","nobility", "pilgrim", "hot air balloon", "Magellan's fleet", "caravel", "society", "high seas", "pirate",

                // GPT-3 generated
                "Roman Empire", "Crusades", "Renaissance", "Industrial Revolution", "Cold War", "World War I", "World War II", "tank", "tenches", "hidden manuscript", "Medieval castle", "Spartans", "Roman legion", "Gladiators", "horse and buggy",

                "life",
                "War",
                "American",
                "King",
                "war",
                "love",
                "British",
                "century",
                "lives",
                "battle",
                "team",
                "U.S.",
                "fight",
                "group",
                "army",
                //"help",
                "death",
                "Nazi",
                "America",
                //"attempt",
                "England",
                "forced",
                "country",
                "German",
                "Queen",
                "history",
                "English",
                //"would",
                "save",
                "escape",

                // from newest KeyBERT notbook

                "World War II",
                "British",
                "American",
                "German",
                "Nazi",
                "U.S.",
                "England",
                "battle",
                "English",
                "French",
                "writer",
                "France",
                "America",
                "Japanese",
                "slavery",
                "FBI",
                "soldiers",
                "family",
                "king",
                "WWII",
                "coach",
                "London",
                "drama",
                "escape",
                "Rome",
                "Jewish",
                "village",
                "Paris",
                "throne",
                "war",
                "Japan",
                "journalist",
                "terrorist",
                "agents",
                "Afghanistan",
                "journey",
                "crucifixion",
                "vengeance",
                "combat",
                "United States",
                "Germany",
                "Spain",
                "Russian",
                "fate",
                "mountains",
                "mission",
                "town",
                "prince",
                "son",
                "nation",
                "haunted",
                "New York",
                "discovery",
                "execution",
                "Nazis",
                "farmer",
                "apartheid",
                "army",
                "scandal",
                "president",
                "military",
                "kingdom",
                "assassinate",
                "harrowing",
                "island",
                "Britain",
                "invasion",
                "fights",
                "serial",
                "friend",
                "officer",
                "women",
                "Vietnam War",
                "Texas",
                "boxer",
                "roman",
                "odds",
                "history",
                "submarine",
                "raid",
                "childhood",
                "woman",
                "prison",
                "resistance",
                "lawyer",
                "slaves",
                "Army",
                "captain",
                "protect",
                "Indians",
                "frontier",
                "Russia",
                "naval",
                //"jesus",
                "Israeli",
                "relationship",
                "life",
                "colonel",
                "rescue",
                "prisoners",
                "survivors",
                "Mexico City",
                "football",
                "orphans",
                "CIA",
                "attacks",
                "ambassador",
                "depicts",
                "terrorists",
                "negotiations",
                "tense",
                "Austrian",
                "fight",
                "moved",
                "slave",
                "Watergate",
                "treason",
                "Czech",
                "civilization",
                "astronaut",
                //"Earth",
                "astronauts",
                "sister",
                "families",
                "crucified",
                "hustler",
                "falsely",
                "Norwegian",
                "kidnap",
                "senator",
                "brother",
                "police",
                "empire",
                "warrior",
                "Scottish",
                "Christian",
                "fame",
                "clock",
                "classroom",
                "soldier",
                "deserts",
                "Parisian",
                "rural",
                "Olympic Games",
                "faith",
                "troops",
                "communist",
                "attorney",
                "crew",
                "musical",
                "Allied",
                "pilot",
                "freedom",
                "brothers",
                "Holocaust",
                //"largest",
                "born",
                "screen",
                "lives",
                "reign",
                "Hollywood",
                "glimpse",
                "biopic",
                "surrender",
                "mountain",
                "quest",
                "girl",
                //"rise",
                "Khmer Rouge",
                "fought",
                "Americans",
                "civil",
                "farmers",
                "Indian",
                "ascension",
                "government",
                "reservation",
                "black",
                "college",
                "underworld",
                "siblings",
                "orbit",
                "Native American",
                "hotel",
                "India",
                "Iraq",
                "reviled",
                "teenage",
                "World War I.",
                "land",
                "dramatic",
                "seismic",
                "nazareth",
                "house",
                "Ottoman Empire",
                "Navy",
                "activist",
                "journalists",
                "flees",
                "radical",
                "Scotland",
                "widow",
                "documents",
                "Western",
                "stage",
                "famine",
                "track",
                "death",
                "age",
                "Danish",
                "Africa",
                "author",
                "forced",
                "sergeant",
                "Nero",
                "friendship",
                "beautiful",
                "outlaw",
                "bank",
                "archaeologist",
                "falls",
                "discoveries",
                "destroyed",
                "frontiersman",
                "peaceful",
                //"save",
                "bombs",
                "marine",
                "daughter",
                "comedy",
                "jesuit",
                "Gladiator",
                "Catholic Church",
                "plane",
                "secretary",
                "homeland",
                //"behavior",
                "Sparta",
                "Cold War",
                "chronicle",
                "presidential",
                "Egypt",
                "Pennsylvania",
                "Chicago",
                "explorer",
                "clash",
                "battles",
                //"scenes",
                "heir",
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
                    OpeningImage = "Show some aspect of the setting that makes it clear this takes place in a historical era.",
                    Setup = "Show aspects of the historical setting that impact the protagonist's life."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}