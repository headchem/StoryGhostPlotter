using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Fear : IEmotion
{
    public string Id { get { return "fear"; } }
    public string Name { get { return "Moderate Fear"; } }
    public string Description { get { return ""; } }
}