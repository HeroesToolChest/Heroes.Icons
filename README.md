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
- Match Awards
- Hero Skins
- Mounts
- Banners
- Sprays
- ~~Announcers~~
- Voice Lines
- Portraits
- Emoticons
- Emoticon Packs
- Veterancy data

## Supported Platforms
- .Net Core 3.0+

## Usage
Look through source code for now, examples will be provided later.

## Developing
To build and compile the code, it is recommended to use the latest version of [Visual Studio 2019 or Visual Studio Code](https://visualstudio.microsoft.com/downloads/).

Another option is to use the dotnet CLI tools from the [.NET Core 3.0 SDK](https://dotnet.microsoft.com/download).

`Heroes.Models.csproj` project is a submodule. Any code changes should be commited to that repository.

## License
[MIT license](/LICENSE)
