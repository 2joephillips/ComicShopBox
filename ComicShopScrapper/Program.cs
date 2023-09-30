using ComicShop.Core;
using SharpCompress;

internal class Program
{
    public static List<Comic> comics { get; private set; }

    private static void Main(string[] args)
    {

        const string ComicFilePath = "D:\\Comics";
        comics = JSONHelper.Load();
        if (Directory.Exists(ComicFilePath))
            ProcessComicDirectoryAsync(ComicFilePath);
    }

    private static void ProcessComicDirectoryAsync(string comicFilePath)
    {
        var reviewedFiles = comics.Select(comic => comic.FilePath).ToList();
        var comicFiles = Directory.GetFiles(comicFilePath, "*.cbz", SearchOption.AllDirectories).ToList();
        var unreviewedFiles = comicFiles.Where(file => !reviewedFiles.Contains(file)).ToList();
        var comicFilesNoLongerFound = reviewedFiles.Where(file => !comicFiles.Contains(file)).ToList();

        ProcessComicsNoLongerFound(comicFilesNoLongerFound);
        ProcessNewComicFiles(unreviewedFiles);

        JSONHelper.Save(comics);
    }

    private static void ProcessNewComicFiles(List<string> unreviewedFiles)
    {
        // Handle as batchs
        var chunks = unreviewedFiles.Chunk(100);
        chunks.ForEach(chunk => {
            comics.AddRange(from string filePath in chunk
                            let processedComic = ProcessComicFile(filePath)
                            select processedComic);
            JSONHelper.Save(comics);
        });
    }

    private static Comic ProcessComicFile(string filePath)
    {
        Comic comic;
        var tempFolderPath = TempStorageHelper.SetUpTempFolder(filePath);
        var ableToUnzip = ArchiveHelpers.ZipUnpacked(filePath, tempFolderPath, out bool usedRar);
        comic = ableToUnzip
            ? new Comic(filePath, usedRar).CreateFromFile(tempFolderPath)
            : new Comic(filePath) { Error = ComicProcessingError.UnableToUnzip };
        TempStorageHelper.CleanUpTempFolder(tempFolderPath);
        return comic;
    }

    private static void ProcessComicsNoLongerFound(List<string> comicFilesNoLongerFound)
    {
        foreach (var comic in comics.Where(comic => { return comicFilesNoLongerFound.Contains(comic.FilePath) && comic.Error != ComicProcessingError.UnableToFindFile; }))
        {
            comic.Error = ComicProcessingError.UnableToFindFile;
        }
        Console.WriteLine(comics);
    }
}


