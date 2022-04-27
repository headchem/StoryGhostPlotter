using System;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

using StoryGhost.Interfaces;
using StoryGhost.Models;
using StoryGhost.Models.Completions;
using StoryGhost.Util;
using StoryGhost.LogLine;

namespace StoryGhost.Services;

public class KeywordsService : IKeywordsService
{

    public List<string> GetKeywords(List<string> genres, int numKeywords)
    {
        if (genres == null || genres.Count == 0) throw new Exception("You must pass in at least one genre");

        var genresObjs = Factory.GetGenres(genres);

        var keywords = new List<string>();

        foreach (var genre in genresObjs) {
            var randomizedKeywords = genre.Keywords.OrderBy(w => Guid.NewGuid()).Take(numKeywords).ToList();

            keywords.AddRange(randomizedKeywords);
        }

        keywords = keywords.Distinct().OrderBy(w => Guid.NewGuid()).Take(numKeywords).ToList();

        return keywords;
    }
}