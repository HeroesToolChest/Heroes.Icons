namespace Heroes.Icons.Tests
{
    public class HeroesIconsBase
    {
        public HeroesIconsBase()
        {
            HeroesIcons = new HeroesIcons();
        }

        protected IHeroesIcons HeroesIcons { get; private set; }
    }
}
