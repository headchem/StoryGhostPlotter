using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Joy : IEmotion
{
    public string Id { get { return "joy"; } }
    public string Name { get { return "Moderate Joy"; } }
    public string Description { get { return ""; } }
}