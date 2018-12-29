# Heroes Icons
[![Build Status](https://dev.azure.com/kevinkoliva/Heroes%20of%20the%20Storm%20Projects/_apis/build/status/koliva8245.Heroes.Icons?branchName=master)](https://dev.azure.com/kevinkoliva/Heroes%20of%20the%20Storm%20Projects/_build/latest?definitionId=4?branchName=master)

Heroes Icons is a .NET Standard 2.0 library that contains Heroes of the Storm game data, such as Hero data, abilities, talents, match awards, battlegrounds and much more.

All data and images are part of the library.
 - Data files are in the [Xml folder](https://github.com/koliva8245/Heroes.Icons/tree/master/Heroes.Icons/Xml)
 - Images are in the [Images folder](https://github.com/koliva8245/Heroes.Icons/tree/master/Heroes.Icons/Images)

The following files are generated through the tool [Heroes Data Parser](https://github.com/koliva8245/HeroesDataParser):
 - `Xml/HeroBuilds`
 - `Xml/MatchAwards`

## Usage
The library contains an interface class `IHeroesIcons`. Methods are available to access all other data.
```
IHeroesIcons heroesIcons = new HeroesIcons();

// example of one method that gets the hero data of the hero Abathur for the latest build
Hero hero = heroesIcons.HeroesData().HeroData("Abathur");
```

There is also an `ImageStreams` class that adds extension methods to some of the classes in the `Heroes.Models` project, such as the `HeroPortrait` class.
```
// continuing from code above
// gets the stream data for the hero's hero portrait
Stream heroSelectImageStream = hero.HeroPortrait().HeroSelectImage();
```


The `ImageStreams` class also contains static methods to access some other images, such as party icons
```
// gets the teal party icons data stream
Stream partyIconTeal = ImageStreams.PartyIconImage(PartyIconColor.Teal);
```

## License
[MIT license](/LICENSE)
