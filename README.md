# Swastika I/O - swas·ti·ka (/ˈswästəkə/)
Swastika I/O is free, open source and cross-platform CMS based on ASP.NET Core. It is built using the best and the most modern tools and languages (Visual Studio 2017, C# etc). Be the best and join our team!

## Build Status
| Build server| Platform       | Status      |
|-------------|----------------|-------------|
| AppVeyor    | Windows        |[![Build status](https://ci.appveyor.com/api/projects/status/dup0f5a09j58ud8s?svg=true)](https://ci.appveyor.com/project/Smilefounder/swastika-core) |
|Travis       | Linux / MacOS  |[![Build Status](https://api.travis-ci.org/Swastika-IO/Swastika-Core.svg?branch=master)](https://travis-ci.org/Swastika-IO/Swastika-Core) |
|Visual Studio       | Hosted  |[![Build Status](https://swastika-io.visualstudio.com/_apis/public/build/definitions/67a4dc0a-8e40-4fd9-af40-5c8cc4a0751e/4/badge)](https://swastika-io.visualstudio.com/Swastika-IO/) |
|Code Climate       | |[![Code Climate](https://codeclimate.com/github/Swastika-IO/Swastika-Core.png)](https://codeclimate.com/github/Swastika-IO/Swastika-Core) |
|Codecov       | |[![codecov](https://codecov.io/gh/Swastika-IO/Swastika-Core/branch/master/graph/badge.svg)](https://codecov.io/gh/Swastika-IO/Swastika-Core) |


## Technology
- ASP.NET Core 2.0
- .NET Standard 2.0
- Entity Framework Core

## Architecture:
- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Notification
- CQRS (Imediate Consistency)
- Event Sourcing

## Prerequisites
- You will need Visual Studio 2017 and the .NET Core SDK (latest).
- .NET Core 2.0 for Visual Studio

## How to run on local
- Open the Swastika.sln solution in Visual Studio
- Build the solution (default apps will be copied to the "Apps" folder)
- Choose the data provider of your choice in the appsettings file and modify the default connection string accordingly if needed.
- Run (F5 or Ctrl+F5)
- Database and seed data will be created automatically the first time you run the application.

## How to contribute
Please create issues to report bugs, suggest new functionalities, ask questions or just share your thoughts about the project. Our team will really appreciate your contribution, thanks!

