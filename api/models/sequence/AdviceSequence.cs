using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class AdviceSequence
{
    //[JsonPropertyName("sequenceName")]
    public string OpeningImage { get; set; }
    public string ThemeStated { get; set; }
    public string Setup { get; set; }
    public string SetupContinued { get; set; }
    public string IncitingIncident { get; set; }
    public string Debate { get; set; }
    public string DebateContinued { get; set; }
    public string BStory { get; set; }
    public string BreakIntoTwo { get; set; }
    public string FunAndGames { get; set; }
    public string FirstPinchPoint { get; set; }
    public string Midpoint { get; set; }
    public string BadGuysCloseIn { get; set; }
    public string SecondPinchPoint { get; set; }
    public string AllHopeIsLost { get; set; }
    public string DarkNightOfTheSoul { get; set; }
    public string BreakIntoThree { get; set; }
    public string Climax { get; set; }
    public string Cooldown { get; set; }
}