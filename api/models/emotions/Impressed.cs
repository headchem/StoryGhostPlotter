using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Impressed : IEmotion
{
    public string Id { get { return "impressed"; } }
    public string Name { get { return "Mildly Impressed"; } }
    public string Description { get { return ""; } }
}