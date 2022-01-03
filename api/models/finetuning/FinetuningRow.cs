using System;
using System.Collections.Generic;

namespace StoryGhost.Models;

// the response to the webservice call, I guess containing a file, or the raw json string output?
public class FinetuningRow
{
    public string Prompt { get; set; }
    public string Completion {get;set;}
}