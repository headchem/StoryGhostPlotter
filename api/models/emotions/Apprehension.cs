using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Apprehension : IEmotion
{
    public string Id { get { return "apprehension"; } }
    public string Name { get { return "Mild Apprehension"; } }
    public string Description { get { return ""; } }
}