using ClosedXML.Excel;
using Microsoft.JSInterop;

namespace EclipseWebApp.Data.Utilitys;

public static class ExcelUtility
{
    public static byte[] GenerateExcel<T>(IEnumerable<T> data, string sheetName)
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add(sheetName);
            // Merge cells A1:C1 and set the heading
            var mergedRange = worksheet.Range("A1:C1").Merge();
            mergedRange.Value = $"{sheetName}";
            mergedRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            mergedRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            mergedRange.Style.Font.Bold = true;
            mergedRange.Style.Font.FontSize = 15;
            mergedRange.Style.Fill.BackgroundColor = XLColor.LightGray;
            mergedRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;


            var propertyNames = typeof(T).GetProperties()
                .Select(prop => prop.Name)
                .ToList();
            // Add dynamic headings to row 3
            for (var i = 0; i < propertyNames.Count; i++)
            {
                var headingCell = worksheet.Cell(3, i + 1);
                headingCell.Value = propertyNames[i];
                headingCell.Style.Font.Bold = true;
                headingCell.Style.Fill.BackgroundColor = XLColor.LightGray;
                headingCell.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            }

            var dataRow = 4; // Start from row 4 for data

            foreach (var item in data)
            {
                // Populate data dynamically based on property names
                for (var i = 0; i < propertyNames.Count; i++)
                {
                    var value = typeof(T).GetProperty(propertyNames[i])?.GetValue(item);
                    worksheet.Cell(dataRow, i + 1).Value = value != null ? value.ToString() : string.Empty;
                }

                dataRow++;
            }

            // Auto-fit columns starting from row 3
            worksheet.ColumnsUsed().AdjustToContents();

            using (var ms = new MemoryStream())
            {
                workbook.SaveAs(ms);
                return ms.ToArray();
            }
        }
    }

    public static async Task SaveAs(IJSRuntime jSRuntime, string fileName, byte[] data)
    {
        await jSRuntime.InvokeAsync<object>(
            "BlazorDownloadFile",
            fileName,
            Convert.ToBase64String(data)
        );
    }
}