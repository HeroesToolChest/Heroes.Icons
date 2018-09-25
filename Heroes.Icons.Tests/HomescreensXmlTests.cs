using Heroes.Icons.Models;
using System.Linq;
using Xunit;

namespace Heroes.Icons.Tests
{
    public class HomescreensXmlTests : HeroesIconsBase
    {
        private readonly IHomescreens Homescreens;

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

        [Fact]
        public void HomeScreenImageFileNameTests()
        {
            foreach (Homescreen homescreen in Homescreens.Homescreens().ToList())
            {
                Assert.False(string.IsNullOrEmpty(homescreen.ImageFileName));
            }
        }
    }
}
