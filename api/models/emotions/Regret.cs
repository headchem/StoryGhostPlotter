using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Regret : IEmotion
{
    public string Id { get { return "regret"; } }
    public string Name { get { return "Mild Regret"; } }
    public string Description { get { return ""; } }
}