using System.Drawing;
using System.Drawing.Imaging;

namespace ComicShop.Core;

public static class ImageHelpers
{
    public static string GetCoverImagesPath()
    {
        var coverImagePath =  Path.Combine(AppStorageHelper.GetPath(), "coverImages");
        if (!Directory.Exists(coverImagePath))
        {
            Directory.CreateDirectory(coverImagePath);
        }
        return coverImagePath;
    }

    public static string CreateOptimizedCoverImage(string coverImagePath, Guid comicIdentifier )
    {
        
        var coverImageStoragePath = GetCoverImagesPath();
        using (Image img = Image.FromFile(coverImagePath))
        {
            // Define quality level for JPEG compression (0-100)
            int jpegQuality = 90;

            // Construct the full path for the optimized image
            var fileName = $"{comicIdentifier.ToString()}.jpeg";
            var optimizedImagePath = Path.Combine(coverImageStoragePath, fileName);

            // Save the image with specified format and quality
            img.Save(optimizedImagePath, ImageFormat.Jpeg); // You can use other formats like PNG if needed

            return optimizedImagePath;
        }
    }
}
