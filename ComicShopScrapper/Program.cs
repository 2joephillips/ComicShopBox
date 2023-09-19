using ComicShop.Core;

internal class Program
{


    private static void Main(string[] args)
    {
        const string ComicFilePath = "D:\\Comics";

        if (Directory.Exists(ComicFilePath))
            ProcessComicDirectory(ComicFilePath);


        void ProcessComicDirectory(string comicFilePath)
        {
            string[] fileEntries = Directory.GetFiles(ComicFilePath, "*.cbz", SearchOption.AllDirectories);
            List<Comic> comics = new List<Comic>();
            foreach (string filePath in fileEntries)
            {
                var processedComic = ProcessComicFile(filePath);

                comics.Add(processedComic);
            }

        }

        Comic ProcessComicFile(string filePath)
        {
            Comic comic;
            var tempFilePath = TempStorageHelper.SetUpTempFolder(filePath);
            if (ArchiveHelpers.ZipUnpacked(filePath, tempFilePath, out bool usedRar))
            {
                comic = new Comic(usedRar).CreateFromFile(tempFilePath);
            }
            else
            {
                comic = new Comic() { FilePath = filePath, FileName = filePath.Split("\\").Last(), Identifier = new Guid(), Error = ComicProcessingError.UnableToUnzip };
            }
            TempStorageHelper.CleanUpTempFolder(comic);
            return comic;
        }
    }
}


