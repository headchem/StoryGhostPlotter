using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Optimism : IEmotion
{
    public string Id { get { return "optimism"; } }
    public string Name { get { return "Intense Optimism"; } }
    public string Description { get { return ""; } }
}