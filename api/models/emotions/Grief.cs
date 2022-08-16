using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Grief : IEmotion
{
    public string Id { get { return "grief"; } }
    public string Name { get { return "Intense Grief"; } }
    public string Description { get { return ""; } }
}