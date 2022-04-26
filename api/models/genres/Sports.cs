using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Sports : IGenre
{
    public string Id { get { return "sports"; } }
    public string Name { get { return "Sports"; } }
    public string Description { get { return "The Sports genre focuses on a game that dominates the Hero's life. The game is a backdrop for the Hero's struggles to overcome adversity."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "game", "losing", "winning", "overcome", "skill",

                "team",
                "school",
                "coach",
                "player",
                "life",
                "game",
                "college",
                "match",
                "love",
                "home",
                "save",
                "help",
                "play",
                "championship",
                "star",
                "join",
                "pro",
                "dreams",
                "playing",
                "skills",
                "champion"
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
                    OpeningImage = "Briefly show a physical or symbolic element that demonstrates this story focuses on a specific sport.",
                    Setup = "Show the sports setting in action, and how it permeates the everyday lives of the characters.",
                    FunAndGames = "Celebrate the sport by showing its highs and lows. Show the sport from multiple perspectives: the players, the fans, and the business side."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}