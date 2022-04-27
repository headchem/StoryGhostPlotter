using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class History : IGenre
{
    public string Id { get { return "history"; } }
    public string Name { get { return "History"; } }
    public string Description { get { return "TODO description"; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
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