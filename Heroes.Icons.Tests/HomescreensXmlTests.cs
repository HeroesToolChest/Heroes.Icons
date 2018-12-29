using Heroes.Icons.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Heroes.Icons.Tests
{
    [TestClass]
    public class HomescreensXmlTests : HeroesIconsBase
    {
        private readonly IHomescreens Homescreens;

        public HomescreensXmlTests()
        {
            Homescreens = HeroesIcons.Homescreens();
        }

        [TestMethod]
        public void GetTotalCountOfHomescreensTest()
        {
            Assert.IsTrue(Homescreens.Count() >= 4);
        }

        [TestMethod]
        public void ListOfHomescreensTest()
        {
            Assert.IsTrue(Homescreens.Homescreens().Count() >= 4);
        }

        [TestMethod]
        public void HomeScreenImageFileNameTests()
        {
            foreach (Homescreen homescreen in Homescreens.Homescreens().ToList())
            {
                Assert.IsFalse(string.IsNullOrEmpty(homescreen.ImageFileName));
            }
        }
    }
}
