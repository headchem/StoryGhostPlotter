using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Awe : IEmotion
{
    public string Id { get { return "awe"; } }
    public string Name { get { return "Intense Awe"; } }
    public string Description { get { return ""; } }
}