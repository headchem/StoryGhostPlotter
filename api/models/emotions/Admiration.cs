using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Admiration : IEmotion
{
    public string Id { get { return "admiration"; } }
    public string Name { get { return "Intense Admiration"; } }
    public string Description { get { return ""; } }
}