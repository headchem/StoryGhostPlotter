using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryGhost.Interfaces;

public interface IAnalysisService
{
    public Task<bool> IsToxic(string text);
    
}