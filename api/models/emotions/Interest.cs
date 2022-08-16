using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Interest : IEmotion
{
    public string Id { get { return "interest"; } }
    public string Name { get { return "Mild Interest"; } }
    public string Description { get { return ""; } }
}