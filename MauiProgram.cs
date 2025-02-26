using CommunityToolkit.Maui;
namespace RonaldDuPreeJr_C971;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            // Initialize the .NET MAUI Community Toolkit by adding the below line of code
            .UseMauiCommunityToolkit()
            // After initializing the .NET MAUI Community Toolkit, optionally add additional fonts
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Calibri-Regular.ttf", "CalibriRegular");
                fonts.AddFont("Calibri-Semibold.ttf", "CalibriSemibold");
            });

        // Continue initializing your .NET MAUI App here

        return builder.Build();
    }
}