using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Criticism : IEmotion
{
    public string Id { get { return "criticism"; } }
    public string Name { get { return "Moderate Criticism"; } }
    public string Description { get { return ""; } }
}