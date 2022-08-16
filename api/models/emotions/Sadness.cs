using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Sadness : IEmotion
{
    public string Id { get { return "sadness"; } }
    public string Name { get { return "Moderate Sadness"; } }
    public string Description { get { return ""; } }
}