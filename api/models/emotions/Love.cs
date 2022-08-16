using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Love : IEmotion
{
    public string Id { get { return "love"; } }
    public string Name { get { return "Intense Love"; } }
    public string Description { get { return ""; } }
}