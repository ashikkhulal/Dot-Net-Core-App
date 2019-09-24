[![Build status](https://dev.azure.com/clearmeasurelabs/Onion-DevOps-Architecture/_apis/build/status/Onion-DevOps-Architecture-CI)](https://dev.azure.com/clearmeasurelabs/Onion-DevOps-Architecture/_build/latest?definitionId=7)
![TDD status](https://vsrm.dev.azure.com/clearmeasurelabs/_apis/public/Release/badge/801ebfd3-bd0a-4c92-8080-1b73805b58d1/1/4)
![UAT status](https://vsrm.dev.azure.com/clearmeasurelabs/_apis/public/Release/badge/801ebfd3-bd0a-4c92-8080-1b73805b58d1/1/6)
![Prod status](https://vsrm.dev.azure.com/clearmeasurelabs/_apis/public/Release/badge/801ebfd3-bd0a-4c92-8080-1b73805b58d1/1/7)

# Get the book & other resources
* ![Book Cover](https://images-na.ssl-images-amazon.com/images/I/41oudHNH%2BeL._SX348_BO1,204,203,200_.jpg)
* https://www.amazon.com/NET-DevOps-Azure-Developers-Architecture/dp/1484253426
  * This book is the preview edition released at the Microsoft Build conference. You can pre-order it now.
  * [Preview table of contents](https://dev.azure.com/clearmeasurelabs/801ebfd3-bd0a-4c92-8080-1b73805b58d1/_apis/git/repositories/101c3516-9d64-4757-8df5-547a7f4bbb49/Items?path=%2F.NET+DevOps+for+Azure+-+TOC.pdf&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=master&download=true&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1)
* [Azure DevOps Podcast](http://www.azuredevops.show)
* [Azure DevOps User Group](https://www.meetup.com/Azure-DevOps-User-Group/)
* [Clone this project template](https://dev.azure.com/clearmeasurelabs/801ebfd3-bd0a-4c92-8080-1b73805b58d1/_apis/git/repositories/b6025e0e-77dc-4b6b-af2b-dc16adeda1c4/Items?path=%2FOnionDevOpsArchitecture-dotnetcore2.2.zip)
* [Azure DevOps Demo Generator template](https://dev.azure.com/clearmeasurelabs/Onion-DevOps-Architecture/_git/ProjectTemplates?path=%2FREADME.md&version=GBmaster)

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


<!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-63426635-5"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());

  gtag('config', 'UA-63426635-5');
</script>
