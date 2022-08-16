using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Dislike : IEmotion
{
    public string Id { get { return "dislike"; } }
    public string Name { get { return "Mild Dislike"; } }
    public string Description { get { return ""; } }
}