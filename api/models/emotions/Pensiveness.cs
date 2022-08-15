using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Emotions;

public class Pensiveness : IEmotion
{
    public string Id { get { return "pensiveness"; } }
    public string Name { get { return "Mild Pensiveness"; } }
    public string Description { get { return ""; } }
}