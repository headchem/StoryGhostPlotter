using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class ProtectPossession : IPrimalStakes
{
    public string Id { get { return "protectPossession"; } }
    public string Name { get { return "protect a possession"; } }
    public string Description { get { return "The Hero possesses or desires a special object that gives their life meaning. An outsider threatens to destroy or steal the object, while the Hero will sacrifice everything to protect or acquire the object."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "greed", "prize", "abundance", "covet", "possess"
            };
        }
    }

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                Setup = "The main character starts off with a valuable possession.",
                IncitingIncident = "A dangerous outsider threatens to take the main character's possession.",
                Midpoint = "The main character is able to partially protect their possession.",
                BadGuysCloseIn = "The threat is still looming towards the main character's possession.",
                AllHopeIsLost = "The main character is incapacitated, and appears to have lost any ability to protect their possession.",
                Climax = "Using lessons the main character learned throughout this ordeal, they successfully protect their possession, defeating the threat once and for all."

            };
        }
    }
}