using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Caring : IEmotion
{
    public string Id { get { return "caring"; } }
    public string Name { get { return "Moderate Caring"; } }
    public string Description { get { return ""; } }
}