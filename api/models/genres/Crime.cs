using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Crime : IGenre
{
    public string Id { get { return "crime"; } }
    public string Name { get { return "Crime"; } }
    public string Description { get { return "The Crime genre centers on criminal acts and especially on the investigation, either by an amateur or a professional detective, of a serious crime, often a murder. Most crime drama focuses on crime investigation and does not feature the courtroom."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "crime", "detective", "danger", "secrets", "hunt", "locked chest", "bank safe", "expert witness", "witness", "methodical detective", "Scotland Yard", "corruption", "inept police", "forensic", "locked room", "clues", "intruder", "medical examiner", "morgue", "lawyer",

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
                "run"
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