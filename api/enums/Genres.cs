using System;
using System.Collections.Generic;
using StoryGhost.Models;

namespace StoryGhost.Enums;

public static class GenresEnum
{
    public static readonly string Action = "action";
    public static readonly string Adventure = "adventure";
    public static readonly string Comedy = "comedy";
    public static readonly string Crime = "crime";
    public static readonly string Drama = "drama";
    public static readonly string Family = "family";
    public static readonly string Fantasy = "fantasy";
    public static readonly string History = "history";
    public static readonly string Horror = "horror";
    public static readonly string Music = "music";
    public static readonly string Mystery = "mystery";
    public static readonly string Romance = "romance";
    public static readonly string ScienceFiction = "science fiction";
    public static readonly string Sports = "sports";
    public static readonly string Thriller = "thriller";
    public static readonly string Urban = "urban";
    public static readonly string War = "war";
    public static readonly string Western = "western";

    public static readonly List<string> All = new List<string>{
        Action,
        Adventure,
        Comedy,
        Crime,
        Drama,
        Family,
        Fantasy,
        History,
        Horror,
        Music,
        Mystery,
        Romance,
        ScienceFiction,
        Sports,
        Thriller,
        Urban,
        War,
        Western
    };
}