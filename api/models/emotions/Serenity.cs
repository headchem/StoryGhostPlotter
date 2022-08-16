using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Serenity : IEmotion
{
    public string Id { get { return "serenity"; } }
    public string Name { get { return "Mild Serenity"; } }
    public string Description { get { return ""; } }
}