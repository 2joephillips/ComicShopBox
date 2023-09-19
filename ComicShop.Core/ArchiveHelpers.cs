using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;

namespace ComicShop.Core
{
    public static class ArchiveHelpers
    {
        public static bool ZipUnpacked(string filePath, string tempPath, out bool usedRar)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                var tr = SharpCompress.Archives.Zip.ZipArchive.Open(fileInfo, new SharpCompress.Readers.ReaderOptions() { DisableCheckIncomplete = true, LookForHeader = true });
                tr.WriteToDirectory(tempPath);
                usedRar = false;
                return true;
            }
            catch
            {
                using (var archive = RarArchive.Open(filePath))
                {
                    foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    {
                        entry.WriteToDirectory(tempPath, new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                    usedRar = true;
                    return true;
                }
            }
        }
    }
}
