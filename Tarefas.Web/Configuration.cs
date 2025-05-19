using MudBlazor;
using MudBlazor.Utilities;

namespace Tarefas.Web;

public static class Configuration
{
    public const string HttpClientName = "taskApp";
    public static string StripePublicKey { get; set; } = "";

    public static string BackendUrl { get; set; } = "http://localhost:5017";
    
    public static MudTheme Theme = new()
    {
        Typography = new Typography
        {
           Default = new DefaultTypography
           {
           FontFamily = ["Raleway", "sans-serif"]
        }
        },
        
        PaletteLight = new PaletteLight
        {
            Primary = new MudColor("#1e8cfa"),
            PrimaryContrastText = new MudColor("#000000"),
            Secondary = Colors.LightBlue.Lighten2,
            Background = Colors.Gray.Lighten4,
            AppbarBackground = new MudColor("#1e8cfa"),
            AppbarText = Colors.Shades.Black,
            TextPrimary = Colors.Shades.Black,
            DrawerText = Colors.Shades.White,
            DrawerBackground = Colors.Green.Darken4
        },
        PaletteDark = new PaletteDark
        {
            Primary = Colors.LightBlue.Accent3,
            Secondary = Colors.LightBlue.Darken3,
            // Background = Colors.LightGreen.Darken4,
            AppbarBackground = Colors.LightBlue.Accent3,
            AppbarText = Colors.Shades.Black,
            PrimaryContrastText = new MudColor("#000000")
        }
    };
}