# Ichosys.DataModel #
This library contains class and methods for supporting a model using data annotations to record metadata.

* [Building Project](#building-prjoject)
* [Public API](#api)

Be sure to read the [guidelines for contributing](CONTRIBUTING.md) to this project.

## Building Project ##
By default, the project `$(BuildNumber)` property is set to zero. Uncomment the line `Extensions.Configuration.csproj` to allow auto-assignment of the build number. Once the build is complete, revert the change to the `$(BuilderNumber)` property assignment.

## API ##
This library maintains the following API for consumption:

[DataModel](#DataModel)
* [IModelMetadataService](#IModelMetadataService)
* [ModelMetadataExtension](#ModelMetadataExtension)

[DataModel.Annotations](#DataModel.Annotations)
* [NounAttribute](#NounAttribute)
* [SearchableAttribute](#SearchableAttribute)

[DataModel.Expressions](#DataModel.Expressions)
* [IExpressionBuilder](#IExpressionBuilder)
* [IQueryParameter](#IQueryParameter)
* [ISearchableMemberMetadata](#ISearchableMemberMetadata)

### DataModel 
#### IModelMetadataService ####
`IModelMetadataService` provides helper methods for accessing model metadata. This interface supports string localization using `DisplayAttribute` or similar. ([source](\DataModel\IModelMetadataService.cs))

#### ModelMetadataExtension ####
`ModelMetadataExtensions` provides extension methods for use with `Type` objects to retrieve metadata elements from member attributes. ([source](\DataModel\ModelMetadataExtension.cs))
###

---

### DataModel.Annotations
Provides helper methods for working with `System.ComponentModel.DataAnnotations`.

#### NounAttribute ####
`NounAttribute` describes the singular and plural forms and articles of a noun. ([source](\DataModel\Annotations\NounAttribute.cs))

#### SearchableAttribute ####
`SearchableAttribute` signals that a member can be passed to `Expressions.IExpressionBuilder`. ([source](\DataModel\Annotations\SearchableAttribute.cs))
###

---

### DataModel.Expressions 
Supports generation of queries dynamically.

#### IExpressionBuilder ####
`IExpressionBuilder` provides generic methods used for building query expressions dynamically. ([source](\DataModel\Expressions\IExpressionBuilder.cs))

#### IQueryParameter ####
`IQueryParameter` represents part of a search expression used to construct a valid left-hand side of an equation. ([source](\DataModel\Expressions\IQueryParameter.cs))

#### ISearchableMemberMetadata ####
`ISearchableMemberMetadata` represents a class member that is supported for building search expressions dynamically. ([source](\DataModel\Expressions\ISearchableMemberMetadata.cs))

###