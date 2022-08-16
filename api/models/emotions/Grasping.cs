using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Grasping : IEmotion
{
    public string Id { get { return "grasping"; } }
    public string Name { get { return "Mildly Grasping"; } }
    public string Description { get { return ""; } }
}