using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Submission : IEmotion
{
    public string Id { get { return "submission"; } }
    public string Name { get { return "Intense Submission"; } }
    public string Description { get { return ""; } }
}