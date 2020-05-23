# Heroes Icons
[![Build Status](https://dev.azure.com/kevinkoliva/Heroes%20of%20the%20Storm%20Projects/_apis/build/status/HeroesToolChest.Heroes.Icons?branchName=master)](https://dev.azure.com/kevinkoliva/Heroes%20of%20the%20Storm%20Projects/_build/latest?definitionId=4&branchName=master) [![Release](https://img.shields.io/github/release/HeroesToolChest/Heroes.Icons.svg)](https://github.com/HeroesToolChest/Heroes.Icons/releases/latest) [![NuGet](https://img.shields.io/nuget/v/Heroes.Icons.svg)](https://www.nuget.org/packages/Heroes.Icons/)

**This library is currently under development**

Heroes Icons is a dotnet core library that parses the json data extracted from [Heroes Data Parser](https://github.com/HeroesToolChest/HeroesDataParser) and provides an api to access the data along with multi-localization support.

The gamestrings can be either part of the json data files or be in localized form. If there is only going to be one supported locale, then have HDP leave it as is, otherwise include the option `--localized-text`. 

If using localized-text, the command `localized-json` must be used to convert the gamestring text files into json files. 

Another choice instead of using HDP is to use the already extracted data files at [heroes-data](https://github.com/HeroesToolChest/heroes-data).

All data files will eventually be supported (strike-through is completed)
- ~~Heroes~~
- ~~Units~~
- ~~Match Awards~~
- Hero Skins
- Mounts
- Banners
- Sprays
- ~~Announcers~~
- Voice Lines
- Portrait Packs
- Reward Portraits
- Emoticons
- Emoticon Packs
- Veterancy data

## Supported Platforms
- .Net Core 3.1+ (aiming to be .Net 5)

## Usage
There is a `<data-file-name>DataDocument` class for each json data file. Each provide static multiple `Parse` methods to parse the json files.

Example usage for parsing a non-localized json data file.
```
// read as a json file
// the localization will automatically be set as kokr since the file name ends with _kokr
using HeroDataDocument heroDataDocument = HeroDataDocument.Parse("herodata_76003_kokr.json");

// example getting hero data for Alarak
Hero heroData = heroDataDocument.GetHeroById("Alarak", true, true, true, true);

// or if the file name doesn't end with the locale, it can be set as a parameter
using HeroDataDocument heroDataDocument = HeroDataDocument.Parse("herodata_76003.json", Localization.KOKR);

// example getting hero data for Alarak
Hero heroData = heroDataDocument.GetHeroById("Alarak", true, true, true, true);
```

If the json data file is localized, then the gamestrings json file will need to be parsed as well.
```
using GameStringDocument gameStringDocument = GameStringDocument.Parse("gamestrings_76893_frfr.json");
using HeroDataDocument heroDataDocument = HeroDataDocument.Parse("herodata_76003_localized", gameStringDocument);
```

The `Parse` methods that accept a file path will load up the file by using `File.ReadAllBytes(...)`. If instead a stream is desired, `Stream` overloaded parse methods are available. Example parsing a non-localized json data file.
```
// localization must be specified as a parameter.
using FileStream stream = new FileStream("herodata_76003_enus.json", FileMode.Open);
using HeroDataDocument document = HeroDataDocument.Parse(stream, Localization.ENUS);
```

For a localized json data file, the `GameStringDocument` can accept a `Stream` argument as well.
```
using FileStream gameStringStream = new FileStream("gamestrings_76893_enus.json", FileMode.Open);
using GameStringDocument gameStringDocument = GameStringDocument.Parse(gameStringStream);

using FileStream fileStream = new FileStream("herodata_76003_localized.json", FileMode.Open);
using HeroDataDocument document = HeroDataDocument.Parse(fileStream, gameStringDocument);
```
However a better way would be to use the `Parse(Stream utf8Json, Stream utf8JsonGameStrings)` method.
```
using FileStream gameStringStream = new FileStream("gamestrings_76893_enus.json", FileMode.Open);
using FileStream fileStream = new FileStream(_dataFile, FileMode.Open);
using HeroDataDocument document = HeroDataDocument.Parse(fileStream, gameStringStream);
```



## Developing
To build and compile the code, it is recommended to use the latest version of [Visual Studio 2019 or Visual Studio Code](https://visualstudio.microsoft.com/downloads/).

Another option is to use the dotnet CLI tools from the [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download).

## License
[MIT license](/LICENSE)
