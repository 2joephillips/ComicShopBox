namespace ComicShop.Core;

public static class AppStorageHelper
{
    public static bool AppSetup { get; set; }

    public static string GetAppPath()
    {
        return Path.GetTempPath() + "comicShop\\";
    }

    public static string GetCoverImagesPath() {
        return Path.Combine(GetAppPath(), "coverimages");
    }

    public static string GetAppJsonFilePath()
    {
        return Path.Combine(GetAppPath(), "comicshopbox.json");
    }

    public static string GetAppSettingsPath() {
        return Path.Combine(GetAppPath(), "settings.json");
    }
    public static void LoadSettings()
    {
        AppSetup = true;
    }
}
