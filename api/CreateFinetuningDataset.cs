using System;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using StoryGhost.Util;
using StoryGhost.Models;
using ClosedXML.Excel;

namespace StoryGhost.LogLine;
public static class CreateFinetuningDataset
{
    [FunctionName("CreateFinetuningDataset")]
    public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req, ILogger log)
    {
        try
        {
            var formdata = await req.ReadFormAsync();
            var file = req.Form.Files["myFile"];

            var stories = await getStoryRows(file);

            var results = new Dictionary<string, List<FinetuningRow>>();

            var completionTypes = new List<string>{
                "orphanSummary",
                "orphanFull",
                "wandererSummary",
                "wandererFull",
                "warriorSummary",
                "warriorFull",
                "martyrSummary",
                "martyrFull"
            };

            foreach (var completionType in completionTypes)
            {
                results[completionType] = getRows(completionType, stories);
            }

            return new OkObjectResult(results);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex);
        }
    }

    private static List<FinetuningRow> getRows(string completionType, List<Story> stories)
    {
        var results = new List<FinetuningRow>();

        foreach (var story in stories)
        {
            var row = getPromptAndCompletion(completionType, story);
            results.Add(row);
        }

        return results;
    }

    private static FinetuningRow getPromptAndCompletion(string completionType, Story story)
    {
        var row = new FinetuningRow();

        story.CompletionType = completionType;
        row.Prompt = Factory.GetPrompt(story);
        row.Completion = completionType switch
        {
            "orphanSummary" => story.OrphanSummary,
            "orphanFull" => story.OrphanFull,
            "wandererSummary" => story.WandererSummary,
            "wandererFull" => story.WandererFull,
            "warriorSummary" => story.WarriorSummary,
            "warriorFull" => story.WarriorFull,
            "martyrSummary" => story.MartyrSummary,
            "martyrFull" => story.MartyrFull,
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(completionType)),
        };

        row.Completion = " " + row.Completion.Trim() + "###"; // According to OpenAI guidelines: "Each completion should start with a whitespace due to our tokenization, which tokenizes most words with a preceding whitespace. Each completion should end with a fixed stop sequence to inform the model when the completion ends. A stop sequence could be \n, ###, or any other token that does not appear in any completion." HOWEVER, a YouTube video from OpenAI said that the preceeding space before completions wasn't needed for open-ended generation tasks.

        return row;
    }

    /// <summary>Given an Excel file, return a fully populated <c>List<Story></c></summary>
    private static async Task<List<Story>> getStoryRows(IFormFile file)
    {
        using var stream = new MemoryStream();
        await file.CopyToAsync(stream);

        using var workbook = new XLWorkbook(stream);

        //Read the first Sheet from Excel file.
        var worksheet = workbook.Worksheet(1);

        //Loop through the Worksheet rows.
        bool firstRow = true;
        var stories = new List<Story>();

        foreach (IXLRow row in worksheet.Rows())
        {
            //Use the first row to add columns to DataTable.
            if (firstRow)
            {
                // skip first row
                firstRow = false;
            }
            else
            {
                // stop iterating once an empty row is found
                if (string.IsNullOrWhiteSpace(row.Cell(1).CachedValue.ToString())) break;

                var storyRow = new Story();

                int i = 0;
                foreach (IXLCell cell in row.Cells())
                {
                    var cellVal = cell.CachedValue.ToString();

                    cellVal = clean(cellVal);

                    switch (i)
                    {
                        case 1:
                            storyRow.Genre = cellVal;
                            break;
                        case 2:
                            storyRow.PrimalStakes = cellVal;
                            break;
                        case 3:
                            storyRow.ProblemTemplate = cellVal;
                            break;
                        case 4:
                            storyRow.HeroArchetype = cellVal;
                            break;
                        case 5:
                            storyRow.EnemyArchetype = cellVal;
                            break;
                        case 6:
                            storyRow.DramaticQuestion = cellVal;
                            break;
                        case 7:
                            storyRow.Keywords = cellVal.Split(",").Select(x => x.Trim()).ToList();
                            break;
                        case 9:
                            storyRow.OrphanFull = cellVal;
                            break;
                        case 10:
                            storyRow.OrphanSummary = cellVal;
                            break;
                        case 11:
                            storyRow.WandererFull = cellVal;
                            break;
                        case 12:
                            storyRow.WandererSummary = cellVal;
                            break;
                        case 13:
                            storyRow.WarriorFull = cellVal;
                            break;
                        case 14:
                            storyRow.WarriorSummary = cellVal;
                            break;
                        case 15:
                            storyRow.MartyrFull = cellVal;
                            break;
                        case 16:
                            storyRow.MartyrSummary = cellVal;
                            break;
                        default:
                            break;
                    }

                    i++;
                }

                stories.Add(storyRow);
            }
        }

        return stories;
    }

    private static string clean(string input)
    {
        input = input
            .Replace("“", "\"")
            .Replace("”", "\"")
            .Replace("’", "'")
            .Replace("‘", "'")
            .Replace("…", "...")
            .Replace("–", "-")
            .Replace("SET-UP:", "SETUP:")
            .Replace("ALL IS LOST:", "ALL HOPE IS LOST:");

        return input;
    }

}