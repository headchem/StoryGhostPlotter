using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Hope : IEmotion
{
    public string Id { get { return "hope"; } }
    public string Name { get { return "Moderate Hope"; } }
    public string Description { get { return ""; } }
}