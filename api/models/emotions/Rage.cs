using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Rage : IEmotion
{
    public string Id { get { return "rage"; } }
    public string Name { get { return "Intense Rage"; } }
    public string Description { get { return ""; } }
}