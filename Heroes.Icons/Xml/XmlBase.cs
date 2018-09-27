using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Xml.Linq;

namespace Heroes.Icons.Xml
{
    internal abstract class XmlBase
    {
        protected Assembly HeroesIconsAssembly => Assembly.GetExecutingAssembly();

        protected string XmlAssemblyPath => "Heroes.Icons.Xml";
        protected string Localization => "enus";

        protected string GetAssemblyZipFileName(string streamPath)
        {
            string[] parts = streamPath.Split('.');

            return parts[parts.Length - 2] + '.' + parts[parts.Length - 1];
        }

        protected XDocument LoadZipFileFromManifestStream(Stream stream, string xmlFile)
        {
            using (ZipArchive zipArchive = new ZipArchive(stream, ZipArchiveMode.Read))
            {
                ZipArchiveEntry fileEntry = zipArchive.GetEntry(xmlFile);

                return XDocument.Load(fileEntry.Open());
            }
        }
    }
}
