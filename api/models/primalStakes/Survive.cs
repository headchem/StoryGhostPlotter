using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class Survive : IPrimalStakes
{
    public string Id { get { return "survive"; } }
    public string Name { get { return "survive"; } }
    public string Description { get { return "An Enemy threatens the safety of the Hero's identity or physical existence. The Hero's will to persevere is tested, but they ultimately find peace."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "safety", "danger", "resistance"
            };
        }
    }

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                Setup = "The main character starts off comfortable in their life.",
                IncitingIncident = "An event threatens the main character's survival.",
                Midpoint = "The main character is able to survive, but only barely.",
                BadGuysCloseIn = "The threat to the main character's survival still looms.",
                AllHopeIsLost = "The main character's will to persevere is tested, and they appear to be losing the battle to survive.",
                Climax = "Using lessons the main character learned throughout this ordeal, they successfully survive the ordeal and find peace."
            };
        }
    }
}