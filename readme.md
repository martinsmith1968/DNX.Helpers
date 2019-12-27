# DNX.Helpers

Built by [Travis CI](https://travis-ci.org/) ![Build Status](https://travis-ci.org/martinsmith1968/DNX.Helpers.svg?branch=master)

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

### Acknowledgements

With grateful thanks to all the people and organisations below, who've contributed something to either
make the development of this easier, or generally contributed to making [Visual Studio](https://visualstudio.microsoft.com/) an awesome environment:

| Title | Description |
|---|----|
| [Resharper Ultimate](https://www.jetbrains.com/resharper) | The guys at [JetBrains](https://www.jetbrains.com) make awesome tools for whatever your development language of preference. Visual Studio would not be complete without Resharper Ultimate |
| [Travis CI](https://travis-ci.org) | A cloud Continuous Integration environment that's easy to integrate with and is still as feature rich as you could need. Your builds have caught my lack of cross-platform awareness more than once |
| [GhostDoc Pro](https://submain.com/download/ghostdoc/pro/) | Good intellisense is key to almost any library and GhostDoc generates sensible documentation at the touch of a button. A community edition is also available for free |
| [BuildVision](https://github.com/StefanKert/BuildVision) | For multi-project solutions, this is the __best__ build visualizer. Can't wait for a VS 2019 version |
| [VSColorOutput](https://github.com/mike-ward/VSColorOutput) | Bring colour to your output window. Don't forget to donate... |
| [Automatic Versions](https://www.precisioninfinity.com/software-development-productivity-improvement/business-software-tools/automatic-versions-extension-for-visual-studio/) | A recent addition to my toolset, this is awesome at controlling my versioning for releases |
| [Mads Kristensen](https://marketplace.visualstudio.com/publishers/MadsKristensen) | Last but by no means least, a huge thank you to Mads at Microsoft for some brilliant time saving tools that make Visual Studio just that little bit more brilliant (E.g. [Markdown Editor](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor), [Add New File](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.AddNewFile), [Task Runner Explorer](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.TaskRunnerExplorer) |
| [Microsoft DevLabs](https://marketplace.visualstudio.com/publishers/Microsoft%20DevLabs) | Not sure why some of these aren't part of Visual Studio from the start but kudos to Microsoft for releasing them. Some excellent productivity enhancers here (E.g. [Fix Mixed Tabs](https://marketplace.visualstudio.com/items?itemName=VisualStudioPlatformTeam.FixMixedTabs), [Align Assignments](https://marketplace.visualstudio.com/items?itemName=VisualStudioPlatformTeam.AlignAssignments) |
