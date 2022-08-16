using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Possessive : IEmotion
{
    public string Id { get { return "possessive"; } }
    public string Name { get { return "Moderately Possessive"; } }
    public string Description { get { return ""; } }
}