using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class FindConnection : IPrimalStakes
{
    public string Id { get { return "findConnection"; } }
    public string Name { get { return "find connection"; } }
    public string Description { get { return "The Hero lacks a deep connection in life, and they are irresistably drawn to another entity that is seemingly incompatible. As the two learn more about each other, they develop a strong bond."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "loneliness", "rescue", "connection", "passion", "belonging"
            };
        }
    }

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                Setup = "The main character starts off feeling a lack of deep emotional connection.",
                IncitingIncident = "The main character meets someone who they feel a connection toward.",
                FunAndGames = "The main character attempts to bond with the other person, and it appears to be going well, despite their incompatibilities.",
                BadGuysCloseIn = "Cracks form in the main character's relationships.",
                AllHopeIsLost = "The main character alienates themselves.",
                Climax = "Using lessons the main character learned throughout this ordeal, they successfully cement a deep emotional bond with the other person."
            };
        }
    }
}