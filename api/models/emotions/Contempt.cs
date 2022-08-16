using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Contempt : IEmotion
{
    public string Id { get { return "contempt"; } }
    public string Name { get { return "Intense Contempt"; } }
    public string Description { get { return ""; } }
}