using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Vigilance : IEmotion
{
    public string Id { get { return "vigilance"; } }
    public string Name { get { return "Intense Vigilance"; } }
    public string Description { get { return ""; } }
}