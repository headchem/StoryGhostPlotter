using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Anticipation : IEmotion
{
    public string Id { get { return "anticipation"; } }
    public string Name { get { return "Moderate Anticipation"; } }
    public string Description { get { return ""; } }
}