using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Surprise : IEmotion
{
    public string Id { get { return "surprise"; } }
    public string Name { get { return "Moderate Surprise"; } }
    public string Description { get { return ""; } }
}