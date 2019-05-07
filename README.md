[![Build status](https://dev.azure.com/clearmeasurelabs/Onion-DevOps-Architecture/_apis/build/status/Onion-DevOps-Architecture-CI)](https://dev.azure.com/clearmeasurelabs/Onion-DevOps-Architecture/_build/latest?definitionId=7)
![TDD status](https://vsrm.dev.azure.com/clearmeasurelabs/_apis/public/Release/badge/801ebfd3-bd0a-4c92-8080-1b73805b58d1/1/4)
![UAT status](https://vsrm.dev.azure.com/clearmeasurelabs/_apis/public/Release/badge/801ebfd3-bd0a-4c92-8080-1b73805b58d1/1/6)
![Prod status](https://vsrm.dev.azure.com/clearmeasurelabs/_apis/public/Release/badge/801ebfd3-bd0a-4c92-8080-1b73805b58d1/1/7)

# Get the book & other resources
* ![Book Cover](https://static.lulu.com/browse/product_thumbnail.php?productId=24077802&resolution=320)
* https://aka.ms/dotnetdevopsbook 
  * This book is the preview edition released at the Microsoft Build conference. You can buy it now.
* [Azure DevOps Podcast](http://www.azuredevops.show)
* [Azure DevOps User Group](https://www.meetup.com/Azure-DevOps-User-Group/)

# Introduction 
Demonstrates how to set up .Net Core for DevOps with Azure, with professional patterns including:
 * Private build
 * Test-driven development
 * Onion Architecture solution reference structure
 * Infrastructure as Code
 * CQRS
 * DevOps diagnostics
# Getting Started
Install SQL Express 2017 (localhost\sql2017) & Visual Studio 2019 (enabled w/ .NET Core 2.2)
Clone the repository
execute "click_to_build.bat" or PrivateBuild.ps1

You will have the database created locally for you, and you are ready to CTRL+F5 from Visual Studio in order to run the application.

# Build and Test
Run .\build.ps1 OR click_to_build.bat
