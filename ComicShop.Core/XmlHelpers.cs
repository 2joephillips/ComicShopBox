using System.Xml.Serialization;
using System.Xml;

namespace ComicShop.Core
{
    public static class XmlHelpers
    {
        public static T DeserializeXml<T>(string xmlFilePath)
        {
            // Create an instance of the XmlSerializer with the type you want to deserialize
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (FileStream fileStream = new FileStream(xmlFilePath, FileMode.Open))
            {
                using (XmlReader xmlReader = XmlReader.Create(fileStream))
                {
                    // Deserialize the XML into an object of the specified type
                    return (T)serializer.Deserialize(xmlReader);
                }
            }
        }
    }
}
