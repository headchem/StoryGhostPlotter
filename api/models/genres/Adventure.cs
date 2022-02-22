using System;
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
            return new List<string>{
                "danger", "excitement", "action", "travel", "quests", "discovery"
            };
        }
    }

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                OpeningImage = "Briefly show a physical or symbolic element that hints at the adventure to come.",
                Setup = "Show how the world is full of adventure, even if the main characters haven't embarked upon their own yet.",
                FunAndGames = "The main characters encounter danger at every step, but miraculously escape each time, making it look easy and even having a bit of fun in the process."
            };
        }
    }

    public string GetLogLineContribution(long seed, IProblemTemplate problemTemplate, IDramaticQuestion dramaticQuestion)
    {
        return $"This is an award winning adventure story where the main character is placed in a risky situation that requires them to go on a quest to discover the truth.";
    }

}