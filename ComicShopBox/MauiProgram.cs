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
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<ComicService>();

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