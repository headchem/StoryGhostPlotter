using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Terror : IEmotion
{
    public string Id { get { return "terror"; } }
    public string Name { get { return "Intense Terror"; } }
    public string Description { get { return ""; } }
}