using System.IO;
using System.IO.Compression;
using System.Xml.Linq;

namespace Heroes.Icons.Xml
{
    internal abstract class XmlBase
    {
        protected string XmlFolderPath => "Xml";
        protected string Localization => "enus";

        protected XDocument LoadZipFile(string zipFilePath, string xmlFile)
        {
            using (FileStream fileStream = new FileStream(zipFilePath, FileMode.Open))
            {
                using (ZipArchive zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Read))
                {
                    ZipArchiveEntry fileEntry = zipArchive.GetEntry(xmlFile);

                    return XDocument.Load(fileEntry.Open());
                }
            }
        }
    }
}
