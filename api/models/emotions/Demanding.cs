using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Demanding : IEmotion
{
    public string Id { get { return "demanding"; } }
    public string Name { get { return "Moderately Demanding"; } }
    public string Description { get { return ""; } }
}