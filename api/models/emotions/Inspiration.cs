using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Inspiration : IEmotion
{
    public string Id { get { return "inspiration"; } }
    public string Name { get { return "Moderate Inspiration"; } }
    public string Description { get { return ""; } }
}