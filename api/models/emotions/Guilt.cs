using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Guilt : IEmotion
{
    public string Id { get { return "guilt"; } }
    public string Name { get { return "Moderate Guilt"; } }
    public string Description { get { return ""; } }
}