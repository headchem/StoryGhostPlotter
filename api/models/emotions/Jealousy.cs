using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Jealousy : IEmotion
{
    public string Id { get { return "jealousy"; } }
    public string Name { get { return "Intense Jealousy"; } }
    public string Description { get { return ""; } }
}