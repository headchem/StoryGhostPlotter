using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

namespace StoryGhost.Models.Genres;

public class Comedy : IGenre
{
    public string Id { get { return GenresEnum.Comedy; } }
    public string Name { get { return "Comedy"; } }
    public string Description { get { return "Comedy is intended to be humorous or amusing by inducing laughter. Stories in this style traditionally have a happy ending. The genre focuses on individual character personalities and interactions."; } }
    public List<string> Keywords
    {
        get
        {
            var listWithDupes = new List<string>{
                "uncomfortable", "mistaken", "powerless youth", "bizarre situation", "mimic the powerful", "prank", "divergent world views", "witty", "avoiding chores", "awkward situation", "accidentally successful buffoon", "mismatched partners", "silly mundane task",

                // GPT-3 generated
                "overconfidence", "bluffing", "embarrassment", "rivalry", "luck", "caught in a lie", "disguised", "caught in the act", "Incompetence", "prank gone wrong", "fool",

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
                "parents",
                "husband",
                "wife",
                "brother",
                "sister",

                //"life",
                "school",
                "love",
                //"young",
                //"help",
                //"time",
                "home",
                //"save",
                "town",
                "Christmas",
                //"team",
                //"group",
                //"lives",
                //"decides",
                "meets",
                "secret",
                "discovers",
                "night",
                "discover",
                "college",
                "job",
                //"gang",
                "falls",
                "kids",
                "girlfriend",
                "boyfriend",
                "dreams",
                //"live",
                "couple",
                //"mysterious",
                "trip",
                "work",
                //"living",
                "adventure",
                "party",
                "house",
                "relationship",
                //"forced",
                "wedding",
                //"tries",
                //"decide",
                "local",
                "chance",
                "children",
                "accidentally",
                "star",
                //"plans",
                //"learn",
                "business",
                "city",
                //"fight",
                //"band",
                //"journey",
                //"run",
                "beautiful",
                "money",
                "game",
                //"learns",
                "romance",
                "single",
                "student",
                "prove",

                // from newest KeyBERT notbook

                "family",
                "town",
                "New York",
                "woman",
                "school",
                "friends",
                "wedding",
                "gang",
                "parents",
                "father",
                "adventure",
                "Earth",
                "American",
                "daughter",
                "Los Angeles",
                "agent",
                "college",
                "Hollywood",
                "life",
                "save",
                "New York City",
                "falls",
                "London",
                "comedy",
                "island",
                "house",
                "journey",
                "party",
                "friend",
                "children",
                "wife",
                "writer",
                "dreams",
                "romance",
                "girl",
                "evil",
                "alien",
                "teenager",
                "couple",
                "band",
                "brothers",
                "cop",
                "detective",
                "dog",
                "America",
                "marriage",
                "love",
                "FBI",
                "relationship",
                "teen",
                "princess",
                "vacation",
                "teenage",
                "hotel",
                "student",
                "brother",
                "music",
                "married",
                "discover",
                "students",
                "prison",
                //"fall",
                "Paris",
                "kids",
                "police",
                "adventures",
                "mother",
                "Manhattan",
                "romantic",
                "sister",
                "revenge",
                "Santa",
                "journalist",
                "England",
                "French",
                "British",
                "beautiful",
                "village",
                "boy",
                "undercover",
                "France",
                "apartment",
                "travel",
                "son",
                "CIA",
                "book",
                "Chicago",
                "haunted",
                "girlfriend",
                "park",
                "bank",
                "cast",
                "women",
                "holiday",
                "actor",
                "professor",
                "camp",
                "relationships",
                "friendship",
                "mansion",
                "animals",
                "marry",
                "teacher",
                "trip",
                "rescue",
                "star",
                "United States",
                "engaged",
                "cat",
                "monsters",
                "heist",
                "quest",
                "sisters",
                "dad",
                "U.S.",
                "aliens",
                "zombie",
                "girls",
                "thief",
                "business",
                "canine",
                "childhood",
                "escape",
                "vampire",
                "ghost",
                "planet",
                "fashion",
                "stage",
                "bachelor",
                "couples",
                "comedian",
                //"upside",
                "stories",
                "robot",
                "fight",
                "night",
                "crime",
                "Las Vegas",
                "monster",
                "Scooby-Doo",
                "affair",
                "criminals",
                "birthday",
                //"meet",
                "comic",
                "cousin",
                "uncle",
                "road",
                "neighborhood",
                "travels",
                "dream",
                "businessman",
                "powers",
                "nanny",
                "siblings",
                "real",
                "chance",
                "supernatural",
                "series",
                "buddy",
                "spy",
                "divorce",
                "robbery",
                "dragon",
                "executive",
                "guests",
                "dating",
                "campus",
                "superheroes",
                "zombies",
                "teens",
                "estate",
                "English",
                "forced",
                "battle",
                "mom",
                "reunite",
                "discovers",
                "plot",
                "estranged",
                "reunion",
                "track",
                "live",
                "stay",
                "dance",
                "musical",
                "California",
                "actress",
                "World War II",
                "boyfriend",
                "vampires",
                "mission",
                "teach",
                "waitress",
                "social",
                "Mexican",
                "protect",
                "cheerleader",
                "daughters",
                "hometown",
                "senior",
                "fortune",
                //"asterix",
                "twin",
                "sidekick",
                "fiance",
                "heiress",
                "suburban",
                "secret",
                "talent",
                "author",
                "Mexico",
                "San Francisco",
                //"prove",
                "resort",
                "husband",
                "murder",
                "scam",
                "lost",
                "Texas",
                "death",
                "artist",
                "coach",
                "jungle",
                "bear",
                "mouse",
                "neighbors",
                "differences",
                "heart",
                "path",
                //"ready",
                "hospital",
                "wakes",
                "wishes",
                "mob",
                "magazine",
                "baseball",
                "dictator",
                "families",
                "wealthy",
                "meaning",
                "Italy",
                "European",
                "prince",
                "intergalactic",
                "head",
                "city",
                "local",
                "prom",
                "sorority",

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
                    OpeningImage = "Establish a quirky or humorous tone.",
                    Setup = "Show the protagonist in a silly situation."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}