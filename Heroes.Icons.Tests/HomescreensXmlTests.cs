using Heroes.Icons.Xml;
using System.Linq;
using Xunit;

namespace Heroes.Icons.Tests
{
    public class HomescreensXmlTests : HeroesIconsBase
    {
        private readonly IHomescreensXml Homescreens;

        public HomescreensXmlTests()
        {
            Homescreens = HeroesIcons.Homescreens();
        }

        [Fact]
        public void GetTotalCountOfHomescreensTest()
        {
            Assert.True(Homescreens.Count() >= 4);
        }

        [Fact]
        public void ListOfHomescreensTest()
        {
            Assert.True(Homescreens.Homescreens().Count() >= 4);
        }
    }
}
