using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Loathing : IEmotion
{
    public string Id { get { return "loathing"; } }
    public string Name { get { return "Intense Loathing"; } }
    public string Description { get { return ""; } }
}