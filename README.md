# Heroes Icons
[![Build status](https://ci.appveyor.com/api/projects/status/kjiv2swardk47ltt?svg=true)](https://ci.appveyor.com/project/koliva8245/heroes-icons)
[![Build Status](https://travis-ci.com/koliva8245/Heroes.Icons.svg?branch=master)](https://travis-ci.com/koliva8245/Heroes.Icons)

Heroes Icons is a .NET Standard 2.0 library to access data (abilities, talents, etc...), images such as hero portraits, ability and talent icons, homescreens, battlegrounds, award icons, and others.

All data and images are part of the library.
 - Data files are in the [Xml folder](https://github.com/koliva8245/Heroes.Icons/tree/master/Heroes.Icons/Xml)
 - Images are in the [Images folder](https://github.com/koliva8245/Heroes.Icons/tree/master/Heroes.Icons/Images)

In the `Xml/HeroBuilds` folder, the `heroesdata_*_enus.min.zip` files are generated through the tool [Heroes Data Parser](https://github.com/koliva8245/HeroesDataParser)

## Usage
The library contains an interface class `IHeroesIcons'. Methods are available to access all other data.
```
IHeroesIcons heroesIcons = new HeroesIcons();

// gets the hero data of the hero Abathur
Hero hero = heroesIcons.HeroesData().HeroData("Abathur");
```
