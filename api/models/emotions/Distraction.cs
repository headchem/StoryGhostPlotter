using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Distraction : IEmotion
{
    public string Id { get { return "distraction"; } }
    public string Name { get { return "Mild Distraction"; } }
    public string Description { get { return ""; } }
}