using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Scifi : IGenre
{
    public string Id { get { return "science fiction"; } }
    public string Name { get { return "Science Fiction"; } }
    public string Description { get { return "Science Fiction is packed full of futuristic ideas, extrapolating from what's possible today into advanced science and technology. It examines the consequences of these innovations, and seeks to inspire a sense of forward-thinking wonder."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "technology", "future", "space", "aliens", "innovation"
            };
        }
    }

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                OpeningImage = "Briefly show a physical or symbolic element that demonstrates this is a futuristic scifi setting.",
                Setup = "Show the scifi setting in action, and how it permeates the everyday lives of the characters.",
                FunAndGames = "Show the most high-tech aspects of the fantasy setting, and how the characters treat it as mundane, having grown used to it."
            };
        }
    }

}