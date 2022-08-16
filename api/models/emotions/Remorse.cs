using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Remorse : IEmotion
{
    public string Id { get { return "remorse"; } }
    public string Name { get { return "Intense Remorse"; } }
    public string Description { get { return ""; } }
}