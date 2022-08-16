using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Disapproval : IEmotion
{
    public string Id { get { return "disapproval"; } }
    public string Name { get { return "Intense Disapproval"; } }
    public string Description { get { return ""; } }
}