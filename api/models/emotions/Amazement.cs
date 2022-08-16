using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Amazement : IEmotion
{
    public string Id { get { return "amazement"; } }
    public string Name { get { return "Intense Amazement"; } }
    public string Description { get { return ""; } }
}