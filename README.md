# NewTemplateManager - To Manager Creation of Clean Architecture Solution 
# Iformation about templating can be found here https://github.com/dotnet/templating
# Additional Information on Template creation can be found in https://github.com/sayedihashimi/template-sample


It's recommended that you delete the cache folders that are used for the templates. The cache folders are in the user home directory (~) under the .templateengine folder. The default path on windows is C:\Users\{username}\.templateengine and for macOS /Users/{username}/.templateengine.

Close all instances of Visual Studio
Create a NuGet package that has the template
Delete Template Engine cache folders (folders under ~/.templateengine)
Install the template using dotnet new --install <path-to-nuget-package>
Start Visual Studio

dotnet new --list      =>will give you a list of installed templates on your system

dotnet new install . --force  => This will create a template for the current solution or project using the template.json 

dotnet new --search nuggentName ==> Will search for the nuggetName in nuget-package



###
Add DomainAuto folder to the Domain project
###

