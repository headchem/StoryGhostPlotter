using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Music : IGenre
{
    public string Id { get { return "music"; } }
    public string Name { get { return "Music"; } }
    public string Description { get { return "Stories in the Music genre focus on some aspect of music itself, while also involving music in the telling of the story."; } }
    public List<string> Keywords
    {
        get
        {
            var listWithDupes = new List<string>{
                "stage", "production",

                // GPT-3 generated
                "school production", "struggling to learn an instrument", "singing competition", "dance-off", "repairing an instrument", "forming a band", "music festival", "busking", "attending a concert", "music video", "cover band", "nightclub", "record store", "bonding over a song", "musical that mirrors life",

                //"life",
                "music",
                "school",
                "band",
                "love",
                "dreams",
                "rock",
                "show",
                "star",
                "musical",
                "dance",
                "singer",
                "competition",
                //"help",
                "dancer",
                "talent",
                "group",
                "home",
                "musician",
                "career",

                // from newest KeyBERT notbook

                "band",
                "singer",
                "music",
                "musician",
                "dancer",
                "dance",
                "musical",
                "dancers",
                "songwriter",
                "town",
                "Hollywood",
                "dreams",
                "talent",
                "family",
                "club",
                "New York",
                "musicians",
                "Los Angeles",
                "Broadway",
                "teen",
                "college",
                "girl",
                "life",
                "star",
                "gang",
                "theater",
                "stardom",
                "singing",
                "fame",
                "stage",
                "daughter",
                "artist",
                "dream",
                "law",
                "camp",
                //"Christian",
                "rise",
                "bond",
                "summer",
                "performing",
                "Chicago",
                "children",
                "competition",
                "deaf",
                //"Earth",
                "guitar",
                "singers",
                "drummer",
                "concert",
                "teenager",
                //"Troy",
                "cast",
                "twilight",
                "agent",
                "rock",
                //"Trolls",
                "disco",
                "New York City",
                "audition",
                "coming",
                "accidentally",
                "chipettes",
                "cruise",
                "chipmunks",
                "bands",
                "composer",
                "devious",
                "Sunset Strip",
                "England",
                "America",
                "prodigy",
                "royal",
                "famous",
                "collide",
                "kingdom",
                "friends",
                "American",
                "crews",
                "budding",
                "South America",
                "ballet",
                "prison",
                "finally",
                "dolls",
                "party",
                "attend",
                "Camp Rock",
                "chance",
                "sing",
                "stories",
                "engaged",
                "hearing",
                "Mexican",
                "connect",
                "seeks",
                "blues",
                "grandmother",
                //"Disney",
                "villains",
                "teenagers",
                "plane",
                "sister",
                "Southern",
                "Atlanta",
                "store",
                "students",
                "chronicle",
                "misfit",
                "dancing",
                "record",
                "pursue",
                "rap",
                "dad",
                "drama",
                "segregation",
                "Tennessee",
                "celebrity",
                "Gabriella",
                "school",
                "scholarship",
                "Memphis",
                "father",
                "Texas",
                "girlfriend",
                "boyfriend",
                "biographical",
                "piano",
                "romantic",
                "adventure",
                "woman",
                "sparkle",
                "canterlot",
                "Pennsylvania",
                "farm",
                "English",
                "NYC",
                "dog",
                "embark",
                "named",
                "Catholic",
                "Baltimore",
                //"Maryland School of the Arts",
                "street",
                //"Truth University",
                "brother",
                "mentor",
                "freshmen",
                "castle",
                "frog",
                "birthday",
                //"poppy",
                "branch",
                "sisters",
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
                    OpeningImage = "Involve music in establishing the mood of the setting.",
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}