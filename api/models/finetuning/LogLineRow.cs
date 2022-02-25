using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryGhost.Finetuning.Models;

public class LogLineRow
{
    public string OriginalLanguage { get; set; }
    public string Title { get; set; }
    public string TitleHasSpecialChars { get; set; }
    public double Popularity { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public double VoteAverage { get; set; }
    public int VoteCount { get; set; }
    public string GenreNoSports { get; set; }
    public string Genre { get; set; }
    public List<string> Genres
    {
        get
        {
            // randomizes the order of the genres
            return Genre.Replace("[", "").Replace("]", "").Split(',').ToList().Select(g => g.Replace("'", "").Trim()).ToList().OrderBy(a => Guid.NewGuid()).ToList();
        }
    }
    public string HasSports { get; set; }
    public string HasAdult { get; set; }
    public string HasDisturbing { get; set; }
    public string Overview { get; set; }
    public double Revenue { get; set; }
    public int? Runtime { get; set; }
    public string Tagline { get; set; }
}