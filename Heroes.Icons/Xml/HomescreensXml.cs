using Heroes.Icons.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Heroes.Icons.Xml
{
    internal class HomescreensXml : XmlBase, IInitializable, ISettableBuild, IHomescreens
    {
        private readonly string HomescreenZipFileName = "homescreens.zip";
        private readonly string HomescreensAssembly;

        private XDocument HomescreenDataXml;

        public HomescreensXml()
        {
            HomescreensAssembly = XmlAssemblyPath + ".Homescreens";
        }

        public void Initialize()
        {
        }

        public void SetSelectedBuild(int build)
        {
            if (HomescreenDataXml != null)
                return;

            HomescreenDataXml = LoadZipFileFromManifestStream(HeroesIconsAssembly.GetManifestResourceStream($"{HomescreensAssembly}.{HomescreenZipFileName}"), Path.ChangeExtension(HomescreenZipFileName, "xml"));
        }

        public IEnumerable<Homescreen> Homescreens()
        {
            List<Homescreen> homescreen = new List<Homescreen>();
            foreach (XElement homescreenElement in HomescreenDataXml.Root.Elements())
            {
                homescreen.Add(GetHomescreenDataFromDataXml(homescreenElement));
            }

            return homescreen;
        }

        public int Count()
        {
            return HomescreenDataXml.Root.Elements().Count();
        }

        private Homescreen GetHomescreenDataFromDataXml(XElement homescreenElement)
        {
            if (homescreenElement == null)
                return null;

            Homescreen homescreen = new Homescreen()
            {
                ShortName = homescreenElement.Name.LocalName,
            };

            homescreen.ImageFileName = homescreenElement.Element("Image")?.Value;

            return homescreen;
        }
    }
}
