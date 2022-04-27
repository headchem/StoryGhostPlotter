using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Drama : IGenre
{
    public string Id { get { return "drama"; } }
    public string Name { get { return "Drama"; } }
    public string Description { get { return "Drama is the tension created between extreme forces that oppose one another. It focuses on some aspect of humanity and tests it to the extreme, revealing intense emotions and challenging the relationships of the characters involved."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "conflict", "choice", "relatability", "opposites", "defeat", "triumph", "high stakes",

                // GPT-3 generated
                "betrayal", "secrets", "redemption", "survival", "courage",

            //"life",
            "love",
            //"lives",
            "home",
            "school",
            //"time",
            //"help",
            "death",
            "town",
            "mysterious",
            //"group",
            "war",
            //"meets",
            "relationship",
            "American",
            //"falls",
            //"living",
            //"forced",
            "work",
            "job",
            "discovers",
            //"decides",
            //"save",
            "police",
            "journey",
            //"left",
            "secret",
            "returns",
            "fight",
            "career",
            "beautiful",
            "local",
            "couple",
            "student",
            //"live",
            "prison",
            "future",
            "night",
            "house",
            "child",
            //"team",
            "city",
            "college",
            "dangerous",
            "children",
            "drug",
            "crime",
            "murder",
            //"makes",
            "friendship",
            "chance",
            //"turns",
            "battle",
            "escape",
            "mission",
            "struggles",
            "money",
            "violent",
            "personal",
            "marriage",
            "killer",
            "unexpected",
            "agent",
            "affair",
            "accident",
            "car",
            "revenge",
            "dead",
            //"gang",
            "estranged",
            "truth"
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
                    OpeningImage = "Tension is in the air.",
                    IncitingIncident = "An intensely stressful situation arises for the main character.",
                    Midpoint = "The main character overcomes some adversity for a brief reprieve from the stresses in their life."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}