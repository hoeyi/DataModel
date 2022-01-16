# Ichosoft.DataModel #
This library contains class and methods for supporting a model utilizing data annotations for metadata support.

* [Building Project](#building-prjoject)
* [Public API](#public-api)

Be sure to read the [guidelines for contributing](CONTRIBUTING.md) to this project.

<br/>

## Building Project ##
By default, the project `$(BuildNumber)` property is set to zero. Uncomment the line `Extensions.Configuration.csproj` to allow auto-assignment of the build number. Once the build is complete, revert the change to the `$(BuilderNumber)` property assignment.

<br/>

## Public API ##
This library maintains the following API for consumption:

[DataModel](#DataModel)
* [IModelMetadataService](#IModelMetadataService)
* [ModelMetadataExtension](#ModelMetadataExtension)

[DataModel.Annotations](#DataModel.Annotations)
* [NounAttribute](#NounAttribute)
* [PropertyExtension](#PropertyExtensions)
* [SearchableAttribute](#SearchableAttribute)

[DataModel.Expressions](#DataModel.Expressions)
* [IExpressionBuilder](#IExpressionBuilder)
* [IQueryParameter](#IQueryParameter)
* [ISearchableMemberMetadata](#ISearchableMemberMetadata)


### DataModel 
#### IModelMetadataService ####
`IModelMetadataService` provides helper methods for accessing model metadata. This interface supports string localization using `DisplayAttribute` or similar.

[Details](\DataModel\IModelMetadataService.cs)

#### ModelMetadataExtension ####
`ModelMetadataExtensions` provides extension methods for use with `Type` objects to retrieve metadata elements from member attributes.

[Details](\DataModel\ModelMetadataExtension.cs)
###

---

### DataModel.Annotations
Provides helper methods for working with `System.ComponentModel.DataAnnotations`.

#### NounAttribute ####
`NounAttribute` describes the singular and plural forms and articles of a noun.

[Details](\DataModel\Annotations\NounAttribute.cs)

#### PropertyExtension ####
`PropertyExtension` provides extension methods for accessing metadata n a way that supports `MetadataType` use on model classes.

[Details](\DataModel\Annotations\PropertyExtension.cs)

#### SearchableAttribute ####
`SearchableAttribute` signals that a member can be passed to `Expressions.IExpressionBuilder`

[Details](\DataModel\Annotations\SearchableAttribute.cs)
###

---

### DataModel.Expressions 
Supports generation of queries dynamically.

#### IExpressionBuilder ####
`IExpressionBuilder` provides generic methods used for building query expressions dynamically.

[Details](\DataModel\Expressions\IExpressionBuilder.cs)

#### IQueryParameter ####
`IQueryParameter` represents part of a search expression used to construct a valid left-hand side of an equation.

[Details](\DataModel\Expressions\IQueryParameter.cs)

#### ISearchableMemberMetadata ####
`ISearchableMemberMetadata` represents a class member that is supported for building search expressions dynamically.

[Details](\DataModel\Expressions\ISearchableMemberMetadata.cs)

###