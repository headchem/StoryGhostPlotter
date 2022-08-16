using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Anger : IEmotion
{
    public string Id { get { return "anger"; } }
    public string Name { get { return "Moderate Anger"; } }
    public string Description { get { return ""; } }
}