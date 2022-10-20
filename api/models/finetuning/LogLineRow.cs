using System;
using System.Collections.Generic;
using System.Linq;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Finetuning.Models;

public class LogLineRow
{
    public string OriginalLanguage { get; set; }
    public string Title { get; set; }
    public string TitleHasSpecialChars { get; set; }
    //public double Popularity { get; set; }
    public DateTime? ReleaseDate { get; set; }
    //public double VoteAverage { get; set; }
    //public int VoteCount { get; set; }
    public string GenreNoSports { get; set; }
    
    public string IsGoodLogLine { get; set; }
    public bool IsGoodLogLineBool
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(IsGoodLogLine) && IsGoodLogLine.ToLower().Trim() == "no")
            {
                return false;
            }
            return true;
        }
    }
    public string AppealTerms1 { get; set; }
    public string AppealTerms2 { get; set; }
    public string AppealTerms3 { get; set; }
    public string AppealTerms4 { get; set; }

    public List<IAppealTerm> AppealTerms
    {
        get
        {
            var list = new List<IAppealTerm>() {
                getAppealTermIfExists(AppealTerms1),
                getAppealTermIfExists(AppealTerms2),
                getAppealTermIfExists(AppealTerms3),
                getAppealTermIfExists(AppealTerms4)
            };

            return list.Where(a => a != null).ToList();
        }
    }

    private IAppealTerm getAppealTermIfExists(string appealTermID)
    {
        if (!string.IsNullOrWhiteSpace(appealTermID))
        {
            var appealTerm = Factory.GetAppealTerms(new List<string> { appealTermID }).First();
            return appealTerm;
        }
        return null;
    }

    public string SemiColonSpaceKeywords { get; set; }
    public List<string> SemiColonSpaceKeywordsList
    {
        get
        {
            if (string.IsNullOrWhiteSpace(SemiColonSpaceKeywords))
            {
                return new List<string>();
            }
            var words = SemiColonSpaceKeywords.TrimEnd(';').Trim().Split(';').Select(w => w.Trim()).ToList();

            return words;
        }
    }
    public List<string> GenreList
    {
        get
        {
            // randomizes the order of the genres
            var genres = GenreNoSports.Replace("[", "").Replace("]", "").Split(',').ToList().Select(g => g.Replace("'", "").Trim()).ToList().Where(g => g != "TV Movie").OrderBy(a => Guid.NewGuid()).ToList();

            if (HasSports == "Yes")
            {
                genres.Add("Sports");
            }

            return genres.Distinct().ToList();
        }
    }
    public string HasSports { get; set; }
    public string HasAdult { get; set; }
    public string HasDisturbing { get; set; }
    public string Overview { get; set; }
    //public double Revenue { get; set; }
    //public int? Runtime { get; set; }
    public string Tagline { get; set; }

    //public string Genres { get; set; }
    //public string CombinedKeywords { get; set; }
    //public string CombinedKeywordsDelim { get; set; }
    //public string Keybert { get; set; }
    //public string Ners { get; set; }
}