using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Disgust : IEmotion
{
    public string Id { get { return "disgust"; } }
    public string Name { get { return "Moderate Disgust"; } }
    public string Description { get { return ""; } }
}