using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Aggressiveness : IEmotion
{
    public string Id { get { return "aggressiveness"; } }
    public string Name { get { return "Intense Aggressiveness"; } }
    public string Description { get { return ""; } }
}