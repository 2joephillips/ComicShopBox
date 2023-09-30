
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ComicShop.Core
{
    public class Comic
    {

        public Comic() { }
        public Comic(string filePath) => new Comic(filePath, false);
        public Comic(string filePath, bool usedRar)
        {
            UsedRar = usedRar;
            FilePath = filePath;
            FileName = filePath.Split("\\").Last();
            Identifier = Guid.NewGuid();
        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Guid Identifier { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public byte[] CoverImage { get; set; }
        public string CoverImagePath { get; set; }
        public bool HasMetaData { get; set; }

        [ForeignKey(typeof(ComicMetaData))]
        public int ComicMetaDataId { get; set; }

        [OneToOne]
        public ComicMetaData MetaData { get; set; }

        public ComicProcessingError Error { get; set; }
        public bool UsedRar { get; }

        public string Summary => HasMetaData ? MetaData.Summary ?? "" : "";
    }
}

public enum ComicProcessingError
{
    None = 0,
    UnableToUnzip,
    UnableToFindFile
}

