using EclipseWebAppClassLibrary.Data.GridData;
using EclipseWebAppClassLibrary.Data.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ICarData, CarData>();
builder.Services.AddScoped<IAnalyticsData, AnalyticsData>();
builder.Services.AddScoped<IEmployeeData, EmployeeData>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// Load all assemblies from the EclipsePageLibrary project
var libraryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
var libraryFiles = Directory.GetFiles(libraryPath, "EclipsePageLibrary*.dll", SearchOption.TopDirectoryOnly);
foreach (var libraryFile in libraryFiles)
    try
    {
        var assembly = Assembly.LoadFrom(libraryFile);
        app.MapRazorComponents<BlazorTrainingTwo.Components.App>().AddAdditionalAssemblies(assembly)
            .AddInteractiveServerRenderMode(); // AddInteractiveServerRenderMode should be called here
    }
    catch (Exception ex)
    {
        // Log or handle the exception
        Console.WriteLine($"Failed to load assembly: {libraryFile}. Error: {ex.Message}");
    }

app.Run();