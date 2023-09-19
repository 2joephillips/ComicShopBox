
namespace ComicShop.Core
{
    public class Comic
    {


        public Comic()
        {
            UsedRar = false;
        }
        public Comic(bool usedRar)
        {
            UsedRar = usedRar;
        }

        public int Id { get; set; }
        public Guid Identifier { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public byte[] CoverImage { get; set; }
        public string CoverImagePath { get; set; }
        public bool HasMetaData { get; set; }
        public ComicMetaData MetaData { get; set; }
        public ComicProcessingError Error { get; set; }
        public bool UsedRar { get; }
    }
}

public enum ComicProcessingError
{
    None = 0,
    UnableToUnzip
}
}

