using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Boredom : IEmotion
{
    public string Id { get { return "boredom"; } }
    public string Name { get { return "Mild Boredom"; } }
    public string Description { get { return ""; } }
}