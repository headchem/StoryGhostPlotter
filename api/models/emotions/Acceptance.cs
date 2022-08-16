using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Acceptance : IEmotion
{
    public string Id { get { return "acceptance"; } }
    public string Name { get { return "Mild Acceptance"; } }
    public string Description { get { return ""; } }
}