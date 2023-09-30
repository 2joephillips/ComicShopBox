using ComicShopBox.Database;
using ComicShopBox.Services;
using ComicShopBox.View;
using ComicShopBox.ViewModel;
using Microsoft.Extensions.Logging;

namespace ComicShopBox
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<ComicService>();

            builder.Services.AddSingleton<ComicsViewModel>();
            builder.Services.AddSingleton<ComicDetailsViewModel>();


            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<DetailsPage>();
         
            return builder.Build();
        }
    }
}