using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class War : IGenre
{
    public string Id { get { return "war"; } }
    public string Name { get { return "War"; } }
    public string Description { get { return "The War genre is concerned with warfare, typically about naval, air, or land battles, with combat scenes central to the drama. It has been strongly associated with the 20th century. The fateful nature of battle scenes means that war stories often end with them. Themes explored include combat, survival and escape, camaraderie between soldiers, sacrifice, the futility and inhumanity of battle, the effects of war on society, and the moral and human issues raised by war."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "revolutionaries", "guerilla warfare", "prisoner", "infantry", "submarine", "Pacific", "North Africa", "Vietnam", "Axis", "Allies", "military-industrial complex", "morality", "radio", "satellite", "spy plane", "bomb", "bomber", "military objective", "brave volunteers", "Soviet", "aftermath", "Civil War", "barbed wire", "mustard gas", "nuclear", "trenches", "bayonet", "protest", "puppet regime", "helicopter",

                // GPT-3 generated
                "loyalty", "following orders", "secret mission", "infiltration", "propaganda", "civilian defense", "weapons factory", "aerial dogfight", "storm the beach", "U-boat", "aircraft carrier", "enlistment", "letters home", "ambush", "befriend enemy soldier", "rationing", "desertion", "war crimes", "treaty", "postwar", "purple heart", "parades", "shellshock", "PTSD", "veteran",

                "war",
                "American",
                "mission",
                "soldiers",
                "enemy",
                "German",
                "Nazi",
                "group",
                "love",
                "U.S.",
                "Vietnam",
                "British",
                "rescue",
                "lives",
                "battle",
                "team",
                "army",
                "lines",
                "fight",
                "Army",
                "forced",
                "French",
                "officer",
                "unit",
                "country",
                "Japanese",
                "military",
                "Germany",
                "home",
                "life",
                "save",
                "pilot",
                "elite",
                "France",
                "soldier"
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
                    OpeningImage = "Set a militaristic tone.",
                    Setup = "Elaborate on the war-like conflict and how it impacts the protagonist."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

}