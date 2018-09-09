using System.IO;
using System.Reflection;

namespace Heroes.Icons.Xml
{
    internal abstract class XmlBase
    {
        protected string XmlFolderPath => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Xml");
    }
}
