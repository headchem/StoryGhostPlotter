using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Peaceful : IEmotion
{
    public string Id { get { return "peaceful"; } }
    public string Name { get { return "Mildly Peaceful"; } }
    public string Description { get { return ""; } }
}