using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Easiness : IEmotion
{
    public string Id { get { return "easiness"; } }
    public string Name { get { return "Mild Easiness"; } }
    public string Description { get { return ""; } }
}