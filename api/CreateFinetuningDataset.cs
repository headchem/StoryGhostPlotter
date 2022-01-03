using System;
using System.Threading.Tasks;
using System.IO;
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

            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);

            using var workbook = new XLWorkbook(stream);

            //Read the first Sheet from Excel file.
            var worksheet = workbook.Worksheet(1);

            //Loop through the Worksheet rows.
            bool firstRow = true;
            var numRows = 0;
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

                    int i = 0;
                    foreach (IXLCell cell in row.Cells())
                    {
                        //var cellVal = cell.Value.ToString(); // errors on cells with line breaks?
                        var cellVal = cell.CachedValue.ToString();

                        i++;
                    }

                    numRows++;
                }
            }

            var result = new FinetuningDatasetResponse{
                Result = file.FileName + " - num rows: " + numRows + " - " + file.Length.ToString()
            };


            return new OkObjectResult(result);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex);
        }
    }

}