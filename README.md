# Ichosys.DataModel #
This library contains classes and methods for applying metadata to objects, accessing metadata for presentation in user interfaces or for generating search expressions.

* [Building Project](#building-prjoject)
* [Public API](#api)

Be sure to read the [guidelines for contributing](CONTRIBUTING.md) to this project.

## Building Project ##
By default, the project `$(BuildNumber)` property is set to zero. Uncomment the line `Extensions.Configuration.csproj` to allow auto-assignment of the build number. Once the build is complete, revert the change to the `$(BuilderNumber)` property assignment.

## Contents ##

### DataModel 
#### IModelMetadataService ####
`IModelMetadataService` provides helper methods for accessing model metadata. This interface supports string localization using `DisplayAttribute` or similar. ([source](DataModel/IModelMetadataService.cs))
###

---

### DataModel.Annotations
Provides attributes used for describing objects and properties, as well as helper methods for working with `System.ComponentModel.DataAnnotations`.

### Examples
#### NounAttribute ####
`NounAttribute` describes the singular and plural forms and articles of a noun. ([source](DataModel/Annotations/NounAttribute.cs))

#### SearchableAttribute ####
`SearchableAttribute` signals that a member can be passed to `Expressions.IExpressionBuilder`. ([source](DataModel/Annotations/Searchable.cs))
###

---

### DataModel.Expressions 
Supports generation of query expressions based on attributes applied to class properties.

#### IExpressionBuilder ####
`IExpressionBuilder` provides generic methods used for building query expressions for properties decorated with `SearchableAttribute` and `DisplayAttribute`. ([source](DataModel/Expressions/IExpressionBuilder.cs))

#### IQueryParameter ####
`IQueryParameter` represents part of a search expression used to construct a valid left-hand side of an equation. ([source](DataModel/Expressions/IQueryParameter.cs))

#### ISearchableMemberMetadata ####
`ISearchableMemberMetadata` represents a class member for which query expressions can be built. ([source](DataModel/Expressions/ISearchableMemberMetadata.cs))

###
