using System.Xml.Serialization;

namespace ComicShop.Core
{
    [XmlRoot("ComicInfo")]
    public class ComicMetaData
    {
        public string Series { get; set; }
        public string Number { get; set; }
        public int Volume { get; set; }
        public string Summary { get; set; }
        public string Notes { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string Writer { get; set; }
        public string Penciller { get; set; }
        public string Inker { get; set; }
        public string Letterer { get; set; }
        public string CoverArtist { get; set; }
        public string Editor { get; set; }
        public string Publisher { get; set; }
        public string Web { get; set; }
        public int PageCount { get; set; }
        public string Characters { get; set; }
        public string Teams { get; set; }
        public string Locations { get; set; }
        public string ScanInformation { get; set; }

        [XmlElement("Pages")]
        public Pages Pages { get; set; }
    }



    public class Pages
    {
        [XmlElement("Page")]
        public Page[] Page { get; set; }
    }

    public class Page
    {
        [XmlAttribute("Image")]
        public int Image { get; set; }
        [XmlAttribute("ImageWidth")]
        public int ImageWidth { get; set; }
        [XmlAttribute("ImageHeight")]
        public int ImageHeight { get; set; }
        [XmlAttribute("Type")]
        public string Type { get; set; }
    }
}
