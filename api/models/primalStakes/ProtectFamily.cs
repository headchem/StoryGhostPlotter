using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class ProtectFamily : IPrimalStakes
{
    public string Id { get { return "protectFamily"; } }
    public string Name { get { return "protect one's family"; } }
    public string Description { get { return "The Hero's family is threatened by a dangerous outsider. Despite conflicts within the family, their bonds cannot be broken, and the Hero will stop at nothing to protect them."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "safety", "threat", "bonds"
            };
        }
    }

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                Setup = "The main character starts off with their family in safety.",
                IncitingIncident = "A dangerous outsider threatens the safety of the main character's family.",
                Midpoint = "The main character is able to partially protect their family.",
                BadGuysCloseIn = "The threat is still looming towards the main character's family.",
                AllHopeIsLost = "The main character is incapacitated, and appears to have lost any ability to protect their family.",
                Climax = "Using lessons the main character learned throughout this ordeal, they successfully protect their family, defeating the threat once and for all."
            };
        }
    }
}