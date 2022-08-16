using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Pushy : IEmotion
{
    public string Id { get { return "pushy"; } }
    public string Name { get { return "Mildly Pushy"; } }
    public string Description { get { return ""; } }
}