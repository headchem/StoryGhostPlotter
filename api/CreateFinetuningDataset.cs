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

            var result = new FinetuningDatasetResponse
            {
                Result = file.FileName + " - num rows: " + stories.Count + " - " + file.Length.ToString()
            };

            return new OkObjectResult(result);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex);
        }
    }

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

}