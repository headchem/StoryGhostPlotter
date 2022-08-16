using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Deference : IEmotion
{
    public string Id { get { return "deference"; } }
    public string Name { get { return "Moderate Deference"; } }
    public string Description { get { return ""; } }
}