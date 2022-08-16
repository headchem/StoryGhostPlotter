using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Trust : IEmotion
{
    public string Id { get { return "trust"; } }
    public string Name { get { return "Moderate Trust"; } }
    public string Description { get { return ""; } }
}