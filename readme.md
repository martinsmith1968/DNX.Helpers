# DNX.Helpers

![DNX Solutions Logo](images/favicon-32x32.png)
[DNX.Helpers](http://github.com/martinsmith1968/DNX.Helpers) is a .NET package that contains the bits that I've found lacking or missing from the .NET standard library. It has minimal dependencies on other packages and so is designed to be included to your projects with little or no disruption.

It is designed around the premise that code should be as readable as possible at the highest level possible.

E.g. Replaces code that would normally look something like:
```csharp
var escapedCode = string.Format("{0}{1}{2}",
    code != null && code.StartsWith("[") ? null : "[",
    code,
    code != null && code.EndsWith("]") ? null : "]"
    );
```

with

```csharp
var escapedCode = code.EnsureStartsAndEndsWith("[", "]");
```

### Installation

From NuGet package explorer:

`Install-Package DNX.Helpers`

### Contents

Helpers are divided into the following namespaces:

| Namespace | Descripion |
| --- | --- |
| [Assemblies](docs/Assemblies.md) | Classes for interrogating Assemblies in a easier way |
| [Comparisons](docs/Comparisons.md) | Make working with or implementing an IComparer much simpler |
| [Converters](docs/Converters.md) | Simplify converting textual data to the built in types |
| [Dates](docs/Dates.md) | Simplify working with Dates, especially when UTC or not is a consideration |
| [Enumerations](docs/Enumerations.md) | The `enum` parsing and manipulation functionality that .NET forgot |
| [Exceptions](docs/Exceptions.md) | The custom exceptions that can get thrown by these functions |
| [Interfaces](docs/Interfaces.md) | Common useful interfaces that promote conformity |
| [Linq](docs/Linq.md) | Some useful extension methods and classes for working with enumerables |
| [Maths](docs/Maths.md) | Some useful extension methods for math comparisons across the built in types |
| [Objects](docs/Objects.md) | Some extension methods that apply to any object |
| [Reflection](docs/Reflection.md) | Makes querying your own code at runtime so much simpler |
| [Streams](docs/Streams.md) | Some useful helpers for working with streams without having to remember how to setup readers, etc |
| [Strings](docs/Strings.md) | Extensions to the `string` class to simplify working with textual data |
| [Threading](docs/Threading.md) | Helper methods for working with asynchronous code. Includes a Mutex manager and a Pub/Sub queue |
| [Validation](docs/Validation.md) | Guard classes and methods to simplify argument validation |

Also, check out the [Unit Test](Test.DNX.Helpers) project for some usage examples.

### Reference

[Full Namespace reference](reference/reference.md)

### To Do

[To Do](todo.md)

### Contributing

Contributions welcome. All code must be comprehensively covered by unit tests using [NUnit 3](http://www.nunit.org)

### Credits

By Martin Smith, 2001 onwards

### Licence

[Licence](licence.txt)

### Related Projects

| Project | Location |
| --- | --- |
| [DNX.Helpers](http://github.com/martinsmith1968/DNX.Helpers) | General purpose .NET standard library helpers |
| [DNX.Helpers.Console](http://github.com/martinsmith1968/DNX.Helpers.Console) | For working with console applications |
| [DNX.Helpers.CommandLine](http://github.com/martinsmith1968/DNX.Helpers.CommandLine) | For working with Command Line parsing |
| [DNX.Helpers.Log4Net](http://github.com/martinsmith1968/DNX.Helpers.Log4Net) | For working with Log4Net |
