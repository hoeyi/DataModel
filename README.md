# Ichosoft.DataModel #
This library contains class and methods for supporting a model utilizing data annotations for metadata support. The two public namepsaces are:
* **DataModel.Expressions:** Supports generation of queries dynamically.
* **DataModel.Annotations:** Provides helper methods for working with `System.ComponentModel.DataAnnotations`.

[Contributing Guidelines](CONTRIBUTING.md)

<br/>

## Building Project ##
By default, the project `$(BuildNumber)` property is set to zero. Uncomment the line `Extensions.Configuration.csproj` to allow auto-assignment of the build number. Once the build is complete, revert the change to the `$(BuilderNumber)` property assignment.

<br/>
