using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Docile : IEmotion
{
    public string Id { get { return "docile"; } }
    public string Name { get { return "Mildly Docile"; } }
    public string Description { get { return ""; } }
}