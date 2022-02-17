using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class ExactRevenge : IPrimalStakes
{
    public string Id { get { return "exactRevenge"; } }
    public string Name { get { return "exact revenge"; } }
    public string Description { get { return "After the Hero is betrayed, they seek justice against the entities that harmed them."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "betrayal", "seething", "catharsis", "justice"
            };
        }
    }

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                IncitingIncident = "The main character starts off trusting, but one of the other characters betrays them.",
                Debate = "The main character reels from the betrayal.",
                FunAndGames = "The main character formulates a plan to get revenge.",
                AllHopeIsLost = "The main character's plan for revenge looks like it will fail.",
                Climax = "Using lessons the main character learned throughout this ordeal, they successfully get their revenge."
            };
        }
    }
}