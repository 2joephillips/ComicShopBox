using System.Linq;

namespace ComicShop.Core
{
    public static class ComicExtensions
    {
        static Func<string, bool> identifyImageFiles = file => file.Contains(".jpg")
       || file.Contains(".png")
       || file.Contains(".JPG")
       || file.Contains(".PNG")
       || file.Contains(".jpeg")
       || file.Contains(".JPEG");
        public static Comic CreateFromFile(this Comic comic, string filePath)
        {
            try
            {
                string[] allFiles = Directory.GetFiles(filePath, "*.*", SearchOption.AllDirectories);
                string coverImageFile = allFiles.Where(identifyImageFiles).ToArray()[0];
                comic.CoverImagePath = coverImageFile;

                comic.HasMetaData = allFiles.Any(file => file.Contains(".xml"));
                if (comic.HasMetaData)
                {
                    var xmlFile = allFiles.First(file => file.Contains(".xml"));
                    comic.MetaData = XmlHelpers.DeserializeXml<ComicMetaData>(xmlFile);
                }
                comic.Error = ComicProcessingError.None;
                return comic;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
