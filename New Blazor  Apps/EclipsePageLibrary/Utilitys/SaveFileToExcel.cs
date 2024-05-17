using Microsoft.JSInterop;

namespace EclipseWebApp.Data.Utilitys;

public class SaveFileToExcel
{
    public async Task SaveAs(IJSRuntime jSRuntime, string fileName, byte[] data)
    {
        await jSRuntime.InvokeAsync<object>(
            "BlazorDownloadFile",
            fileName,
            Convert.ToBase64String(data)
        );
    }
}