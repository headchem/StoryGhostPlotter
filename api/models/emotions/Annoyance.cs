using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Annoyance : IEmotion
{
    public string Id { get { return "annoyance"; } }
    public string Name { get { return "Mild Annoyance"; } }
    public string Description { get { return ""; } }
}