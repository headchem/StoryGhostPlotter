using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Ecstasy : IEmotion
{
    public string Id { get { return "ecstasy"; } }
    public string Name { get { return "Intense Ecstasy"; } }
    public string Description { get { return ""; } }
}