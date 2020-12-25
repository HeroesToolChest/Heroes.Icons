# Heroes Icons
[![Build Status](https://dev.azure.com/kevinkoliva/Heroes%20of%20the%20Storm%20Projects/_apis/build/status/HeroesToolChest.Heroes.Icons?branchName=master)](https://dev.azure.com/kevinkoliva/Heroes%20of%20the%20Storm%20Projects/_build/latest?definitionId=4&branchName=master) [![Release](https://img.shields.io/github/release/HeroesToolChest/Heroes.Icons.svg)](https://github.com/HeroesToolChest/Heroes.Icons/releases/latest) [![NuGet](https://img.shields.io/nuget/v/Heroes.Icons.svg)](https://www.nuget.org/packages/Heroes.Icons/)

Heroes Icons is a .NET library that parses the json data extracted from [Heroes Data Parser](https://github.com/HeroesToolChest/HeroesDataParser) and provides objects to easily access the data along with multi-localization support.

The gamestrings can be either part of the json data files or be in localized form. If there is only going to be one supported locale, then have HDP leave it as is, otherwise include the option `--localized-text`. 

If using localized-text, the command `localized-json` must be used to convert the gamestring text files into json files. 

Another choice instead of using HDP is to use the already extracted data files at [heroes-data](https://github.com/HeroesToolChest/heroes-data).

All data files are supported
- Heroes
- Units
- Match Awards
- Hero Skins
- Mounts
- Banners
- Sprays
- Announcers
- Voice Lines
- Portrait Packs
- Reward Portraits
- Emoticons
- Emoticon Packs
- Veterancy data
- Boosts
- Bundles
- Loot Chests
- Type Description data

## Usage
There is a `<data-file-name>DataDocument` class for each json data file. Each provide static multiple `Parse` methods to parse the json files.

Example usage for parsing a non-localized json data file.
```C#
// read as a json file
// the localization will automatically be set as kokr since the file name ends with _kokr
using HeroDataDocument heroDataDocument = HeroDataDocument.Parse("herodata_78679_kokr.json");

// or if the file name doesn't end with the locale, it can be set as a parameter
using HeroDataDocument heroDataDocument = HeroDataDocument.Parse("herodata_78679.json", Localization.KOKR);

// example getting hero data for Alarak
Hero heroData = heroDataDocument.GetHeroById("Alarak", true, true, true, true);
```

If the json data file is localized, then the gamestrings json file will need to be parsed as well.
```C#
using GameStringDocument gameStringDocument = GameStringDocument.Parse("gamestrings_78679_frfr.json");
using HeroDataDocument heroDataDocument = HeroDataDocument.Parse("herodata_78679_localized", gameStringDocument);
```

The `Parse` methods that accept a file path will load up the file by using `File.ReadAllBytes(...)`. If instead a stream is desired, `Stream` overloaded parse methods are available. Example parsing a non-localized json data file.
```C#
// localization must be specified as a parameter.
using FileStream stream = new FileStream("herodata_78679_enus.json", FileMode.Open);
using HeroDataDocument document = HeroDataDocument.Parse(stream, Localization.ENUS);
```

For a localized json data file, the `GameStringDocument` can accept a `Stream` argument as well.
```C#
using FileStream gameStringStream = new FileStream("gamestrings_78679_enus.json", FileMode.Open);
using GameStringDocument gameStringDocument = GameStringDocument.Parse(gameStringStream);

using FileStream fileStream = new FileStream("herodata_78679_localized.json", FileMode.Open);
using HeroDataDocument document = HeroDataDocument.Parse(fileStream, gameStringDocument);
```
However a better way would be to use the `Parse(Stream utf8Json, Stream utf8JsonGameStrings)` method.
```C#
using FileStream gameStringStream = new FileStream("gamestrings_78679_enus.json", FileMode.Open);
using FileStream fileStream = new FileStream("herodata_78679_localized.json", FileMode.Open);
using HeroDataDocument document = HeroDataDocument.Parse(fileStream, gameStringStream);
```

### Data Objects
The data objects are provided from [Heroes.Models](https://github.com/HeroesToolChest/Heroes.Models).

Example of obtaining hero data from `HeroDataDocument` and some methods that are available.
```C#
// parse the json file
using HeroDataDocument heroDataDocument = HeroDataDocument.Parse("herodata_78679_enus.json");

// get hero data for Alarak
// all four booleans are set to true to obtain his abilities, subAbilities, talents, and hero units
Hero alarakData = heroDataDocument.GetHeroById("Alarak", true, true, true, true);

// get Alarak's attribute id
string att = alarakData.AttributeId;

// his rarity
Rarity rarity = alarakData.Rarity;

// his abilities
List<Ability> abilities = alarakData.Abilities.ToList();

// get a specific ability
Ability heroicAbility = alarakData.GetAbility(new AbilityTalentId("AlarakDeadlyChargeActivate", "AlarakDeadlyCharge")
{
    AbilityType = AbilityTypes.Heroic,
});
```

### Updating Existing GameString Data
To update an object's gamestrings to a different localization without having to parse all of the data again is provided through the use of the extension method `UpdateGameStrings`. This method is available on all the data objects.

The method only accepts a `GameStringDocument` argument (since the gamestrings are just being updated, not all the data). It does not matter if the existing data is parsed from a localized or non-localized json file.

Example of usage.
```C#
// parse the json file
using HeroDataDocument heroDataDocument = HeroDataDocument.Parse("herodata_78679_enus.json");

// get the hero data 
Hero alarakData = heroDataDocument.GetHeroById("Alarak", true, true, true, true);

// later on, the korean localization is needed for Alarak, so the gamestrings just need to be updated
// first parse the korean locale gamestrings
using GameStringDocument gameStringDocument = GameStringDocument.Parse("gamestrings_78679_kokr.json");

// then update the gamestrings of alarakData
alarakData.UpdateGameStrings(gameStringDocument);
```

### HeroesDataDirectory class for heroes-data directory
If using [heroes-data](https://github.com/HeroesToolChest/heroes-data) or a similar directory structure and file naming convention, then the `HeroesDataDirectory` class provides methods to parse the files without having to use the `<data-file-name>DataDocument` classes.

Example of usage.
```C#
// by default, this will look into the heroesdata directory, otherwise provide the name of the directory
HeroesDataDirectory heroesDataDirectory = new HeroesDataDirectory();

// get the hero data document
using HeroDataDocument heroDataDocument = heroesDataDirectory.HeroData(new HeroesDataVersion(2, 49, 4, 78679), true, Localization.ENUS);

// now the hero data for Alarak can be obtained
Hero alarakData = dataDocument.GetHeroById("Alarak", true, true, true, true);

// later on we need the korean localization, so the gamestrings need to be updated
heroesDataDirectory.UpdateGameString(alarakData, new HeroesDataVersion(2, 49, 4, 78679), Localization.KOKR);
```

`HeroesDataDirectory` automatically accounts for the "duplicate" version directories by reading the `.hdp.json` files.

## Developing
To build and compile the code, it is recommended to use the latest version of [Visual Studio 2019 or Visual Studio Code](https://visualstudio.microsoft.com/downloads/).

Another option is to use the dotnet CLI tools from the [.NET Core 5.0 SDK](https://dotnet.microsoft.com/download).

## License
[MIT license](/LICENSE)
