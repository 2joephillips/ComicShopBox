using ComicShopBox.Services;
using ComicShopBox.View;
using ComicShopBox.ViewModel;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
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
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Free-Solid-900.otf", "SolidIcons");
                    fonts.AddFont("Free-Regular-400.otf", "RegularIcons");
                    fonts.AddFont("Brands-Regular-400.otf", "BrandIcons");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            
            builder.Services.AddSingleton<ComicService>();
            builder.Services.AddSingleton<ComicVineApiService>();

            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<StartUpViewModel>();
            builder.Services.AddSingleton<DetailsViewModel>();

            builder.Services.AddSingleton<LoadingPage>();
            builder.Services.AddSingleton<StartUpPage>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<DetailsPage>();


            builder.Services.AddSingleton<IFolderPicker>(FolderPicker.Default);
            
            return builder.Build();
        }
    }
}