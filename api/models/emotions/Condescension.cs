using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Condescension : IEmotion
{
    public string Id { get { return "condescension"; } }
    public string Name { get { return "Moderate Condescension"; } }
    public string Description { get { return ""; } }
}