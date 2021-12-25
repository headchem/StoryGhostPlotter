using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class Institutionalized : IProblemTemplate
{
    public string Id { get { return "institutionalized"; } }
    public string Name { get { return "Institutionalized"; } }
    public string Description { get { return "An shunned hero holds on to their identity by going against the group's efforts to force them to conform."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "Group", "Choice", "Sacrifice"
            };
        }
    }

    public string OpeningImage { get { return ""; } }
    public string ThemeStated { get { return ""; } }
    public string Setup { get { return "The Hero shares a strong bond with their (Enemy) group."; } }
    public string IncitingIncident { get { return "The Group pursues a goal that goes against what the Hero believes in."; } }
    public string Debate { get { return ""; } }
    public string BreakIntoTwo { get { return ""; } }
    public string FunAndGames { get { return "The Hero tries out life separate from the group."; } }
    public string FirstPinchPoint { get { return "The Hero is oblivious to a symbolic reminder that being separate from the group is not the same as being an individual."; } }
    public string Midpoint { get { return ""; } }
    public string BadGuysCloseIn { get { return "The Hero feels independent, but the group is pulling them back in."; } }
    public string SecondPinchPoint { get { return ""; } }
    public string AllHopeIsLost { get { return "The Hero contemplates giving up their individualism for the sake of being accepted by the group"; } }
    public string DarkNightOfTheSoul { get { return ""; } }
    public string BreakIntoThree { get { return ""; } }
    public string Climax { get { return "The Hero finds a way to hold true to their own identity, while honoring and affecting positive change on the group."; } }
    public string Cooldown { get { return ""; } }


    public string GetLogLineContribution(int seed, IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"This is a {Name} story about the ideas of: {string.Join(", ", Keywords)}.";
    }

}