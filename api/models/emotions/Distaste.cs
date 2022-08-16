using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Distaste : IEmotion
{
    public string Id { get { return "distaste"; } }
    public string Name { get { return "Mild Distaste"; } }
    public string Description { get { return ""; } }
}