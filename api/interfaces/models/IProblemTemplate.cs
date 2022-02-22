using System;
using System.Collections.Generic;
using StoryGhost.Models.ProblemTemplates;
using StoryGhost.Models;

namespace StoryGhost.Interfaces;

public interface IProblemTemplate
{
    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
    public List<string> Keywords { get; }

    public AdviceSequence AdviceSequence { get; }

    public Adjectives OrphanAdjectives { get; }
    public Adjectives WandererAdjectives { get; }
    public Adjectives WarriorAdjectives { get; }
    public Adjectives MartyrAdjectives { get; }


    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IDramaticQuestion dramaticQuestion);
}