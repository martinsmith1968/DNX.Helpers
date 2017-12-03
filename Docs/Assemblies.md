# DNX.Helpers.Assemblies

## IAssemblyDetails interface

Provides information about an Assembly in a consolidated and easily accessible properties.

| Property | Type | Description |
| --- | --- | --- |
| AssemblyName | `AssemblyName` | Access the underlying `AssemblyName` directly. (Assembly.GetName()) |
| Name | string | The Name of the assembly (AssemblyName.Name) |
| Location | string | The location (full file path) of where the assembly exists |
| FileName | string | The filename and extension of the Assembly location |
| Title | string | The `Title` property from the `AssemblyTitleAttribute` attribute, or null if not present |
| Product | string | The `Product` property from the `AssemblyProductAttribute` attribute, or null if not present |
| Copyright | string | The `Copyright` property from the `AssemblyCopyrightAttribute` attribute, or null if not present |
| Company | string | The `Company` property from the `AssemblyCompanyAttribute` attribute, or null if not present |
| Description | string | The `Description` property from the `AssemblyDescriptionAttribute` attribute, or null if not present |
| Trademark | string | The `Trademark` property from the `AssemblyTrademarkAttribute` attribute, or null if not present |
| Configuration | string | The `Configuration` property from the `AssemblyConfigurationAttribute` attribute, or null if not present |
| FileVersion | string | The `Version` property from the `AssemblyVersionAttribute` attribute, or null if not present |
| InformationalVersion | string | The `InformationalVersion` property from the `AssemblyInformationalVersionAttribute` attribute, or null if not present |
| Version | `Version` | The `Version` property from the `AssemblyName` |
| SimplifiedVersion | string | The `Version` property above, with non-significant 0's removed from the right hand side |

## AssemblyDetails class

Implementation of `IAssemblyDetails`

Static methods

| Method Name | Parameters | Description |
| --- | --- | --- |
| ForAssembly | `Assembly` | Returns an `IAssemblyDetails` for the specified Assembly |
| ForMe |  | Returns an `IAssemblyDetails` for the currently executing assembly |
| ForEntryPoint | `Assembly` | Returns an `IAssemblyDetails` for the entry point Assembly |
| ForAssemblyContaining | `Type` | Returns an `IAssemblyDetails` for the Assembly that the `Type` is in |
| ForAssemblyContaining<T> | `Assembly` | Returns an `IAssemblyDetails` for the Assembly that the `Type` `T` is in |

## AssemblyExtensions

Extend an `Assembly` reference

| Method Name | Parameters | Description |
| --- | --- | --- |
| GetAssemblyDetails | | Enables an IAssemblyDetails to be constructed and returned from an existing `Assembly` reference |

Examples:

```csharp
// GetAssemblyDetails
var details = Assembly.GetExecutingAssembly().GetAssemblyDetails();
var title = details.Title;  // "My Assembly"
```

## VersionExtensions

Extend a `Version` reference

| Method Name | Parameters | Description |
| --- | --- | --- |
| Simplify | minimumPositions (Default: 1) | Reduce a `Version` string to only the significant values, honouring the minimum required positions |

Examples:

```csharp
// Simplify
var version1 = new Version(1, 0, 0, 0);
var v1 = version1.Simplify();     // 1
var v2 = version1.Simplify(2);    // 1.0

var version2 = new Version(1, 2, 3, 0);
var v1 = version2.Simplify();     // 1.2.3
var v2 = version2.Simplify(2);    // 1.2.3

```
