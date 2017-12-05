
# DNX.Helpers


## Assemblies.AssemblyDetails

Implementation for obtaining Assembly Attributes


### M:DNX.Helpers.#ctor

Initializes a new instance of the class.


### M:DNX.Helpers.#ctor(assembly)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| assembly | *System.Reflection.Assembly*<br>The assembly. |

### P:DNX.Helpers.Assembly

Internal Assembly field


### P:DNX.Helpers.AssemblyName

Gets the AssemblyName


### P:DNX.Helpers.Company

Gets the company attribute value.


### P:DNX.Helpers.Configuration

Gets the configuration attribute value.


### P:DNX.Helpers.Copyright

Gets the copyright attribute value.


### P:DNX.Helpers.Description

Gets the description attribute value.


### P:DNX.Helpers.FileName

Gets the file name of the assembly.


### P:DNX.Helpers.FileVersion

Gets the file version attribute value.


### M:DNX.Helpers.ForAssembly(assembly)

Creates an AssemblyDetails from the specified assembly.

| Name | Description |
| ---- | ----------- |
| assembly | *System.Reflection.Assembly*<br>The assembly. |


#### Returns

IAssemblyDetails.


### M:DNX.Helpers.ForAssemblyContaining(type)

Creates an AssemblyDetails fors the assembly containing the specified Type

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br>The type. |


#### Returns

IAssemblyDetails.


### M:DNX.Helpers.ForAssemblyContaining``1

Creates an AssemblyDetails fors the assembly containing the specified Type


#### Returns

IAssemblyDetails.


### M:DNX.Helpers.ForEntryPoint

Creates an AssemblyDetails for the entry point assembly.


#### Returns

IAssemblyDetails.


### M:DNX.Helpers.ForMe

Creates an AssemblyDetails for the calling assembly


#### Returns

IAssemblyDetails.


### M:DNX.Helpers.GetValue``1(System.Func{``0,System.String})

Returns the value of attribute T or String.Empty if no value is available.

| Name | Description |
| ---- | ----------- |
| getValue | *Unknown type*<br>The get value. |


#### Returns

The result of the specified Func, executed on the found attribute, if any. null if not matching attribute can be found


### P:DNX.Helpers.InformationalVersion

Gets the informational version attribute value.


### P:DNX.Helpers.Location

Gets the location of the assembly.


### P:DNX.Helpers.Name

Gets the name of the assembly.


### P:DNX.Helpers.Product

Gets the product attribute value.


### P:DNX.Helpers.SimplifiedVersion

Gets or sets the simplified version.


### P:DNX.Helpers.Title

Gets the title attribute value.


### P:DNX.Helpers.Trademark

Gets the trademark attribute value.


### P:DNX.Helpers.Version

Gets the assembly version.


## T:DNX.Helpers.Assemblies.AssemblyExtensions

Class AssemblyExtensions.


### M:DNX.Helpers.Assemblies.AssemblyExtensions.GetAssemblyDetails(assembly)

Gets the assembly details.

| Name | Description |
| ---- | ----------- |
| assembly | *System.Reflection.Assembly*<br>The assembly. |


#### Returns

IAssemblyDetails.


## T:DNX.Helpers.Assemblies.IAssemblyDetails

Interface IAssemblyDetail


### P:DNX.Helpers.Assemblies.IAssemblyDetails.AssemblyName

Gets the AssemblyName


### P:DNX.Helpers.Assemblies.IAssemblyDetails.Company

Gets the company attribute value.


### P:DNX.Helpers.Assemblies.IAssemblyDetails.Configuration

Gets the configuration attribute value.


### P:DNX.Helpers.Assemblies.IAssemblyDetails.Copyright

Gets the copyright attribute value.


### P:DNX.Helpers.Assemblies.IAssemblyDetails.Description

Gets the description attribute value.


### P:DNX.Helpers.Assemblies.IAssemblyDetails.FileName

Gets the file name of the assembly.


### P:DNX.Helpers.Assemblies.IAssemblyDetails.FileVersion

Gets the file version attribute value.


### P:DNX.Helpers.Assemblies.IAssemblyDetails.InformationalVersion

Gets the informational version attribute value.


### P:DNX.Helpers.Assemblies.IAssemblyDetails.Location

Gets the location of the assembly.


### P:DNX.Helpers.Assemblies.IAssemblyDetails.Name

Gets the name of the assembly.


### P:DNX.Helpers.Assemblies.IAssemblyDetails.Product

Gets the product attribute value.


### P:DNX.Helpers.Assemblies.IAssemblyDetails.SimplifiedVersion

Gets the simplified version.


### P:DNX.Helpers.Assemblies.IAssemblyDetails.Title

Gets the title attribute value.


### P:DNX.Helpers.Assemblies.IAssemblyDetails.Trademark

Gets the trademark attribute value.


### P:DNX.Helpers.Assemblies.IAssemblyDetails.Version

Gets the assembly version.


## T:DNX.Helpers.Assemblies.VersionExtensions

Class VersionExtensions.


### M:DNX.Helpers.Assemblies.VersionExtensions.Simplify(version, minimumPositions)

Simplifies the Version to the specified minimum positions

| Name | Description |
| ---- | ----------- |
| version | *System.Version*<br>The version. |
| minimumPositions | *System.Int32*<br>The minimum positions. |


#### Returns

System.String.


## T:DNX.Helpers.Comparisons.ComparerFunc`1

Class ComparerFunc.


### M:DNX.Helpers.Comparisons.ComparerFunc`1.Compare(x, y)

Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.

| Name | Description |
| ---- | ----------- |
| x | *`0*<br>The first object to compare. |
| y | *`0*<br>The second object to compare. |


#### Returns

A signed integer that indicates the relative values of and , as shown in the following table.Value Meaning Less than zero is less than .Zero equals .Greater than zero is greater than .


### M:DNX.Helpers.Comparisons.ComparerFunc`1.Create(System.Func{`0,`0,System.Int32})

Creates a comparer for the specified type

| Name | Description |
| ---- | ----------- |
| func | *Unknown type*<br>The function. |


#### Returns

ActionComparer<T>.


## T:DNX.Helpers.Comparisons.EqualityComparerFunc`1

Class EqualityComparerFunc.


### M:DNX.Helpers.Comparisons.EqualityComparerFunc`1.Create(System.Func{`0,`0,System.Boolean})

Creates a comparer for the specified type

| Name | Description |
| ---- | ----------- |
| func | *Unknown type*<br>The function. |


#### Returns

ActionEqualityComparer<T>.


### M:DNX.Helpers.Comparisons.EqualityComparerFunc`1.Equals(x, y)

Determines whether the specified objects are equal.

| Name | Description |
| ---- | ----------- |
| x | *`0*<br>The first object to compare. |
| y | *`0*<br>The second object to compare. |


#### Returns

true if the specified objects are equal; otherwise, false.


### M:DNX.Helpers.Comparisons.EqualityComparerFunc`1.GetHashCode(obj)

Returns a hash code for this instance.

| Name | Description |
| ---- | ----------- |
| obj | *`0*<br>The for which a hash code is to be returned. |


#### Returns

A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertBoolExtensions

Class ConvertBoolExtensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertBoolExtensions.IsBool(text)

Determines if the string can be converted to a bool or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a bool; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertBoolExtensions.ToBool(text)

Converts the string to a bool

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

bool

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertBoolExtensions.ToBool(text, defaultValue)

Converts the string to a bool, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.Boolean*<br>The default value. |


#### Returns

bool


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertByteExtensions

Class ConvertByteExtensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertByteExtensions.IsByte(text)

Determines if the string can be converted to a byte or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a byte; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertByteExtensions.ToByte(text)

Converts the string to a byte

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

byte

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertByteExtensions.ToByte(text, defaultValue)

Converts the string to a byte, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.Byte*<br>The default value. |


#### Returns

byte


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertDateTimeExtensions

Class ConvertDateTimeExtensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertDateTimeExtensions.IsDateTime(text)

Determines if the string can be converted to a DateTime or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a DateTime; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertDateTimeExtensions.ToDateTime(text)

Converts the string to a DateTime

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

DateTime

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertDateTimeExtensions.ToDateTime(text, defaultValue)

Converts the string to a DateTime, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.DateTime*<br>The default value. |


#### Returns

DateTime


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertDecimalExtensions

Class ConvertDecimalExtensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertDecimalExtensions.IsDecimal(text)

Determines if the string can be converted to a decimal or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a decimal; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertDecimalExtensions.ToDecimal(text)

Converts the string to a decimal

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

decimal

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertDecimalExtensions.ToDecimal(text, defaultValue)

Converts the string to a decimal, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.Decimal*<br>The default value. |


#### Returns

decimal


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertDoubleExtensions

Class ConvertDoubleExtensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertDoubleExtensions.IsDouble(text)

Determines if the string can be converted to a double or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a double; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertDoubleExtensions.ToDouble(text)

Converts the string to a double

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

double

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertDoubleExtensions.ToDouble(text, defaultValue)

Converts the string to a double, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.Double*<br>The default value. |


#### Returns

double


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertFloatExtensions

Class ConvertFloatExtensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertFloatExtensions.IsFloat(text)

Determines if the string can be converted to a float or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a float; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertFloatExtensions.ToFloat(text)

Converts the string to a float

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

float

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertFloatExtensions.ToFloat(text, defaultValue)

Converts the string to a float, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.Single*<br>The default value. |


#### Returns

float


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertInt16Extensions

Class ConvertInt16Extensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertInt16Extensions.IsInt16(text)

Determines if the string can be converted to a short or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a short; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertInt16Extensions.ToInt16(text)

Converts the string to a short

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

short

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertInt16Extensions.ToInt16(text, defaultValue)

Converts the string to a short, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.Int16*<br>The default value. |


#### Returns

short


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertInt32Extensions

Class ConvertInt32Extensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertInt32Extensions.IsInt32(text)

Determines if the string can be converted to a int or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a int; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertInt32Extensions.ToInt32(text)

Converts the string to a int

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

int

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertInt32Extensions.ToInt32(text, defaultValue)

Converts the string to a int, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.Int32*<br>The default value. |


#### Returns

int


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertInt64Extensions

Class ConvertInt64Extensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertInt64Extensions.IsInt64(text)

Determines if the string can be converted to a long or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a long; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertInt64Extensions.ToInt64(text)

Converts the string to a long

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

long

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertInt64Extensions.ToInt64(text, defaultValue)

Converts the string to a long, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.Int64*<br>The default value. |


#### Returns

long


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertIntExtensions

Class ConvertIntExtensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertIntExtensions.IsInt(text)

Determines if the string can be converted to a int or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a int; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertIntExtensions.ToInt(text)

Converts the string to a int

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

int

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertIntExtensions.ToInt(text, defaultValue)

Converts the string to a int, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.Int32*<br>The default value. |


#### Returns

int


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertLongExtensions

Class ConvertLongExtensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertLongExtensions.IsLong(text)

Determines if the string can be converted to a long or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a long; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertLongExtensions.ToLong(text)

Converts the string to a long

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

long

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertLongExtensions.ToLong(text, defaultValue)

Converts the string to a long, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.Int64*<br>The default value. |


#### Returns

long


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertSByteExtensions

Class ConvertSByteExtensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertSByteExtensions.IsSByte(text)

Determines if the string can be converted to a sbyte or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a sbyte; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertSByteExtensions.ToSByte(text)

Converts the string to a sbyte

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

sbyte

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertSByteExtensions.ToSByte(text, defaultValue)

Converts the string to a sbyte, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.SByte*<br>The default value. |


#### Returns

sbyte


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertShortExtensions

Class ConvertShortExtensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertShortExtensions.IsShort(text)

Determines if the string can be converted to a short or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a short; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertShortExtensions.ToShort(text)

Converts the string to a short

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

short

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertShortExtensions.ToShort(text, defaultValue)

Converts the string to a short, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.Int16*<br>The default value. |


#### Returns

short


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertSingleExtensions

Class ConvertSingleExtensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertSingleExtensions.IsSingle(text)

Determines if the string can be converted to a float or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a float; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertSingleExtensions.ToSingle(text)

Converts the string to a float

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

float

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertSingleExtensions.ToSingle(text, defaultValue)

Converts the string to a float, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.Single*<br>The default value. |


#### Returns

float


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertUInt16Extensions

Class ConvertUInt16Extensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertUInt16Extensions.IsUInt16(text)

Determines if the string can be converted to a ushort or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a ushort; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertUInt16Extensions.ToUInt16(text)

Converts the string to a ushort

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

ushort

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertUInt16Extensions.ToUInt16(text, defaultValue)

Converts the string to a ushort, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.UInt16*<br>The default value. |


#### Returns

ushort


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertUInt32Extensions

Class ConvertUInt32Extensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertUInt32Extensions.IsUInt32(text)

Determines if the string can be converted to a uint or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a uint; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertUInt32Extensions.ToUInt32(text)

Converts the string to a uint

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

uint

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertUInt32Extensions.ToUInt32(text, defaultValue)

Converts the string to a uint, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.UInt32*<br>The default value. |


#### Returns

uint


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertUInt64Extensions

Class ConvertUInt64Extensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertUInt64Extensions.IsUInt64(text)

Determines if the string can be converted to a ulong or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a ulong; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertUInt64Extensions.ToUInt64(text)

Converts the string to a ulong

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

ulong

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertUInt64Extensions.ToUInt64(text, defaultValue)

Converts the string to a ulong, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.UInt64*<br>The default value. |


#### Returns

ulong


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertUIntExtensions

Class ConvertUIntExtensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertUIntExtensions.IsUInt(text)

Determines if the string can be converted to a uint or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a uint; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertUIntExtensions.ToUInt(text)

Converts the string to a uint

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

uint

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertUIntExtensions.ToUInt(text, defaultValue)

Converts the string to a uint, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.UInt32*<br>The default value. |


#### Returns

uint


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertULongExtensions

Class ConvertULongExtensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertULongExtensions.IsULong(text)

Determines if the string can be converted to a ulong or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a ulong; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertULongExtensions.ToULong(text)

Converts the string to a ulong

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

ulong

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertULongExtensions.ToULong(text, defaultValue)

Converts the string to a ulong, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.UInt64*<br>The default value. |


#### Returns

ulong


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.BuiltInTypes.ConvertUShortExtensions

Class ConvertUShortExtensions


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertUShortExtensions.IsUShort(text)

Determines if the string can be converted to a ushort or not

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified text is a ushort; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertUShortExtensions.ToUShort(text)

Converts the string to a ushort

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

ushort

*DNX.Helpers.Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Converters.BuiltInTypes.ConvertUShortExtensions.ToUShort(text, defaultValue)

Converts the string to a ushort, or returns the default value if the conversion fails

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| defaultValue | *System.UInt16*<br>The default value. |


#### Returns

ushort


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Converters.ConvertExtensions

Conversion Extensions.


### M:DNX.Helpers.Converters.ConvertExtensions.ChangeType``1(value)

Changes the value to the specified type

| Name | Description |
| ---- | ----------- |
| value | *System.Object*<br>The value. |


#### Returns

T.


### M:DNX.Helpers.Converters.ConvertExtensions.ChangeType``1(value, defaultValue)

Changes the value to the specified type, with a default value if conversion fails

| Name | Description |
| ---- | ----------- |
| value | *System.Object*<br>The value. |
| defaultValue | *``0*<br>The default value. |


#### Returns

T.


## T:DNX.Helpers.Converters.ConvertObjectExtensions

Conversion Extensions.


### M:DNX.Helpers.Converters.ConvertObjectExtensions.ToStringOrDefault(obj, defaultValue)

Returns the obj.ToString() or Empty if null

| Name | Description |
| ---- | ----------- |
| obj | *System.Object*<br>The object. |
| defaultValue | *System.String*<br>The default value. |


#### Returns

System.String.


### M:DNX.Helpers.Converters.ConvertObjectExtensions.ToStringOrEmpty(obj)

Returns the obj.ToString() or Empty if null

| Name | Description |
| ---- | ----------- |
| obj | *System.Object*<br>The object. |


#### Returns

System.String.


### M:DNX.Helpers.Converters.ConvertObjectExtensions.ToStringOrNull(obj)

Returns the obj.ToString() or null if null

| Name | Description |
| ---- | ----------- |
| obj | *System.Object*<br>The object. |


#### Returns

System.String.


## T:DNX.Helpers.Dates.DateTimeExtensions

DateTime Extensions.


### M:DNX.Helpers.Dates.DateTimeExtensions.ParseDateAsUtc(dateString)

Parses the date as UTC.

| Name | Description |
| ---- | ----------- |
| dateString | *System.String*<br>The date string. |


#### Returns

DateTime.


### M:DNX.Helpers.Dates.DateTimeExtensions.ParseDateAsUtc(dateString, defaultDateTime)

Parses the date as UTC.

| Name | Description |
| ---- | ----------- |
| dateString | *System.String*<br>The date string. |
| defaultDateTime | *System.DateTime*<br>The default date time. |


#### Returns

DateTime.


### M:DNX.Helpers.Dates.DateTimeExtensions.ParseDateAsUtc(dateString, formatProvider)

Parses the date as UTC.

| Name | Description |
| ---- | ----------- |
| dateString | *System.String*<br>The date string. |
| formatProvider | *System.IFormatProvider*<br>The format provider. |


#### Returns

DateTime.


### M:DNX.Helpers.Dates.DateTimeExtensions.ParseDateAsUtc(dateString, formatProvider, defaultDateTime)

Parses the date as UTC.

| Name | Description |
| ---- | ----------- |
| dateString | *System.String*<br>The date string. |
| formatProvider | *System.IFormatProvider*<br>The format provider. |
| defaultDateTime | *System.DateTime*<br>The default date time. |


#### Returns

System.DateTime.


### P:DNX.Helpers.Dates.DateTimeExtensions.UnixEpoch

Gets the unix epoch.


## T:DNX.Helpers.Enumerations.EnumExtensions

Enum Extensions.


### M:DNX.Helpers.Enumerations.EnumExtensions.GetDescription(value)

Gets the description.

| Name | Description |
| ---- | ----------- |
| value | *System.Enum*<br>The value. |


#### Returns

System.String.


### M:DNX.Helpers.Enumerations.EnumExtensions.GetMaxValue``1

Gets the max enum value.


#### Returns

T.

*DNX.Helpers.Exceptions.EnumTypeException:* 


### M:DNX.Helpers.Enumerations.EnumExtensions.GetMinValue``1

Gets the min enum value.


#### Returns

T.

*DNX.Helpers.Exceptions.EnumTypeException:* 


### M:DNX.Helpers.Enumerations.EnumExtensions.GetSetValuesList``1(enumValue)

Gets the set values list.

| Name | Description |
| ---- | ----------- |
| enumValue | *System.Enum*<br>The enum value. |


#### Returns

List<T>.

*DNX.Helpers.Exceptions.EnumTypeException:* 


### M:DNX.Helpers.Enumerations.EnumExtensions.IsValidEnum(value, type, ignoreCase)

Determines whether the text is a valid enum value of the specified enum type

| Name | Description |
| ---- | ----------- |
| value | *System.String*<br>The value. |
| type | *System.Type*<br>The type. |
| ignoreCase | *System.Boolean*<br>if set to true [ignore case]. |


#### Returns

true if [is valid enum] [the specified type]; otherwise, false.

*System.ArgumentNullException:* type

*DNX.Helpers.Exceptions.EnumTypeException:* 


### M:DNX.Helpers.Enumerations.EnumExtensions.IsValidEnum``1(value)

Determines whether the specified enum value is a valid enum name.

| Name | Description |
| ---- | ----------- |
| value | *``0*<br>The enum value. |


#### Returns

true if the specified value is valid; otherwise, false.


### M:DNX.Helpers.Enumerations.EnumExtensions.IsValidEnum``1(value)

Determines whether the specified enum value is a valid enum name.

| Name | Description |
| ---- | ----------- |
| value | *System.String*<br>The enum Name. |


#### Returns

true if the specified value is valid; otherwise, false.


### M:DNX.Helpers.Enumerations.EnumExtensions.IsValidEnum``1(value, ignoreCase)

Determines whether the specified enum value is a valid enum name.

| Name | Description |
| ---- | ----------- |
| value | *System.String*<br>The value. |
| ignoreCase | *System.Boolean*<br>if set to true [ignore case]. |


#### Returns

true if [is valid enum] [the specified ignore case]; otherwise, false.


### M:DNX.Helpers.Enumerations.EnumExtensions.IsValueOneOf``1(value, allowed)

Determines whether [is value one of] [the specified args].

| Name | Description |
| ---- | ----------- |
| value | *``0*<br>The value. |
| allowed | *``0[]*<br>The allowed. |


#### Returns

true if [is value one of] [the specified args]; otherwise, false.


### M:DNX.Helpers.Enumerations.EnumExtensions.IsValueOneOf``1(value, allowed)

Determines whether [is value one of] [the specified args].

| Name | Description |
| ---- | ----------- |
| value | *``0*<br>The value. |
| allowed | *System.Collections.Generic.IList{``0}*<br>The allowed. |


#### Returns

true if [is value one of] [the specified args]; otherwise, false.

*DNX.Helpers.Exceptions.EnumTypeException:* 


### M:DNX.Helpers.Enumerations.EnumExtensions.ManipulateFlag``1(value, flag, set)

Sets the flag.

| Name | Description |
| ---- | ----------- |
| value | *System.Enum*<br>The value. |
| flag | *``0*<br>The flag. |
| set | *System.Boolean*<br>if set to true [set]. |


#### Returns

T.


### M:DNX.Helpers.Enumerations.EnumExtensions.ParseEnum``1(item)

Translate a given string to an enumeration value. May throw a translation exception

| Name | Description |
| ---- | ----------- |
| item | *System.String*<br>The string representation of an enum value of T |


#### Returns

The result


### M:DNX.Helpers.Enumerations.EnumExtensions.ParseEnum``1(item, ignoreCase)

Translate a given string to an enumeration value. May throw a translation exception

| Name | Description |
| ---- | ----------- |
| item | *System.String*<br>The string representation of an enum value of T |
| ignoreCase | *System.Boolean*<br>if set to true ignore the case of item. |


#### Returns

The result

*DNX.Helpers.Exceptions.EnumTypeException:* 


### M:DNX.Helpers.Enumerations.EnumExtensions.ParseEnumOrDefault``1(item, defaultValue)

Attempt to safely translate a string to an enumeration value. If translation is not possible return a default value

| Name | Description |
| ---- | ----------- |
| item | *System.String*<br>The string representation of an enum value of T |
| defaultValue | *``0*<br>The default value to return if translation cannot complete |


#### Returns

T.

*DNX.Helpers.Exceptions.EnumTypeException:* 


### M:DNX.Helpers.Enumerations.EnumExtensions.ParseEnumOrDefault``1(item, ignoreCase, defaultValue)

Attempt to safely translate a string to an enumeration value. If translation is not possible return a default value

| Name | Description |
| ---- | ----------- |
| item | *System.String*<br>The string representation of an enum value of T |
| ignoreCase | *System.Boolean*<br>if set to true [ignore case]. |
| defaultValue | *``0*<br>The default value to return if translation cannot complete |


#### Returns

T.

*DNX.Helpers.Exceptions.EnumTypeException:* 


### M:DNX.Helpers.Enumerations.EnumExtensions.SetFlag``1(value, flag)

Sets the flag.

| Name | Description |
| ---- | ----------- |
| value | *System.Enum*<br>The value. |
| flag | *``0*<br>The flag. |


#### Returns

T.


### M:DNX.Helpers.Enumerations.EnumExtensions.ToDictionaryByName``1

Converts the entire enum to a dictionary with Name as the key


#### Returns

IDictionary<System.String, T>.

*DNX.Helpers.Exceptions.EnumTypeException:* 


### M:DNX.Helpers.Enumerations.EnumExtensions.ToDictionaryByValue``1

Converts the entire enum to a dictionary with Value as the key


#### Returns

IDictionary<T, System.String>.

*DNX.Helpers.Exceptions.EnumTypeException:* 


### M:DNX.Helpers.Enumerations.EnumExtensions.UnsetFlag``1(value, flag)

Unsets the flag.

| Name | Description |
| ---- | ----------- |
| value | *System.Enum*<br>The value. |
| flag | *``0*<br>The flag. |


#### Returns

T.


## T:DNX.Helpers.Exceptions.ConversionException

Conversion Exception.


#### Remarks

Thrown when a conversion to a specified type fails


### M:DNX.Helpers.Exceptions.ConversionException.#ctor(value, message)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| value | *System.String*<br>The value. |
| message | *System.String*<br>The message. |

### M:DNX.Helpers.Exceptions.ConversionException.#ctor(value, message, type)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| value | *System.String*<br>The value. |
| message | *System.String*<br>The message. |
| type | *System.Type*<br>The type. |

### P:DNX.Helpers.Exceptions.ConversionException.ConvertType

Gets the type of the convert.


### P:DNX.Helpers.Exceptions.ConversionException.Value

Gets the value.


## T:DNX.Helpers.Exceptions.EnumTypeException

EnumTypeException.


### M:DNX.Helpers.Exceptions.EnumTypeException.#ctor(type)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br>The type. |


#### Remarks

Uses the default message template


### M:DNX.Helpers.Exceptions.EnumTypeException.#ctor(type, messageTemplate)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br>The type. |
| messageTemplate | *System.String*<br>The message template. |

### F:DNX.Helpers.Exceptions.EnumTypeException.MessageTemplate

The message template


### P:DNX.Helpers.Exceptions.EnumTypeException.Type

The type the exception was thrown for


## T:DNX.Helpers.Exceptions.EnumValueException`1

Class EnumValueException.


### M:DNX.Helpers.Exceptions.EnumValueException`1.#ctor(value)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| value | *`0*<br>The value. |

### M:DNX.Helpers.Exceptions.EnumValueException`1.#ctor(value, messageTemplate)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| value | *`0*<br>The value. |
| messageTemplate | *System.String*<br>The message template. |

### F:DNX.Helpers.Exceptions.EnumValueException`1.MessageTemplate

The message template


### P:DNX.Helpers.Exceptions.EnumValueException`1.Type

Gets the type.


### P:DNX.Helpers.Exceptions.EnumValueException`1.Value

Gets the value.


## T:DNX.Helpers.Exceptions.ExceptionExtensions

Exception Extensions.


### M:DNX.Helpers.Exceptions.ExceptionExtensions.GetExceptionList(ex)

Gets the list of messages from an Exception and inner exceptions

| Name | Description |
| ---- | ----------- |
| ex | *System.Exception*<br>The ex. |


#### Returns

IList<System.String>.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Exceptions.ExceptionExtensions.GetMessageList(ex)

Gets the list of messages from an Exception and inner exceptions

| Name | Description |
| ---- | ----------- |
| ex | *System.Exception*<br>The ex. |


#### Returns

IList<System.String>.


#### Remarks

Also available as an extension method


## T:DNX.Helpers.Exceptions.ParameterException

An exception for idenifying issues with expected parameters


### M:DNX.Helpers.Exceptions.ParameterException.#ctor(paramName, paramValue, message)

Create a ParameterException with a parameter name and value, and a message

| Name | Description |
| ---- | ----------- |
| paramName | *System.String*<br>Name of the parameter. |
| paramValue | *System.Object*<br>The parameter value. |
| message | *System.String*<br>The message. |

### M:DNX.Helpers.Exceptions.ParameterException.#ctor(paramName, paramValue, message, innerException)

Create a ParameterException with a parameter name and value, message and inner Exception

| Name | Description |
| ---- | ----------- |
| paramName | *System.String*<br>Name of the parameter. |
| paramValue | *System.Object*<br>The parameter value. |
| message | *System.String*<br>The message. |
| innerException | *System.Exception*<br>The inner exception. |

### M:DNX.Helpers.Exceptions.ParameterException.#ctor(paramName, message)

Create a ParameterException with a parameter name and a message

| Name | Description |
| ---- | ----------- |
| paramName | *System.String*<br>Name of the parameter. |
| message | *System.String*<br>The message. |

### M:DNX.Helpers.Exceptions.ParameterException.#ctor(paramName, message, innerException)

Create a ParameterException with a parameter name, message and inner Exception

| Name | Description |
| ---- | ----------- |
| paramName | *System.String*<br>Name of the parameter. |
| message | *System.String*<br>The message. |
| innerException | *System.Exception*<br>The inner exception. |

### P:DNX.Helpers.Exceptions.ParameterException.ParamName

The Parameter Name


### P:DNX.Helpers.Exceptions.ParameterException.ParamValue

The value specified for the Parameter


## T:DNX.Helpers.Exceptions.ParameterInvalidException

An exception for idenifying an invalid value issue with expected parameters


### M:DNX.Helpers.Exceptions.ParameterInvalidException.#ctor(paramName, paramValue, message)

Create a ParameterInvalidException with a parameter name and value, and a message

| Name | Description |
| ---- | ----------- |
| paramName | *System.String*<br>Name of the parameter. |
| paramValue | *System.Object*<br>The parameter value. |
| message | *System.String*<br>The message. |

### M:DNX.Helpers.Exceptions.ParameterInvalidException.#ctor(paramName, paramValue, message, innerException)

Create a ParameterInvalidException with a parameter name and value, message and inner Exception

| Name | Description |
| ---- | ----------- |
| paramName | *System.String*<br>Name of the parameter. |
| paramValue | *System.Object*<br>The parameter value. |
| message | *System.String*<br>The message. |
| innerException | *System.Exception*<br>The inner exception. |

### M:DNX.Helpers.Exceptions.ParameterInvalidException.#ctor(paramName, message)

Create a ParameterInvalidException with a parameter name and a message

| Name | Description |
| ---- | ----------- |
| paramName | *System.String*<br>Name of the parameter. |
| message | *System.String*<br>The message. |

### M:DNX.Helpers.Exceptions.ParameterInvalidException.#ctor(paramName, message, innerException)

Create a ParameterInvalidException with a parameter name, message and inner Exception

| Name | Description |
| ---- | ----------- |
| paramName | *System.String*<br>Name of the parameter. |
| message | *System.String*<br>The message. |
| innerException | *System.Exception*<br>The inner exception. |

## T:DNX.Helpers.Exceptions.ReadOnlyListException`1

Class ReadOnlyListException.


### M:DNX.Helpers.Exceptions.ReadOnlyListException`1.#ctor(list)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| list | *System.Collections.Generic.IList{`0}*<br>The list. |

### P:DNX.Helpers.Exceptions.ReadOnlyListException`1.List

Gets the list.


## T:DNX.Helpers.Interfaces.IConverter`2

Converter Interface for transposing objects between 2 types


### M:DNX.Helpers.Interfaces.IConverter`2.Convert(source)

Converts the specified source.

| Name | Description |
| ---- | ----------- |
| source | *`0*<br>The source. |


#### Returns

T2.


## T:DNX.Helpers.Interfaces.IExtractable`1

Extractable Interface for populating another instance from this one


### M:DNX.Helpers.Interfaces.IExtractable`1.ExtractInto(target)

Extracts this object into another

| Name | Description |
| ---- | ----------- |
| target | *`0*<br>The target. |

## T:DNX.Helpers.Interfaces.IPopulatable`1

Populatable Interface for populating this object from another


### M:DNX.Helpers.Interfaces.IPopulatable`1.PopulateFrom(source)

Populates from an instance of T1

| Name | Description |
| ---- | ----------- |
| source | *`0*<br>The source. |

## T:DNX.Helpers.Linq.DictionaryExtensions

Dictionary Extensions.


### M:DNX.Helpers.Linq.DictionaryExtensions.GetValue``2(System.Collections.Generic.IDictionary{``0,``1},``0,``1)

Gets the value.

| Name | Description |
| ---- | ----------- |
| dictionary | *Unknown type*<br>The dictionary. |
| keyName | *Unknown type*<br>Name of the key. |
| defaultValue | *``0*<br>The default value. |


#### Returns

TV.

*System.ArgumentNullException:* dictionary or keyName


### M:DNX.Helpers.Linq.DictionaryExtensions.Merge``2(DNX.Helpers.Linq.MergeTechnique,System.Collections.Generic.IDictionary{``0,``1}[])

Merges dictionaries

| Name | Description |
| ---- | ----------- |
| mergeTechnique | *Unknown type*<br>The merge technique. |
| dictionaries | *Unknown type*<br>The dictionaries. |


#### Returns

Dictionary<TK, TV>.

*System.ArgumentException:* Invalid or unsupported Merge Technique - mergeTechnique


### M:DNX.Helpers.Linq.DictionaryExtensions.MergeFirst``2(System.Collections.Generic.IDictionary{``0,``1}[])

Merges dictionaries using the first found key value

| Name | Description |
| ---- | ----------- |
| dictionaries | *Unknown type*<br>The dictionaries. |


#### Returns

Dictionary<TK, TV>.


### M:DNX.Helpers.Linq.DictionaryExtensions.MergeLast``2(System.Collections.Generic.IDictionary{``0,``1}[])

Merges dictionaries using the last found key value

| Name | Description |
| ---- | ----------- |
| dictionaries | *Unknown type*<br>The dictionaries. |


#### Returns

Dictionary<TK, TV>.


### M:DNX.Helpers.Linq.DictionaryExtensions.MergeUnique``2(System.Collections.Generic.IDictionary{``0,``1}[])

Merges dictionaries assuming all keys are unique

| Name | Description |
| ---- | ----------- |
| dictionaries | *Unknown type*<br>The dictionaries. |


#### Returns

Dictionary<TK, TV>.


### M:DNX.Helpers.Linq.DictionaryExtensions.MergeWith``2(System.Collections.Generic.IDictionary{``0,``1},System.Collections.Generic.IDictionary{``0,``1},DNX.Helpers.Linq.MergeTechnique)

Merges the with.

| Name | Description |
| ---- | ----------- |
| dict | *Unknown type*<br>The dictionary. |
| other | *Unknown type*<br>The other. |
| mergeTechnique | *Unknown type*<br>The merge technique. |


#### Returns

Dictionary<TK, TV>.


#### Remarks

Source and target dictionaries are left untouched


### M:DNX.Helpers.Linq.DictionaryExtensions.RenameKey``1(System.Collections.Generic.IDictionary{System.String,``0},System.String,System.String)

Renames the key.

| Name | Description |
| ---- | ----------- |
| dictionary | *Unknown type*<br>The dictionary. |
| fromKeyName | *Unknown type*<br>Name of from key. |
| toKeyName | *Unknown type*<br>Name of to key. |

*System.ArgumentNullException:* fromKeyName or toKeyName


### M:DNX.Helpers.Linq.DictionaryExtensions.SetValue``2(System.Collections.Generic.IDictionary{``0,``1},``0,``1)

Sets the value.

| Name | Description |
| ---- | ----------- |
| dictionary | *Unknown type*<br>The dictionary. |
| keyName | *Unknown type*<br>Name of the key. |
| value | *`0*<br>The value. |

*System.ArgumentNullException:* dictionary or keyName


## T:DNX.Helpers.Linq.EnumerableExtensions

Class EnumerableExtensions.


### M:DNX.Helpers.Linq.EnumerableExtensions.ToConcreteList``1(enumerable)

Converts an Enumerable to a List or to an empty list if null

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{``0}*<br>The enumerable. |


#### Returns

IList<T>.


### M:DNX.Helpers.Linq.EnumerableExtensions.ToListOrNull``1(enumerable)

Converts an Enumerable to a List or null

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{``0}*<br>The enumerable. |


#### Returns

IList<T>.


## T:DNX.Helpers.Linq.ItemComparison`2

ItemComparison result for logical comparison of 2 objects.


### M:DNX.Helpers.Linq.ItemComparison`2.#ctor(source, target)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| source | *`0*<br>The source. |
| target | *`1*<br>The target. |

### M:DNX.Helpers.Linq.ItemComparison`2.Create(item1, item2)

Creates an ItemComparison

| Name | Description |
| ---- | ----------- |
| item1 | *`0*<br>The item1. |
| item2 | *`1*<br>The item2. |


#### Returns

ItemComparison<T1, T2>.


### P:DNX.Helpers.Linq.ItemComparison`2.Matched

Gets a value indicating whether this is matched.


### P:DNX.Helpers.Linq.ItemComparison`2.Source

Gets the source.


### P:DNX.Helpers.Linq.ItemComparison`2.SourceOnly

Gets a value indicating whether [source only].


### P:DNX.Helpers.Linq.ItemComparison`2.Target

Gets the target.


### P:DNX.Helpers.Linq.ItemComparison`2.TargetOnly

Gets a value indicating whether [target only].


## T:DNX.Helpers.Linq.ItemComparisonList

Class ItemComparisonList.


### M:DNX.Helpers.Linq.ItemComparisonList.Create``1(System.Collections.Generic.IList{``0},System.Collections.Generic.IList{``0},System.Func{``0,``0,System.Boolean})

Creates the specified source list.

| Name | Description |
| ---- | ----------- |
| sourceList | *Unknown type*<br>The source list. |
| targetList | *Unknown type*<br>The target list. |
| matchFunc | *Unknown type*<br>The match function. |


#### Returns

IList<ItemComparison<T, T>>.


### M:DNX.Helpers.Linq.ItemComparisonList.Create``2(System.Collections.Generic.IList{``0},System.Collections.Generic.IList{``1},System.Func{``0,``1,System.Boolean})

Creates the specified source list.

| Name | Description |
| ---- | ----------- |
| sourceList | *Unknown type*<br>The source list. |
| targetList | *Unknown type*<br>The target list. |
| matchFunc | *Unknown type*<br>The match function. |


#### Returns

IList<ItemComparison<T1, T2>>.


## T:DNX.Helpers.Linq.LinqExtensions

Linq Extensions.


### M:DNX.Helpers.Linq.LinqExtensions.HasAny``1(enumerable)

Determines whether the specified enumerable has any elements and is not null

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{``0}*<br>The enumerable. |


#### Returns

true if the specified enumerable has any elements; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Linq.LinqExtensions.HasAny``1(System.Collections.Generic.IEnumerable{``0},System.Func{``0,System.Boolean})

Determines whether the specified enumerable has any elements that match the predicate and is not null

| Name | Description |
| ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{``0}*<br>The enumerable. |
| predicate | *Unknown type*<br>The predicate. |


#### Returns

true if the specified predicate has any elements that match the predicate; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Linq.LinqExtensions.IsIn``1(value, list)

Determines whether the specified value is in the list.

| Name | Description |
| ---- | ----------- |
| value | *``0*<br>The value. |
| list | *``0[]*<br>The list. |


#### Returns

true if the list is not null and value is in the list; otherwise, false.


### M:DNX.Helpers.Linq.LinqExtensions.IsIn``1(value, list, comparer, treatNullListAs)

Determines whether the specified value is in the list.

| Name | Description |
| ---- | ----------- |
| value | *``0*<br>The value. |
| list | *System.Collections.Generic.IList{``0}*<br>The list. |
| comparer | *System.Collections.Generic.IEqualityComparer{``0}*<br>The comparer. |
| treatNullListAs | *System.Boolean*<br>The value to return if the list is null |


#### Returns

true if the value is in the list; otherwise, false.


### M:DNX.Helpers.Linq.LinqExtensions.IsNotIn``1(value, list)

Determines whether the specified value is not in the list.

| Name | Description |
| ---- | ----------- |
| value | *``0*<br>The value. |
| list | *``0[]*<br>The list. |


#### Returns

true if the list is not null and value is not in the list; otherwise, false.


### M:DNX.Helpers.Linq.LinqExtensions.IsNotIn``1(value, list, comparer, treatNullListAs)

Determines whether the specified value is not in the list.

| Name | Description |
| ---- | ----------- |
| value | *``0*<br>The value. |
| list | *System.Collections.Generic.IList{``0}*<br>The list. |
| comparer | *System.Collections.Generic.IEqualityComparer{``0}*<br>The comparer. |
| treatNullListAs | *System.Boolean*<br>The value to return if the list is null |


#### Returns

true if the value is not in the list; otherwise, false.


## T:DNX.Helpers.Linq.ListExtensions

List Extensions.


### M:DNX.Helpers.Linq.ListExtensions.GetAbsoluteIndex``1(list, index)

Gets the absolute index value for the list.

| Name | Description |
| ---- | ----------- |
| list | *System.Collections.Generic.IList{``0}*<br>The list. |
| index | *System.Int32*<br>The index. |


#### Returns

System.Int32.


### M:DNX.Helpers.Linq.ListExtensions.GetAt``1(list, index, defaultValue)

Gets at.

| Name | Description |
| ---- | ----------- |
| list | *System.Collections.Generic.IList{``0}*<br>The list. |
| index | *System.Int32*<br>The index. |
| defaultValue | *``0*<br>The default value. |


#### Returns

T.


### M:DNX.Helpers.Linq.ListExtensions.IsIndexValid``1(list, index)

Determines whether the index is valid for the list

| Name | Description |
| ---- | ----------- |
| list | *System.Collections.Generic.IList{``0}*<br>The list. |
| index | *System.Int32*<br>The index. |


#### Returns

true if [is index valid] [the specified index]; otherwise, false.


### M:DNX.Helpers.Linq.ListExtensions.Move``1(list, oldIndex, newIndex)

Moves an item to the new specified index

| Name | Description |
| ---- | ----------- |
| list | *System.Collections.Generic.IList{``0}*<br>The list. |
| oldIndex | *System.Int32*<br>The old index. |
| newIndex | *System.Int32*<br>The new index. |

*System.ArgumentOutOfRangeException:*  oldIndex or newIndex 

*DNX.Helpers.Exceptions.ReadOnlyListException`1:* 


### M:DNX.Helpers.Linq.ListExtensions.Swap``1(list, oldIndex, newIndex)

Swaps the items at the 2 specified indexes

| Name | Description |
| ---- | ----------- |
| list | *System.Collections.Generic.IList{``0}*<br>The list. |
| oldIndex | *System.Int32*<br>The old index. |
| newIndex | *System.Int32*<br>The new index. |

*System.ArgumentOutOfRangeException:*  oldIndex or newIndex 

*DNX.Helpers.Exceptions.ReadOnlyListException`1:* 


## T:DNX.Helpers.Linq.MergeTechnique

MergeTechnique


#### Remarks

The technique to use when merging dictionaries


### F:DNX.Helpers.Linq.MergeTechnique.TakeFirst

When keys clash, take the first found key value


### F:DNX.Helpers.Linq.MergeTechnique.TakeLast

When keys clash, take the last found key value


### F:DNX.Helpers.Linq.MergeTechnique.Unique

All keys must be unique


## T:DNX.Helpers.Linq.NameValueExtensions

Class NameValueExtensions.


### M:DNX.Helpers.Linq.NameValueExtensions.ToDictionary(collection, mergeTechnique)

Create a Dictionary from a NameValueCollection

| Name | Description |
| ---- | ----------- |
| collection | *System.Collections.Specialized.NameValueCollection*<br>The collection. |
| mergeTechnique | *DNX.Helpers.Linq.MergeTechnique*<br>The merge technique. |


#### Returns

IDictionary<System.String, System.String>.


## T:DNX.Helpers.Linq.TupleExtensions

Class TupleListExtensions.


### M:DNX.Helpers.Linq.TupleExtensions.Add``2(System.Collections.Generic.IList{System.Tuple{``0,``1}},``0,``1)

Adds the specified item1.

| Name | Description |
| ---- | ----------- |
| list | *System.Collections.Generic.IList{``0}*<br>The list. |
| item1 | *`0*<br>The item1. |
| item2 | *`1*<br>The item2. |

### M:DNX.Helpers.Linq.TupleExtensions.Add``3(System.Collections.Generic.IList{System.Tuple{``0,``1,``2}},``0,``1,``2)

Adds the specified item1.

| Name | Description |
| ---- | ----------- |
| list | *System.Collections.Generic.IList{``0}*<br>The list. |
| item1 | *`0*<br>The item1. |
| item2 | *`1*<br>The item2. |
| item3 | *Unknown type*<br>The item3. |

### M:DNX.Helpers.Linq.TupleExtensions.Add``4(System.Collections.Generic.IList{System.Tuple{``0,``1,``2,``3}},``0,``1,``2,``3)

Adds the specified item1.

| Name | Description |
| ---- | ----------- |
| list | *System.Collections.Generic.IList{``0}*<br>The list. |
| item1 | *`0*<br>The item1. |
| item2 | *`1*<br>The item2. |
| item3 | *Unknown type*<br>The item3. |
| item4 | *Unknown type*<br>The item4. |

### M:DNX.Helpers.Linq.TupleExtensions.Add``5(System.Collections.Generic.IList{System.Tuple{``0,``1,``2,``3,``4}},``0,``1,``2,``3,``4)

Adds the specified item1.

| Name | Description |
| ---- | ----------- |
| list | *System.Collections.Generic.IList{``0}*<br>The list. |
| item1 | *`0*<br>The item1. |
| item2 | *`1*<br>The item2. |
| item3 | *Unknown type*<br>The item3. |
| item4 | *Unknown type*<br>The item4. |
| item5 | *Unknown type*<br>The item5. |

### M:DNX.Helpers.Linq.TupleExtensions.Add``6(System.Collections.Generic.IList{System.Tuple{``0,``1,``2,``3,``4,``5}},``0,``1,``2,``3,``4,``5)

Adds the specified item1.

| Name | Description |
| ---- | ----------- |
| list | *System.Collections.Generic.IList{``0}*<br>The list. |
| item1 | *`0*<br>The item1. |
| item2 | *`1*<br>The item2. |
| item3 | *Unknown type*<br>The item3. |
| item4 | *Unknown type*<br>The item4. |
| item5 | *Unknown type*<br>The item5. |
| item6 | *Unknown type*<br>The item6. |

## T:DNX.Helpers.Linq.TupleList`2

Class TupleList to allow Tuple initializers


### M:DNX.Helpers.Linq.TupleList`2.Add(item, item2)

Adds the specified item.

| Name | Description |
| ---- | ----------- |
| item | *`0*<br>The item. |
| item2 | *`1*<br>The item2. |

## T:DNX.Helpers.Linq.TupleList`3

Class TupleList to allow Tuple initializers


### M:DNX.Helpers.Linq.TupleList`3.Add(item, item2, item3)

Adds the specified item.

| Name | Description |
| ---- | ----------- |
| item | *`0*<br>The item. |
| item2 | *`1*<br>The item2. |
| item3 | *`2*<br>The item3. |

## T:DNX.Helpers.Linq.TupleList`4

Class TupleList to allow Tuple initializers


### M:DNX.Helpers.Linq.TupleList`4.Add(item, item2, item3, item4)

Adds the specified item.

| Name | Description |
| ---- | ----------- |
| item | *`0*<br>The item. |
| item2 | *`1*<br>The item2. |
| item3 | *`2*<br>The item3. |
| item4 | *`3*<br>The item4. |

## T:DNX.Helpers.Linq.TupleList`5

Class TupleList to allow Tuple initializers


### M:DNX.Helpers.Linq.TupleList`5.Add(item, item2, item3, item4, item5)

Adds the specified item.

| Name | Description |
| ---- | ----------- |
| item | *`0*<br>The item. |
| item2 | *`1*<br>The item2. |
| item3 | *`2*<br>The item3. |
| item4 | *`3*<br>The item4. |
| item5 | *`4*<br>The item5. |

## T:DNX.Helpers.Linq.TupleList`6

Class TupleList to allow Tuple initializers


### M:DNX.Helpers.Linq.TupleList`6.Add(item, item2, item3, item4, item5, item6)

Adds the specified item.

| Name | Description |
| ---- | ----------- |
| item | *`0*<br>The item. |
| item2 | *`1*<br>The item2. |
| item3 | *`2*<br>The item3. |
| item4 | *`3*<br>The item4. |
| item5 | *`4*<br>The item5. |
| item6 | *`5*<br>The item6. |

## T:DNX.Helpers.Maths.BuiltInTypes.MathsByteExtensions

Class MathsByteExtensions.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsByteExtensions.GetLowerBound(min, max, allowEitherOrder)

Gets the lower bound.

| Name | Description |
| ---- | ----------- |
| min | *System.Byte*<br>The minimum. |
| max | *System.Byte*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

byte


### M:DNX.Helpers.Maths.BuiltInTypes.MathsByteExtensions.GetUpperBound(min, max, allowEitherOrder)

Gets the upper bound.

| Name | Description |
| ---- | ----------- |
| min | *System.Byte*<br>The minimum. |
| max | *System.Byte*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

byte


### M:DNX.Helpers.Maths.BuiltInTypes.MathsByteExtensions.IsBetween(value, min, max)

Determines whether the specified value is inclusively between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Byte*<br>The value. |
| min | *System.Byte*<br>The minimum. |
| max | *System.Byte*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsByteExtensions.IsBetween(value, min, max, boundsType)

Determines whether the specified value is between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Byte*<br>The value. |
| min | *System.Byte*<br>The minimum. |
| max | *System.Byte*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsByteExtensions.IsBetween(value, min, max, allowEitherOrder, boundsType)

Determines whether the specified value is between min and max with full control over bounds checking.

| Name | Description |
| ---- | ----------- |
| value | *System.Byte*<br>The value. |
| min | *System.Byte*<br>The minimum. |
| max | *System.Byte*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsByteExtensions.IsBetweenEither(value, min, max)

Determines whether the specified value is inclusively between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Byte*<br>The value. |
| min | *System.Byte*<br>The minimum. |
| max | *System.Byte*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsByteExtensions.IsBetweenEither(value, min, max, boundsType)

Determines whether the specified value is between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Byte*<br>The value. |
| min | *System.Byte*<br>The minimum. |
| max | *System.Byte*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if [is between either] [the specified minimum]; otherwise, false.


## T:DNX.Helpers.Maths.BuiltInTypes.MathsDateTimeExtensions

Class MathsDateTimeExtensions.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDateTimeExtensions.GetLowerBound(min, max, allowEitherOrder)

Gets the lower bound.

| Name | Description |
| ---- | ----------- |
| min | *System.DateTime*<br>The minimum. |
| max | *System.DateTime*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

DateTime


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDateTimeExtensions.GetUpperBound(min, max, allowEitherOrder)

Gets the upper bound.

| Name | Description |
| ---- | ----------- |
| min | *System.DateTime*<br>The minimum. |
| max | *System.DateTime*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

DateTime


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDateTimeExtensions.IsBetween(value, min, max)

Determines whether the specified value is inclusively between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.DateTime*<br>The value. |
| min | *System.DateTime*<br>The minimum. |
| max | *System.DateTime*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDateTimeExtensions.IsBetween(value, min, max, boundsType)

Determines whether the specified value is between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.DateTime*<br>The value. |
| min | *System.DateTime*<br>The minimum. |
| max | *System.DateTime*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDateTimeExtensions.IsBetween(value, min, max, allowEitherOrder, boundsType)

Determines whether the specified value is between min and max with full control over bounds checking.

| Name | Description |
| ---- | ----------- |
| value | *System.DateTime*<br>The value. |
| min | *System.DateTime*<br>The minimum. |
| max | *System.DateTime*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDateTimeExtensions.IsBetweenEither(value, min, max)

Determines whether the specified value is inclusively between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.DateTime*<br>The value. |
| min | *System.DateTime*<br>The minimum. |
| max | *System.DateTime*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDateTimeExtensions.IsBetweenEither(value, min, max, boundsType)

Determines whether the specified value is between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.DateTime*<br>The value. |
| min | *System.DateTime*<br>The minimum. |
| max | *System.DateTime*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if [is between either] [the specified minimum]; otherwise, false.


## T:DNX.Helpers.Maths.BuiltInTypes.MathsDecimalExtensions

Class MathsDecimalExtensions.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDecimalExtensions.GetLowerBound(min, max, allowEitherOrder)

Gets the lower bound.

| Name | Description |
| ---- | ----------- |
| min | *System.Decimal*<br>The minimum. |
| max | *System.Decimal*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

decimal


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDecimalExtensions.GetUpperBound(min, max, allowEitherOrder)

Gets the upper bound.

| Name | Description |
| ---- | ----------- |
| min | *System.Decimal*<br>The minimum. |
| max | *System.Decimal*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

decimal


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDecimalExtensions.IsBetween(value, min, max)

Determines whether the specified value is inclusively between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Decimal*<br>The value. |
| min | *System.Decimal*<br>The minimum. |
| max | *System.Decimal*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDecimalExtensions.IsBetween(value, min, max, boundsType)

Determines whether the specified value is between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Decimal*<br>The value. |
| min | *System.Decimal*<br>The minimum. |
| max | *System.Decimal*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDecimalExtensions.IsBetween(value, min, max, allowEitherOrder, boundsType)

Determines whether the specified value is between min and max with full control over bounds checking.

| Name | Description |
| ---- | ----------- |
| value | *System.Decimal*<br>The value. |
| min | *System.Decimal*<br>The minimum. |
| max | *System.Decimal*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDecimalExtensions.IsBetweenEither(value, min, max)

Determines whether the specified value is inclusively between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Decimal*<br>The value. |
| min | *System.Decimal*<br>The minimum. |
| max | *System.Decimal*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDecimalExtensions.IsBetweenEither(value, min, max, boundsType)

Determines whether the specified value is between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Decimal*<br>The value. |
| min | *System.Decimal*<br>The minimum. |
| max | *System.Decimal*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if [is between either] [the specified minimum]; otherwise, false.


## T:DNX.Helpers.Maths.BuiltInTypes.MathsDoubleExtensions

Class MathsDoubleExtensions.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDoubleExtensions.GetLowerBound(min, max, allowEitherOrder)

Gets the lower bound.

| Name | Description |
| ---- | ----------- |
| min | *System.Double*<br>The minimum. |
| max | *System.Double*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

double


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDoubleExtensions.GetUpperBound(min, max, allowEitherOrder)

Gets the upper bound.

| Name | Description |
| ---- | ----------- |
| min | *System.Double*<br>The minimum. |
| max | *System.Double*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

double


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDoubleExtensions.IsBetween(value, min, max)

Determines whether the specified value is inclusively between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Double*<br>The value. |
| min | *System.Double*<br>The minimum. |
| max | *System.Double*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDoubleExtensions.IsBetween(value, min, max, boundsType)

Determines whether the specified value is between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Double*<br>The value. |
| min | *System.Double*<br>The minimum. |
| max | *System.Double*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDoubleExtensions.IsBetween(value, min, max, allowEitherOrder, boundsType)

Determines whether the specified value is between min and max with full control over bounds checking.

| Name | Description |
| ---- | ----------- |
| value | *System.Double*<br>The value. |
| min | *System.Double*<br>The minimum. |
| max | *System.Double*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDoubleExtensions.IsBetweenEither(value, min, max)

Determines whether the specified value is inclusively between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Double*<br>The value. |
| min | *System.Double*<br>The minimum. |
| max | *System.Double*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsDoubleExtensions.IsBetweenEither(value, min, max, boundsType)

Determines whether the specified value is between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Double*<br>The value. |
| min | *System.Double*<br>The minimum. |
| max | *System.Double*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if [is between either] [the specified minimum]; otherwise, false.


## T:DNX.Helpers.Maths.BuiltInTypes.MathsFloatExtensions

Class MathsFloatExtensions.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsFloatExtensions.GetLowerBound(min, max, allowEitherOrder)

Gets the lower bound.

| Name | Description |
| ---- | ----------- |
| min | *System.Single*<br>The minimum. |
| max | *System.Single*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

float


### M:DNX.Helpers.Maths.BuiltInTypes.MathsFloatExtensions.GetUpperBound(min, max, allowEitherOrder)

Gets the upper bound.

| Name | Description |
| ---- | ----------- |
| min | *System.Single*<br>The minimum. |
| max | *System.Single*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

float


### M:DNX.Helpers.Maths.BuiltInTypes.MathsFloatExtensions.IsBetween(value, min, max)

Determines whether the specified value is inclusively between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Single*<br>The value. |
| min | *System.Single*<br>The minimum. |
| max | *System.Single*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsFloatExtensions.IsBetween(value, min, max, boundsType)

Determines whether the specified value is between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Single*<br>The value. |
| min | *System.Single*<br>The minimum. |
| max | *System.Single*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsFloatExtensions.IsBetween(value, min, max, allowEitherOrder, boundsType)

Determines whether the specified value is between min and max with full control over bounds checking.

| Name | Description |
| ---- | ----------- |
| value | *System.Single*<br>The value. |
| min | *System.Single*<br>The minimum. |
| max | *System.Single*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsFloatExtensions.IsBetweenEither(value, min, max)

Determines whether the specified value is inclusively between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Single*<br>The value. |
| min | *System.Single*<br>The minimum. |
| max | *System.Single*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsFloatExtensions.IsBetweenEither(value, min, max, boundsType)

Determines whether the specified value is between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Single*<br>The value. |
| min | *System.Single*<br>The minimum. |
| max | *System.Single*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if [is between either] [the specified minimum]; otherwise, false.


## T:DNX.Helpers.Maths.BuiltInTypes.MathsInt16Extensions

Class MathsInt16Extensions.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt16Extensions.GetLowerBound(min, max, allowEitherOrder)

Gets the lower bound.

| Name | Description |
| ---- | ----------- |
| min | *System.Int16*<br>The minimum. |
| max | *System.Int16*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

short


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt16Extensions.GetUpperBound(min, max, allowEitherOrder)

Gets the upper bound.

| Name | Description |
| ---- | ----------- |
| min | *System.Int16*<br>The minimum. |
| max | *System.Int16*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

short


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt16Extensions.IsBetween(value, min, max)

Determines whether the specified value is inclusively between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Int16*<br>The value. |
| min | *System.Int16*<br>The minimum. |
| max | *System.Int16*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt16Extensions.IsBetween(value, min, max, boundsType)

Determines whether the specified value is between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Int16*<br>The value. |
| min | *System.Int16*<br>The minimum. |
| max | *System.Int16*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt16Extensions.IsBetween(value, min, max, allowEitherOrder, boundsType)

Determines whether the specified value is between min and max with full control over bounds checking.

| Name | Description |
| ---- | ----------- |
| value | *System.Int16*<br>The value. |
| min | *System.Int16*<br>The minimum. |
| max | *System.Int16*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt16Extensions.IsBetweenEither(value, min, max)

Determines whether the specified value is inclusively between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Int16*<br>The value. |
| min | *System.Int16*<br>The minimum. |
| max | *System.Int16*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt16Extensions.IsBetweenEither(value, min, max, boundsType)

Determines whether the specified value is between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Int16*<br>The value. |
| min | *System.Int16*<br>The minimum. |
| max | *System.Int16*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if [is between either] [the specified minimum]; otherwise, false.


## T:DNX.Helpers.Maths.BuiltInTypes.MathsInt32Extensions

Class MathsInt32Extensions.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt32Extensions.GetLowerBound(min, max, allowEitherOrder)

Gets the lower bound.

| Name | Description |
| ---- | ----------- |
| min | *System.Int32*<br>The minimum. |
| max | *System.Int32*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

int


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt32Extensions.GetUpperBound(min, max, allowEitherOrder)

Gets the upper bound.

| Name | Description |
| ---- | ----------- |
| min | *System.Int32*<br>The minimum. |
| max | *System.Int32*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

int


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt32Extensions.IsBetween(value, min, max)

Determines whether the specified value is inclusively between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Int32*<br>The value. |
| min | *System.Int32*<br>The minimum. |
| max | *System.Int32*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt32Extensions.IsBetween(value, min, max, boundsType)

Determines whether the specified value is between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Int32*<br>The value. |
| min | *System.Int32*<br>The minimum. |
| max | *System.Int32*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt32Extensions.IsBetween(value, min, max, allowEitherOrder, boundsType)

Determines whether the specified value is between min and max with full control over bounds checking.

| Name | Description |
| ---- | ----------- |
| value | *System.Int32*<br>The value. |
| min | *System.Int32*<br>The minimum. |
| max | *System.Int32*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt32Extensions.IsBetweenEither(value, min, max)

Determines whether the specified value is inclusively between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Int32*<br>The value. |
| min | *System.Int32*<br>The minimum. |
| max | *System.Int32*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt32Extensions.IsBetweenEither(value, min, max, boundsType)

Determines whether the specified value is between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Int32*<br>The value. |
| min | *System.Int32*<br>The minimum. |
| max | *System.Int32*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if [is between either] [the specified minimum]; otherwise, false.


## T:DNX.Helpers.Maths.BuiltInTypes.MathsInt64Extensions

Class MathsInt64Extensions.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt64Extensions.GetLowerBound(min, max, allowEitherOrder)

Gets the lower bound.

| Name | Description |
| ---- | ----------- |
| min | *System.Int64*<br>The minimum. |
| max | *System.Int64*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

long


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt64Extensions.GetUpperBound(min, max, allowEitherOrder)

Gets the upper bound.

| Name | Description |
| ---- | ----------- |
| min | *System.Int64*<br>The minimum. |
| max | *System.Int64*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

long


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt64Extensions.IsBetween(value, min, max)

Determines whether the specified value is inclusively between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Int64*<br>The value. |
| min | *System.Int64*<br>The minimum. |
| max | *System.Int64*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt64Extensions.IsBetween(value, min, max, boundsType)

Determines whether the specified value is between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Int64*<br>The value. |
| min | *System.Int64*<br>The minimum. |
| max | *System.Int64*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt64Extensions.IsBetween(value, min, max, allowEitherOrder, boundsType)

Determines whether the specified value is between min and max with full control over bounds checking.

| Name | Description |
| ---- | ----------- |
| value | *System.Int64*<br>The value. |
| min | *System.Int64*<br>The minimum. |
| max | *System.Int64*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt64Extensions.IsBetweenEither(value, min, max)

Determines whether the specified value is inclusively between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Int64*<br>The value. |
| min | *System.Int64*<br>The minimum. |
| max | *System.Int64*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsInt64Extensions.IsBetweenEither(value, min, max, boundsType)

Determines whether the specified value is between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.Int64*<br>The value. |
| min | *System.Int64*<br>The minimum. |
| max | *System.Int64*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if [is between either] [the specified minimum]; otherwise, false.


## T:DNX.Helpers.Maths.BuiltInTypes.MathsSByteExtensions

Class MathsSByteExtensions.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsSByteExtensions.GetLowerBound(min, max, allowEitherOrder)

Gets the lower bound.

| Name | Description |
| ---- | ----------- |
| min | *System.SByte*<br>The minimum. |
| max | *System.SByte*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

sbyte


### M:DNX.Helpers.Maths.BuiltInTypes.MathsSByteExtensions.GetUpperBound(min, max, allowEitherOrder)

Gets the upper bound.

| Name | Description |
| ---- | ----------- |
| min | *System.SByte*<br>The minimum. |
| max | *System.SByte*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

sbyte


### M:DNX.Helpers.Maths.BuiltInTypes.MathsSByteExtensions.IsBetween(value, min, max)

Determines whether the specified value is inclusively between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.SByte*<br>The value. |
| min | *System.SByte*<br>The minimum. |
| max | *System.SByte*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsSByteExtensions.IsBetween(value, min, max, boundsType)

Determines whether the specified value is between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.SByte*<br>The value. |
| min | *System.SByte*<br>The minimum. |
| max | *System.SByte*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsSByteExtensions.IsBetween(value, min, max, allowEitherOrder, boundsType)

Determines whether the specified value is between min and max with full control over bounds checking.

| Name | Description |
| ---- | ----------- |
| value | *System.SByte*<br>The value. |
| min | *System.SByte*<br>The minimum. |
| max | *System.SByte*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsSByteExtensions.IsBetweenEither(value, min, max)

Determines whether the specified value is inclusively between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.SByte*<br>The value. |
| min | *System.SByte*<br>The minimum. |
| max | *System.SByte*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsSByteExtensions.IsBetweenEither(value, min, max, boundsType)

Determines whether the specified value is between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.SByte*<br>The value. |
| min | *System.SByte*<br>The minimum. |
| max | *System.SByte*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if [is between either] [the specified minimum]; otherwise, false.


## T:DNX.Helpers.Maths.BuiltInTypes.MathsUInt16Extensions

Class MathsUInt16Extensions.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt16Extensions.GetLowerBound(min, max, allowEitherOrder)

Gets the lower bound.

| Name | Description |
| ---- | ----------- |
| min | *System.UInt16*<br>The minimum. |
| max | *System.UInt16*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

ushort


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt16Extensions.GetUpperBound(min, max, allowEitherOrder)

Gets the upper bound.

| Name | Description |
| ---- | ----------- |
| min | *System.UInt16*<br>The minimum. |
| max | *System.UInt16*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

ushort


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt16Extensions.IsBetween(value, min, max)

Determines whether the specified value is inclusively between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.UInt16*<br>The value. |
| min | *System.UInt16*<br>The minimum. |
| max | *System.UInt16*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt16Extensions.IsBetween(value, min, max, boundsType)

Determines whether the specified value is between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.UInt16*<br>The value. |
| min | *System.UInt16*<br>The minimum. |
| max | *System.UInt16*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt16Extensions.IsBetween(value, min, max, allowEitherOrder, boundsType)

Determines whether the specified value is between min and max with full control over bounds checking.

| Name | Description |
| ---- | ----------- |
| value | *System.UInt16*<br>The value. |
| min | *System.UInt16*<br>The minimum. |
| max | *System.UInt16*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt16Extensions.IsBetweenEither(value, min, max)

Determines whether the specified value is inclusively between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.UInt16*<br>The value. |
| min | *System.UInt16*<br>The minimum. |
| max | *System.UInt16*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt16Extensions.IsBetweenEither(value, min, max, boundsType)

Determines whether the specified value is between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.UInt16*<br>The value. |
| min | *System.UInt16*<br>The minimum. |
| max | *System.UInt16*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if [is between either] [the specified minimum]; otherwise, false.


## T:DNX.Helpers.Maths.BuiltInTypes.MathsUInt32Extensions

Class MathsUInt32Extensions.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt32Extensions.GetLowerBound(min, max, allowEitherOrder)

Gets the lower bound.

| Name | Description |
| ---- | ----------- |
| min | *System.UInt32*<br>The minimum. |
| max | *System.UInt32*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

uint


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt32Extensions.GetUpperBound(min, max, allowEitherOrder)

Gets the upper bound.

| Name | Description |
| ---- | ----------- |
| min | *System.UInt32*<br>The minimum. |
| max | *System.UInt32*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

uint


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt32Extensions.IsBetween(value, min, max)

Determines whether the specified value is inclusively between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.UInt32*<br>The value. |
| min | *System.UInt32*<br>The minimum. |
| max | *System.UInt32*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt32Extensions.IsBetween(value, min, max, boundsType)

Determines whether the specified value is between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.UInt32*<br>The value. |
| min | *System.UInt32*<br>The minimum. |
| max | *System.UInt32*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt32Extensions.IsBetween(value, min, max, allowEitherOrder, boundsType)

Determines whether the specified value is between min and max with full control over bounds checking.

| Name | Description |
| ---- | ----------- |
| value | *System.UInt32*<br>The value. |
| min | *System.UInt32*<br>The minimum. |
| max | *System.UInt32*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt32Extensions.IsBetweenEither(value, min, max)

Determines whether the specified value is inclusively between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.UInt32*<br>The value. |
| min | *System.UInt32*<br>The minimum. |
| max | *System.UInt32*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt32Extensions.IsBetweenEither(value, min, max, boundsType)

Determines whether the specified value is between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.UInt32*<br>The value. |
| min | *System.UInt32*<br>The minimum. |
| max | *System.UInt32*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if [is between either] [the specified minimum]; otherwise, false.


## T:DNX.Helpers.Maths.BuiltInTypes.MathsUInt64Extensions

Class MathsUInt64Extensions.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt64Extensions.GetLowerBound(min, max, allowEitherOrder)

Gets the lower bound.

| Name | Description |
| ---- | ----------- |
| min | *System.UInt64*<br>The minimum. |
| max | *System.UInt64*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

ulong


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt64Extensions.GetUpperBound(min, max, allowEitherOrder)

Gets the upper bound.

| Name | Description |
| ---- | ----------- |
| min | *System.UInt64*<br>The minimum. |
| max | *System.UInt64*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order |


#### Returns

ulong


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt64Extensions.IsBetween(value, min, max)

Determines whether the specified value is inclusively between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.UInt64*<br>The value. |
| min | *System.UInt64*<br>The minimum. |
| max | *System.UInt64*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt64Extensions.IsBetween(value, min, max, boundsType)

Determines whether the specified value is between min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.UInt64*<br>The value. |
| min | *System.UInt64*<br>The minimum. |
| max | *System.UInt64*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt64Extensions.IsBetween(value, min, max, allowEitherOrder, boundsType)

Determines whether the specified value is between min and max with full control over bounds checking.

| Name | Description |
| ---- | ----------- |
| value | *System.UInt64*<br>The value. |
| min | *System.UInt64*<br>The minimum. |
| max | *System.UInt64*<br>The maximum. |
| allowEitherOrder | *System.Boolean*<br>if set to true allow min/max in either order. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt64Extensions.IsBetweenEither(value, min, max)

Determines whether the specified value is inclusively between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.UInt64*<br>The value. |
| min | *System.UInt64*<br>The minimum. |
| max | *System.UInt64*<br>The maximum. |


#### Returns

true if the specified minimum is between min and max; otherwise, false.


### M:DNX.Helpers.Maths.BuiltInTypes.MathsUInt64Extensions.IsBetweenEither(value, min, max, boundsType)

Determines whether the specified value is between the smaller of min and max and the larger of min and max.

| Name | Description |
| ---- | ----------- |
| value | *System.UInt64*<br>The value. |
| min | *System.UInt64*<br>The minimum. |
| max | *System.UInt64*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Control boundary checking. |


#### Returns

true if [is between either] [the specified minimum]; otherwise, false.


## T:DNX.Helpers.Maths.IsBetweenBoundsType

Enum IsBetweenBoundsType


### F:DNX.Helpers.Maths.IsBetweenBoundsType.ExcludeLowerAndUpper

Exclude Lower and Upper bounds when determining IsBetween


### F:DNX.Helpers.Maths.IsBetweenBoundsType.ExcludeLowerIncludeUpper

Exclude Lower but Include Upper bounds when determining IsBetween


### F:DNX.Helpers.Maths.IsBetweenBoundsType.Exclusive

Exclude Lower and Upper bounds when determining IsBetween


### F:DNX.Helpers.Maths.IsBetweenBoundsType.GreaterThanLowerLessThanOrEqualToUpper

Exclude Lower but Include Upper bounds when determining IsBetween


### F:DNX.Helpers.Maths.IsBetweenBoundsType.GreaterThanOrEqualToLowerLessThanUpper

Include Lower but Exclude Upper bounds when determining IsBetween


### F:DNX.Helpers.Maths.IsBetweenBoundsType.IncludeLowerAndUpper

Include Lower and Upper bounds when determining IsBetween


### F:DNX.Helpers.Maths.IsBetweenBoundsType.IncludeLowerExcludeUpper

Include Lower but Exclude Upper bounds when determining IsBetween


### F:DNX.Helpers.Maths.IsBetweenBoundsType.Inclusive

Include Lower and Upper bounds when determining IsBetween


## T:DNX.Helpers.Maths.IsBetweenTypeExtensions

Class IsBetweenTypeExtensions.


### M:DNX.Helpers.Maths.IsBetweenTypeExtensions.GetLimitDescriptionFormat(boundsType)

Gets the limit description format.

| Name | Description |
| ---- | ----------- |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |


#### Returns

System.String.


## T:DNX.Helpers.Objects.ObjectExtensions

Class ObjectExtensions.


### M:DNX.Helpers.Objects.ObjectExtensions.CoalesceNull(objects)

Coalesces the list of objects to find the first not null

| Name | Description |
| ---- | ----------- |
| objects | *System.Collections.Generic.IList{System.Object}*<br>The objects. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Objects.ObjectExtensions.CoalesceNull(objects)

Coalesces the list of objects to find the first not null

| Name | Description |
| ---- | ----------- |
| objects | *System.Object[]*<br>The objects. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Objects.ObjectExtensions.GetUniqueInstanceId(obj)

Gets the unique instance identifier.

| Name | Description |
| ---- | ----------- |
| obj | *System.Object*<br>The object. |


#### Returns

System.String.


### M:DNX.Helpers.Objects.ObjectExtensions.GetUniqueInstanceId(obj, instanceIdOverride)

Gets the unique instance identifier.

| Name | Description |
| ---- | ----------- |
| obj | *System.Object*<br>The object. |
| instanceIdOverride | *System.String*<br>The instance identifier override. |


#### Returns

System.String.


## T:DNX.Helpers.Reflection.AttributeExtensions

Attribute Extensions.


### M:DNX.Helpers.Reflection.AttributeExtensions.GetMemberAttributes``1(memberInfo, inherit)

Gets the custom attributes from a member (property / field)

| Name | Description |
| ---- | ----------- |
| memberInfo | *System.Reflection.MemberInfo*<br>The member information. |
| inherit | *System.Boolean*<br>The inherit. |


#### Returns

System.Collections.Generic.IList<T>.


### M:DNX.Helpers.Reflection.AttributeExtensions.GetTypeAttributes``1(type, inherit)

Gets the custom attributes for the Type.

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br>The type. |
| inherit | *System.Boolean*<br>if set to true [inherit]. |


#### Returns

IList<T>.


### M:DNX.Helpers.Reflection.AttributeExtensions.GetTypeAttributesFromInstance``1(instance, inherit)

Gets the custom attributes for the type from an instance.

| Name | Description |
| ---- | ----------- |
| instance | *System.Object*<br>The object. |
| inherit | *System.Boolean*<br>if set to true [inherit]. |


#### Returns

IList<T>.


### M:DNX.Helpers.Reflection.AttributeExtensions.HasTypeAttributes``1(type, inherit)

Does the instance object have type attributes

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br>The type. |
| inherit | *System.Boolean*<br>if set to true [inherit]. |


#### Returns

true if XXXX, false otherwise.


### M:DNX.Helpers.Reflection.AttributeExtensions.InstanceHasTypeAttributes``1(obj, inherit)

Does the instance object have type attributes

| Name | Description |
| ---- | ----------- |
| obj | *System.Object*<br>The object. |
| inherit | *System.Boolean*<br>if set to true [inherit]. |


#### Returns

true if XXXX, false otherwise.


## T:DNX.Helpers.Reflection.ExpressionExtensions

Class ExpressionExtensions.


### M:DNX.Helpers.Reflection.ExpressionExtensions.GetExpressionName``1(exp)

Gets the name of the expression.

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{``0}}*<br>The exp. |


#### Returns




### M:DNX.Helpers.Reflection.ExpressionExtensions.GetLambdaName``1(exp)

Gets the name of the lambda expression.

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{``0}}*<br>The exp. |


#### Returns




### M:DNX.Helpers.Reflection.ExpressionExtensions.GetMemberName``1(exp)

Gets the name of the member expression.

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{``0}}*<br>The exp. |


#### Returns




### M:DNX.Helpers.Reflection.ExpressionExtensions.GetUnaryName``1(exp)

Gets the name of the unary expression.

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{``0}}*<br>The exp. |


#### Returns




### M:DNX.Helpers.Reflection.ExpressionExtensions.IsLambdaExpression``1(exp)

Determines whether Determines whether the expression is a lambda expression

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{``0}}*<br>The exp. |


#### Returns




### M:DNX.Helpers.Reflection.ExpressionExtensions.IsMemberExpression``1(exp)

Determines whether the expression is a member expression

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{``0}}*<br>The exp. |


#### Returns




### M:DNX.Helpers.Reflection.ExpressionExtensions.IsUnaryExpression``1(exp)

Determines whether Determines whether the expression is a unary expression

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{``0}}*<br>The exp. |


#### Returns




## T:DNX.Helpers.Reflection.InstanceResolutionExtensions

Instance Resolution Extensions.


### M:DNX.Helpers.Reflection.InstanceResolutionExtensions.GetConcreteTypesThatImplementInterface``1(assembly)

Find all concrete classes in an assembly that implement a given interface

| Name | Description |
| ---- | ----------- |
| assembly | *System.Reflection.Assembly*<br>The assembly to search |


#### Returns

List of 


### M:DNX.Helpers.Reflection.InstanceResolutionExtensions.GetInstanceOfClassesThatImplementInterfaceWithAttribute``2(System.Collections.Generic.IList{``0},System.Func{``1,System.Boolean})

Find instances of classes in an assembly that implement a given interface and are decorated with an attribute that passes the given func test

| Name | Description |
| ---- | ----------- |
| instances | *Unknown type*<br>The instances. |
| func | *Unknown type*<br>The func to run against the decoration attribute |


#### Returns

Instance of T or null


### M:DNX.Helpers.Reflection.InstanceResolutionExtensions.GetInstancesOfClassesThatImplementInterface``1(assembly)

Find instances of classes in an assembly that implement a given interface

| Name | Description |
| ---- | ----------- |
| assembly | *System.Reflection.Assembly*<br>The assembly to search |


#### Returns

List of instances of T>


### M:DNX.Helpers.Reflection.InstanceResolutionExtensions.GetTypesThatImplementInterface``1(assembly)

Finds the types that implement interface.

| Name | Description |
| ---- | ----------- |
| assembly | *System.Reflection.Assembly*<br>The assembly. |


#### Returns

IList<Type>.


### M:DNX.Helpers.Reflection.InstanceResolutionExtensions.ResolveImplementationOfInterfaceWithAttribute``2(System.Reflection.Assembly,System.Func{``1,System.Boolean})

Find instances of classes in an assembly that implement a given interface and are decorated with an attribute that passes the given func test

| Name | Description |
| ---- | ----------- |
| assembly | *System.Reflection.Assembly*<br>The assembly to search |
| func | *Unknown type*<br>The func to run against the decoration attribute |


#### Returns

List of instances of T


## T:DNX.Helpers.Reflection.ReflectionExtensions

Reflection Extensions.


### M:DNX.Helpers.Reflection.ReflectionExtensions.GetPropertiesDictionary(obj)

Gets the object properties as a dictionary.

| Name | Description |
| ---- | ----------- |
| obj | *System.Object*<br>The object. |


#### Returns

IDictionary<System.String, System.Object>.


### M:DNX.Helpers.Reflection.ReflectionExtensions.GetPropertiesDictionary(obj, bindingFlags)

Gets the object properties as a dictionary.

| Name | Description |
| ---- | ----------- |
| obj | *System.Object*<br>The object. |
| bindingFlags | *System.Reflection.BindingFlags*<br>The binding flags. |


#### Returns

IDictionary<System.String, System.Object>.


### M:DNX.Helpers.Reflection.ReflectionExtensions.GetPropertiesForType(type)

Gets the properties for the specified type.

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br>The type. |


#### Returns

IList<PropertyInfo>.


### M:DNX.Helpers.Reflection.ReflectionExtensions.GetPropertiesForType(type, bindingFlags)

Gets the properties for the specified type.

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br>The type. |
| bindingFlags | *System.Reflection.BindingFlags*<br>The binding flags. |


#### Returns

IList<PropertyInfo>.


### M:DNX.Helpers.Reflection.ReflectionExtensions.GetPropertiesForTypes(types)

Gets the properties for the specified types.

| Name | Description |
| ---- | ----------- |
| types | *System.Collections.Generic.IEnumerable{System.Type}*<br>The types. |


#### Returns

IList<PropertyInfo>.


### M:DNX.Helpers.Reflection.ReflectionExtensions.GetPropertiesForTypes(types, bindingFlags)

Gets the properties for the specified types.

| Name | Description |
| ---- | ----------- |
| types | *System.Collections.Generic.IEnumerable{System.Type}*<br>The types. |
| bindingFlags | *System.Reflection.BindingFlags*<br>The binding flags. |


#### Returns

IList<PropertyInfo>.


### M:DNX.Helpers.Reflection.ReflectionExtensions.GetPropertyInfoByName(instance, propertyName)

Gets an objects property info by name. Supports dot notation for child properties

| Name | Description |
| ---- | ----------- |
| instance | *System.Object*<br>The instance. |
| propertyName | *System.String*<br>Name of the property. |


#### Returns

PropertyInfo.


### M:DNX.Helpers.Reflection.ReflectionExtensions.GetPropertyValueByName(instance, propertyName)

Gets he value of an objects property by name

| Name | Description |
| ---- | ----------- |
| instance | *System.Object*<br>The instance. |
| propertyName | *System.String*<br>Name of the property. |


#### Returns

System.Object.


### M:DNX.Helpers.Reflection.ReflectionExtensions.IsPropertyNameValid(instance, propertyName)

Determines whether the specified property name is valid for the specified object

| Name | Description |
| ---- | ----------- |
| instance | *System.Object*<br>The instance. |
| propertyName | *System.String*<br>Name of the property. |


#### Returns

System.Boolean.


### M:DNX.Helpers.Reflection.ReflectionExtensions.PopulateFrom``1(``0,System.Collections.Generic.IDictionary{System.String,System.Object},System.Reflection.BindingFlags)

Populates an object instance from a Dictionary

| Name | Description |
| ---- | ----------- |
| instance | *System.Object*<br>The instance. |
| dict | *Unknown type*<br>The dictionary. |
| bindingFlags | *System.Reflection.BindingFlags*<br>The binding flags. |


#### Returns

T.


### M:DNX.Helpers.Reflection.ReflectionExtensions.ToDictionary(instance, bindingFlags)

Serialises an object instance to a Dictionary

| Name | Description |
| ---- | ----------- |
| instance | *System.Object*<br>The instance. |
| bindingFlags | *System.Reflection.BindingFlags*<br>The binding flags. |


#### Returns

IDictionary<System.String, System.Object>.


### M:DNX.Helpers.Reflection.ReflectionExtensions.ToDictionaryTyped``1(instance, bindingFlags)

Serialises an object instance to a Dictionary

| Name | Description |
| ---- | ----------- |
| instance | *``0*<br>The instance. |
| bindingFlags | *System.Reflection.BindingFlags*<br>The binding flags. |


#### Returns

IDictionary<System.String, System.Object>.


### M:DNX.Helpers.Reflection.ReflectionExtensions.ToInstance``1(System.Collections.Generic.IDictionary{System.String,System.Object},System.Reflection.BindingFlags)

Creates a populated object instance from a Dictionary

| Name | Description |
| ---- | ----------- |
| dict | *Unknown type*<br>The dictionary. |
| bindingFlags | *System.Reflection.BindingFlags*<br>The binding flags. |


#### Returns

T.


## T:DNX.Helpers.Streams.StreamExtensions

Class StreamProcessor.


### M:DNX.Helpers.Streams.StreamExtensions.ReadAllBytes(stream, bufferSize)

Reads the entire stream as a byte array

| Name | Description |
| ---- | ----------- |
| stream | *System.IO.Stream*<br>The stream. |
| bufferSize | *System.Int32*<br>Size of the buffer. |


#### Returns

System.Byte[].


### M:DNX.Helpers.Streams.StreamExtensions.ReadAllLines(stream, estimatedCapacity)

Reads the entire stream as a list of lines

| Name | Description |
| ---- | ----------- |
| stream | *System.IO.Stream*<br>The stream. |
| estimatedCapacity | *System.Nullable{System.Int32}*<br>The estimated capacity. |


#### Returns

IList<System.String>.


### M:DNX.Helpers.Streams.StreamExtensions.ReadAllText(stream)

Reads the entire stream as text

| Name | Description |
| ---- | ----------- |
| stream | *System.IO.Stream*<br>The stream. |


#### Returns

System.String.


## T:DNX.Helpers.Strings.Interpolation.InterpolatableProperty

An InterpolatableProperty


### M:DNX.Helpers.Strings.Interpolation.InterpolatableProperty.GetVariableName(namePrefix)

Gets the name of the variable for substitution

| Name | Description |
| ---- | ----------- |
| namePrefix | *System.String*<br>The name prefix. |


#### Returns

System.String.


### P:DNX.Helpers.Strings.Interpolation.InterpolatableProperty.IsStatic

Gets or sets a value indicating whether this instance is static.


### P:DNX.Helpers.Strings.Interpolation.InterpolatableProperty.Name

Gets or sets the name.


### P:DNX.Helpers.Strings.Interpolation.InterpolatableProperty.PropertyInfo

Gets the property information.


## T:DNX.Helpers.Strings.Interpolation.NamedInstance

Class NamedInstance.


### M:DNX.Helpers.Strings.Interpolation.NamedInstance.#ctor(instance, name)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| instance | *System.Object*<br>The instance. |
| name | *System.String*<br>The name. |

### P:DNX.Helpers.Strings.Interpolation.NamedInstance.Instance

Gets or sets the instance.


### P:DNX.Helpers.Strings.Interpolation.NamedInstance.Name

Gets or sets the name.


## T:DNX.Helpers.Strings.Interpolation.StringInterpolator

StringInterpolator to simulate and extend named string interpolation available in C# 6.0


### M:DNX.Helpers.Strings.Interpolation.StringInterpolator.BuildParameterValuesForNamedInstance(System.Collections.Generic.IDictionary{System.String,System.Object},System.String,System.Object,System.String)

Builds the parameter values for named instance.

| Name | Description |
| ---- | ----------- |
| parameterValues | *Unknown type*<br>The parameter values. |
| format | *Unknown type*<br>The format. |
| instance | *System.Object*<br>The instance. |
| namePrefix | *System.String*<br>The name prefix. |


#### Returns

System.String.


### M:DNX.Helpers.Strings.Interpolation.StringInterpolator.GetInterpolatableProperties(type)

Gets the list of interpolatable properties from a type

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br>The type. |


#### Returns

IList<InterpolatableProperty>.


### M:DNX.Helpers.Strings.Interpolation.StringInterpolator.InterpolateWith(text, instance, namePrefix, ignoreErrors)

Interpolates the text with the optionally named instance

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| instance | *System.Object*<br>The instance. |
| namePrefix | *System.String*<br>The name prefix. |
| ignoreErrors | *System.Boolean*<br>if set to true [ignore errors]. |


#### Returns

System.String.


### M:DNX.Helpers.Strings.Interpolation.StringInterpolator.InterpolateWithAll(text, namedInstances, ignoreErrors)

Interpolates text with properties from a list of object instances

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| namedInstances | *System.Collections.Generic.IList{DNX.Helpers.Strings.Interpolation.NamedInstance}*<br>The named instances. |
| ignoreErrors | *System.Boolean*<br>if set to true [ignore errors]. |


#### Returns

System.String.


## T:DNX.Helpers.Strings.RegexStringExtensions

Regex String Extensions.


### M:DNX.Helpers.Strings.RegexStringExtensions.GetGroupName(regex, index)

Gets the name of the group.

| Name | Description |
| ---- | ----------- |
| regex | *System.Text.RegularExpressions.Regex*<br>The regex. |
| index | *System.Int32*<br>The index. |


#### Returns

System.String.


### M:DNX.Helpers.Strings.RegexStringExtensions.ParseFirstMatchToDictionary(input, regExpression)

Parses the first match to dictionary.

| Name | Description |
| ---- | ----------- |
| input | *System.String*<br>The input. |
| regExpression | *System.String*<br>The regular expression. |


#### Returns

Dictionary<System.String, System.String>.


### M:DNX.Helpers.Strings.RegexStringExtensions.ParseToDictionary(input, regExpression, keyGroupName, valueGroupName)

Parses to dictionary.

| Name | Description |
| ---- | ----------- |
| input | *System.Collections.Generic.IEnumerable{System.String}*<br>The input. |
| regExpression | *System.String*<br>The reg expression. |
| keyGroupName | *System.String*<br>Name of the key group. |
| valueGroupName | *System.String*<br>Name of the value group. |


#### Returns

Dictionary<System.String, System.String>.


### M:DNX.Helpers.Strings.RegexStringExtensions.ParseToDictionaryList(input, regExpression)

Parses to a list of dictionaries.

| Name | Description |
| ---- | ----------- |
| input | *System.String*<br>The input. |
| regExpression | *System.String*<br>The reg expression. |


#### Returns

List<Dictionary<System.String, System.String>>.


### M:DNX.Helpers.Strings.RegexStringExtensions.ParseToKeyValuePair(input, regExpression, keyGroupName, valueGroupName)

Parses to key value pair.

| Name | Description |
| ---- | ----------- |
| input | *System.String*<br>The input. |
| regExpression | *System.String*<br>The reg expression. |
| keyGroupName | *System.String*<br>Name of the key group. |
| valueGroupName | *System.String*<br>Name of the value group. |


#### Returns

KeyValuePair<System.String, System.String>.


## T:DNX.Helpers.Strings.StringExtensions

String Extensions


### M:DNX.Helpers.Strings.StringExtensions.BuildNumberValidationRegexForCulture(cultureInfo)

Builds the number validation regex for the specified cultureinfo

| Name | Description |
| ---- | ----------- |
| cultureInfo | *System.Globalization.CultureInfo*<br>The culture information. |


#### Returns

System.String.


### M:DNX.Helpers.Strings.StringExtensions.CoalesceNull(strings)

Coalesces the list of strings to find the first not null

| Name | Description |
| ---- | ----------- |
| strings | *System.Collections.Generic.IList{System.String}*<br>The strings. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.CoalesceNull(strings)

Coalesces the list of strings to find the first not null

| Name | Description |
| ---- | ----------- |
| strings | *System.String[]*<br>The strings. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.CoalesceNullOrEmpty(strings)

Coalesces the list of strings to find the first not null or empty.

| Name | Description |
| ---- | ----------- |
| strings | *System.Collections.Generic.IList{System.String}*<br>The strings. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.CoalesceNullOrEmpty(strings)

Coalesces the list of strings to find the first not null or empty.

| Name | Description |
| ---- | ----------- |
| strings | *System.String[]*<br>The strings. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.CoalesceNullOrWhitespace(strings)

Coalesces the list of strings to find the first not null or whitespace.

| Name | Description |
| ---- | ----------- |
| strings | *System.Collections.Generic.IList{System.String}*<br>The strings. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.CoalesceNullOrWhitespace(strings)

Coalesces the list of strings to find the first not null or whitespace.

| Name | Description |
| ---- | ----------- |
| strings | *System.String[]*<br>The strings. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.ContainsOnly(text, characters)

Determines whether text contains only the specified characters.

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| characters | *System.Collections.Generic.IList{System.Char}*<br>The characters. |


#### Returns

System.Boolean.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.ContainsOnly(text, characters)

Determines whether text contains only the specified characters.

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| characters | *System.String*<br>The characters. |


#### Returns

true if the specified characters contains only; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.ContainsText(text, searchText, comparison)

Determines whether the text contains the specified search text.

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| searchText | *System.String*<br>The search text. |
| comparison | *System.StringComparison*<br>The comparison. |


#### Returns

true if the specified search text contains text; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.EnsureEndsWith(text, suffix)

Ensures a string ends with a suffix string.

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| suffix | *System.String*<br>The suffix. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.EnsureStartsAndEndsWith(text, prefixsuffix)

Ensures a string starts and ends with a prefix / suffix string.

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| prefixsuffix | *System.String*<br>The prefix / suffix. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.EnsureStartsAndEndsWith(text, prefix, suffix)

Ensures a string starts a prefix string and ends with a suffix string.

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| prefix | *System.String*<br>The prefix. |
| suffix | *System.String*<br>The suffix. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.EnsureStartsWith(text, prefix)

Ensure a string starts with a prefix string

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br> |
| prefix | *System.String*<br> |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.IsValidNumber(text)

Determines whether the specified text is numeric conforming to the current Culture NumberFormat.

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

true if the specified culture information is numeric; otherwise, false.


### M:DNX.Helpers.Strings.StringExtensions.IsValidNumber(text, cultureInfo)

Determines whether the specified text is numeric conforming to the specified Culture NumberFormat.

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| cultureInfo | *System.Globalization.CultureInfo*<br>The culture information. |


#### Returns

true if the specified culture information is numeric; otherwise, false.


### M:DNX.Helpers.Strings.StringExtensions.RemoveAny(text, charsToRemove)

Removes any of the specified characters from a string

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| charsToRemove | *System.Char[]*<br>The chars to remove. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.RemoveAny(text, charsToRemove)

Removes any of the specified characters from a string

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| charsToRemove | *System.String*<br>The chars to remove. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.RemoveAnyExcept(text, charsToKeep)

Removes any characters from a string so that only instances of the specified characters remain

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| charsToKeep | *System.Collections.Generic.IList{System.Char}*<br>The chars to keep. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.RemoveAnyExcept(text, charsToKeep)

Removes any characters from a string so that only instances of the specified characters remain

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| charsToKeep | *System.String*<br>The chars to keep. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.RemoveEndsWith(text, suffix)

Ensures a string does not end with a suffix string

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| suffix | *System.String*<br>The suffix. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.RemoveStartsAndEndsWith(text, prefixsuffix)

Ensures a string does not start or end with a prefix / suffix string

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| prefixsuffix | *System.String*<br>The prefix and suffix. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.RemoveStartsAndEndsWith(text, prefix, suffix)

Ensures a string does not start with a prefix string or end with a suffix string

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| prefix | *System.String*<br>The prefix. |
| suffix | *System.String*<br>The suffix. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.RemoveStartsWith(text, prefix)

Ensures a string does not start with a prefix string

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| prefix | *System.String*<br>The prefix. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.Reverse(text)

Reverses the specified text.

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.Split(text, delimiters, options)

Splits the text by the specified delimiters.

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| delimiters | *System.String*<br>The delimiters. |
| options | *System.StringSplitOptions*<br>The options. |


#### Returns

IEnumerable<System.String>.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Strings.StringExtensions.SplitByText(text, delimiterText, options, comparison)

Splits the text by the specified text string.

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text. |
| delimiterText | *System.String*<br>The delimiter text. |
| options | *System.StringSplitOptions*<br>The options. |
| comparison | *System.StringComparison*<br>The comparison. |


#### Returns

IEnumerable<System.String>.


## T:DNX.Helpers.Threading.IProducerConsumerQueue`1

Interface IProducerConsumerQueue


### M:DNX.Helpers.Threading.IProducerConsumerQueue`1.AddItem(item)

Add an item to the Queue to be processed

| Name | Description |
| ---- | ----------- |
| item | *`0*<br>The item to be queued. |

### M:DNX.Helpers.Threading.IProducerConsumerQueue`1.AddItems(items)

Adds a batch of items to the Queue to be processed

| Name | Description |
| ---- | ----------- |
| items | *`0[]*<br>The items to be queued. |

### M:DNX.Helpers.Threading.IProducerConsumerQueue`1.Clear

Clear the Queue of all items


### P:DNX.Helpers.Threading.IProducerConsumerQueue`1.Comparer

A Comparer to use if the Queue is to be ordered


## T:DNX.Helpers.Threading.Mutexes.Mutex

Class Mutex.


### M:DNX.Helpers.Threading.Mutexes.Mutex.#ctor(name)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>The name. |

### M:DNX.Helpers.Threading.Mutexes.Mutex.#ctor(name, lockObject)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>The name. |
| lockObject | *System.Object*<br>The lock object. |

### M:DNX.Helpers.Threading.Mutexes.Mutex.Dispose

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.


### P:DNX.Helpers.Threading.Mutexes.Mutex.LockObject

Gets or sets the lock object.


### P:DNX.Helpers.Threading.Mutexes.Mutex.Name

Gets the name.


### P:DNX.Helpers.Threading.Mutexes.Mutex.State

Gets the state.


### P:DNX.Helpers.Threading.Mutexes.Mutex.ThreadId

Gets the thread identifier.


### P:DNX.Helpers.Threading.Mutexes.Mutex.Timestamp

Gets the timestamp.


## T:DNX.Helpers.Threading.Mutexes.MutexManager

Class MutexManager.


### M:DNX.Helpers.Threading.Mutexes.MutexManager.#cctor

Initializes a new instance of the class.


### M:DNX.Helpers.Threading.Mutexes.MutexManager.Acquire(name)

Acquires a named Mutex waiting for it to become available

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>The name. |


#### Returns

Mutex.


### M:DNX.Helpers.Threading.Mutexes.MutexManager.AcquireNoWait(name)

Acquires a named Mutex or returns null immediately if unable

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>The name. |


#### Returns

DNX.Helpers.Threading.Mutexes.Mutex.


### M:DNX.Helpers.Threading.Mutexes.MutexManager.CanAcquire(name)

Determines whether the named Mutex could be acquired

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>The name. |


#### Returns

true if this instance can acquire the specified name; otherwise, false.


### P:DNX.Helpers.Threading.Mutexes.MutexManager.Mutexes

Gets the mutexes.


### F:DNX.Helpers.Threading.Mutexes.MutexManager.MutexManagerLocker

The locker


## T:DNX.Helpers.Threading.Mutexes.MutexState

The waiting


### F:DNX.Helpers.Threading.Mutexes.MutexState.Acquired

Lock acquired


### F:DNX.Helpers.Threading.Mutexes.MutexState.Released

Lock released


### F:DNX.Helpers.Threading.Mutexes.MutexState.Waiting

Waiting to acquire a lock


## T:DNX.Helpers.Threading.ParameterizedThreadStart`1

Generic parameterized delegate.

| Name | Description |
| ---- | ----------- |
| value | *System.UInt64*<br>The strongly typed value to pass to the method. |

## T:DNX.Helpers.Threading.ProducerConsumerQueue`1

Generic Producer/Consumer Queue object


#### Remarks

Provides virtual methods hooks to allow a descendant class to vary the behaviour.Allows an to process queued items in a defined order.Abstract to allow implementor to provide ProcessItem method to handle a queued item.


### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.#ctor

Default Constructor


### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.#ctor(autoCleanup)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| autoCleanup | *System.Boolean*<br>if set to true items will be automatically disposed. |

### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.#ctor(autoCleanup, timeout, comparer)

Constructor accepting a Wake timeout and a Comparer (for Ordered Queue)

| Name | Description |
| ---- | ----------- |
| autoCleanup | *System.Boolean*<br>if set to true [auto cleanup]. |
| timeout | *System.TimeSpan*<br>The timeout. |
| comparer | *System.Collections.Generic.IComparer{`0}*<br>The comparer. |

### F:DNX.Helpers.Threading.ProducerConsumerQueue`1._executingItems

The currently executing items


### F:DNX.Helpers.Threading.ProducerConsumerQueue`1._lockerExecuting

Locking control object to regulate access to the process executing count.


### F:DNX.Helpers.Threading.ProducerConsumerQueue`1._lockerQueue

Locking control object to regulate access to the queue objects


### F:DNX.Helpers.Threading.ProducerConsumerQueue`1._queuedItems

The queued items


### F:DNX.Helpers.Threading.ProducerConsumerQueue`1._waitHandle

WaitHandle for synchronising threads


### F:DNX.Helpers.Threading.ProducerConsumerQueue`1._workerThread

Queue processor thread


### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.AddItem(item)

Queue an item to be processed

| Name | Description |
| ---- | ----------- |
| item | *`0*<br>The item to be added. |


#### Remarks

 Public interface. Validates item to be a valid instance. 


### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.AddItems(items)

Adds a batch of items to the Queue to be processed

| Name | Description |
| ---- | ----------- |
| items | *`0[]*<br>The items. |

### P:DNX.Helpers.Threading.ProducerConsumerQueue`1.AutoCleanupItems

Gets or sets a value indicating whether items are automatically disposed.


### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.CanHandleItemNow(item)

Hook to determine if we can handle the item yet.

| Name | Description |
| ---- | ----------- |
| item | *`0*<br>The item about to be handled |


#### Returns

 true/false - depending on whether we can handle the item yet or not 


#### Remarks

 Allows implementor to create custom lists (not just queues) based around the Producer/Consumer pattern 


### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.Clear

Remove all items from the Queue


### P:DNX.Helpers.Threading.ProducerConsumerQueue`1.Comparer

The Comparer to use when ordering Queued items


#### Remarks

 Specify NULL for a regular FIFO queue 


### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.Describe(ex)

Describes the specified exception.

| Name | Description |
| ---- | ----------- |
| ex | *System.Exception*<br>The exception. |


#### Returns

A text representation of the Exception


### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.Dispose

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.


### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.EnqueueItem(item)

Queue an item to be processed

| Name | Description |
| ---- | ----------- |
| item | *`0*<br>The item to be queued. |


#### Remarks

 Internal use only. 


### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.EnqueueItems(items)

Queue a batch of items to be processed

| Name | Description |
| ---- | ----------- |
| items | *System.Collections.Generic.IReadOnlyCollection{`0}*<br>The items. |


#### Remarks

 Internal use only. 


### P:DNX.Helpers.Threading.ProducerConsumerQueue`1.ExecutingCount

Gets the executing count.


### P:DNX.Helpers.Threading.ProducerConsumerQueue`1.ExecutingItems

Gets the executing items.


### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.HandleItem(item)

Queue processor to handle an item when it gets to the front of the queue.

| Name | Description |
| ---- | ----------- |
| item | *`0*<br>The item to be handled |


#### Remarks

 Performs any processing required prior to calling specific implementor of ProcessItem 


### P:DNX.Helpers.Threading.ProducerConsumerQueue`1.IsExecuting

Gets a value indicating whether this instance is executing.


### P:DNX.Helpers.Threading.ProducerConsumerQueue`1.IsTimed

Gets a value indicating whether this queue operates on a timeout.


### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.ItemAdded(item)

Hook called when an item has been added to the queue.

| Name | Description |
| ---- | ----------- |
| item | *`0*<br>The item just added. |

### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.ItemComplete(item)

Hook called when an item has been processed

| Name | Description |
| ---- | ----------- |
| item | *`0*<br>The item just successfully processed |

### P:DNX.Helpers.Threading.ProducerConsumerQueue`1.Items

Gets the items.


### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.ProcessItem(item)

Abstract method for processing a queued item after being picked up by the Queue handler

| Name | Description |
| ---- | ----------- |
| item | *`0*<br>The item to be processed |

### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.StartExecuting(item)

Adds the item to the executing items list.

| Name | Description |
| ---- | ----------- |
| item | *`0*<br>The item to add. |

### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.StopExecuting(item)

Removes the item from the executing items list.


#### Remarks

 Also performs cleanup of the item, if necessary 

| Name | Description |
| ---- | ----------- |
| item | *`0*<br>The item to remove. |

### P:DNX.Helpers.Threading.ProducerConsumerQueue`1.Timeout

Gets the timeout.


### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.WaitForConsumersToComplete

Waits for consumers to complete.


### M:DNX.Helpers.Threading.ProducerConsumerQueue`1.Work

Queue handler thread method for dealing with queued items


## T:DNX.Helpers.Threading.ProducerConsumerQueueAction`1

Class ProducerConsumerQueueAction.


### M:DNX.Helpers.Threading.ProducerConsumerQueueAction`1.#ctor(action)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| action | *System.Action{`0}*<br>The action. |

### M:DNX.Helpers.Threading.ProducerConsumerQueueAction`1.#ctor(action, autoCleanUp)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| action | *System.Action{`0}*<br>The action. |
| autoCleanUp | *System.Boolean*<br>if set to true [automatic clean up]. |

### M:DNX.Helpers.Threading.ProducerConsumerQueueAction`1.#ctor(action, autoCleanUp, timeout, comparer)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| action | *System.Action{`0}*<br>The action. |
| autoCleanUp | *System.Boolean*<br>if set to true [automatic clean up]. |
| timeout | *System.TimeSpan*<br>The timeout. |
| comparer | *System.Collections.Generic.IComparer{`0}*<br>The comparer. |

### F:DNX.Helpers.Threading.ProducerConsumerQueueAction`1._action

The action


### M:DNX.Helpers.Threading.ProducerConsumerQueueAction`1.ProcessItem(item)

Method for processing a queued item after being picked up by the Queue handler

| Name | Description |
| ---- | ----------- |
| item | *`0*<br>The item to be processed |

## T:DNX.Helpers.Threading.ThreadHelper

Helper class for Thread operations


### M:DNX.Helpers.Threading.ThreadHelper.Start(start)

Creates and starts a new Thread.

| Name | Description |
| ---- | ----------- |
| start | *System.Threading.ThreadStart*<br>ThreadStart delegate. |


#### Returns

The Thread instance.


### M:DNX.Helpers.Threading.ThreadHelper.Start``1(start, value)

Creates and starts a new Thread which runs the parameterized delegate.

| Name | Description |
| ---- | ----------- |
| start | *DNX.Helpers.Threading.ParameterizedThreadStart{``0}*<br>The generic delegate. |
| value | *``0*<br>The type to pass to delegate. |


#### Returns

The Thread instance.


### M:DNX.Helpers.Threading.ThreadHelper.StartOnThreadPool(start)

Queues a delegate to run on a thread pool thread.

| Name | Description |
| ---- | ----------- |
| start | *System.Threading.ThreadStart*<br>ThreadStart delegate. |


#### Returns

True if the delegate is queued successfully; False otherwise 


### M:DNX.Helpers.Threading.ThreadHelper.StartOnThreadPool``1(start, value)

Queues a delegate to run on a thread pool thread.

| Name | Description |
| ---- | ----------- |
| start | *DNX.Helpers.Threading.ParameterizedThreadStart{``0}*<br>The generic delegate. |
| value | *``0*<br>The type to pass to delegate. |


#### Returns

True if the delegate is queued successfully; False otherwise 


## T:DNX.Helpers.Validation.BuiltInTypes.Guard

Guard Extensions.

Guard Extensions.

Guard Extensions.

Guard Extensions.

Guard Extensions.

Guard Extensions.

Guard Extensions.

Guard Extensions.

Guard Extensions.

Guard Extensions.

Guard Extensions.

Guard Extensions.


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Byte}}*<br>The linq expression of the argument to check |
| min | *System.Byte*<br>minimum allowed value |
| max | *System.Byte*<br>maximum allowed value |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Byte}}*<br>The exp. |
| min | *System.Byte*<br>The minimum. |
| max | *System.Byte*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Byte}}*<br>The exp. |
| bound1 | *System.Byte*<br>The bound1. |
| bound2 | *System.Byte*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, val, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Byte}}*<br>The exp. |
| val | *System.Byte*<br>The value. |
| bound1 | *System.Byte*<br>The bound1. |
| bound2 | *System.Byte*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

*System.ArgumentOutOfRangeException:* 

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.DateTime}}*<br>The linq expression of the argument to check |
| min | *System.DateTime*<br>minimum allowed value |
| max | *System.DateTime*<br>maximum allowed value |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.DateTime}}*<br>The exp. |
| min | *System.DateTime*<br>The minimum. |
| max | *System.DateTime*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.DateTime}}*<br>The exp. |
| bound1 | *System.DateTime*<br>The bound1. |
| bound2 | *System.DateTime*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, val, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.DateTime}}*<br>The exp. |
| val | *System.DateTime*<br>The value. |
| bound1 | *System.DateTime*<br>The bound1. |
| bound2 | *System.DateTime*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

*System.ArgumentOutOfRangeException:* 

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Decimal}}*<br>The linq expression of the argument to check |
| min | *System.Decimal*<br>minimum allowed value |
| max | *System.Decimal*<br>maximum allowed value |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Decimal}}*<br>The exp. |
| min | *System.Decimal*<br>The minimum. |
| max | *System.Decimal*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Decimal}}*<br>The exp. |
| bound1 | *System.Decimal*<br>The bound1. |
| bound2 | *System.Decimal*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, val, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Decimal}}*<br>The exp. |
| val | *System.Decimal*<br>The value. |
| bound1 | *System.Decimal*<br>The bound1. |
| bound2 | *System.Decimal*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

*System.ArgumentOutOfRangeException:* 

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Double}}*<br>The linq expression of the argument to check |
| min | *System.Double*<br>minimum allowed value |
| max | *System.Double*<br>maximum allowed value |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Double}}*<br>The exp. |
| min | *System.Double*<br>The minimum. |
| max | *System.Double*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Double}}*<br>The exp. |
| bound1 | *System.Double*<br>The bound1. |
| bound2 | *System.Double*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, val, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Double}}*<br>The exp. |
| val | *System.Double*<br>The value. |
| bound1 | *System.Double*<br>The bound1. |
| bound2 | *System.Double*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

*System.ArgumentOutOfRangeException:* 

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int16}}*<br>The linq expression of the argument to check |
| min | *System.Int16*<br>minimum allowed value |
| max | *System.Int16*<br>maximum allowed value |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int16}}*<br>The exp. |
| min | *System.Int16*<br>The minimum. |
| max | *System.Int16*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int16}}*<br>The exp. |
| bound1 | *System.Int16*<br>The bound1. |
| bound2 | *System.Int16*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, val, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int16}}*<br>The exp. |
| val | *System.Int16*<br>The value. |
| bound1 | *System.Int16*<br>The bound1. |
| bound2 | *System.Int16*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

*System.ArgumentOutOfRangeException:* 

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int32}}*<br>The linq expression of the argument to check |
| min | *System.Int32*<br>minimum allowed value |
| max | *System.Int32*<br>maximum allowed value |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int32}}*<br>The exp. |
| min | *System.Int32*<br>The minimum. |
| max | *System.Int32*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int32}}*<br>The exp. |
| bound1 | *System.Int32*<br>The bound1. |
| bound2 | *System.Int32*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, val, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int32}}*<br>The exp. |
| val | *System.Int32*<br>The value. |
| bound1 | *System.Int32*<br>The bound1. |
| bound2 | *System.Int32*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

*System.ArgumentOutOfRangeException:* 

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int64}}*<br>The linq expression of the argument to check |
| min | *System.Int64*<br>minimum allowed value |
| max | *System.Int64*<br>maximum allowed value |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int64}}*<br>The exp. |
| min | *System.Int64*<br>The minimum. |
| max | *System.Int64*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int64}}*<br>The exp. |
| bound1 | *System.Int64*<br>The bound1. |
| bound2 | *System.Int64*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, val, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int64}}*<br>The exp. |
| val | *System.Int64*<br>The value. |
| bound1 | *System.Int64*<br>The bound1. |
| bound2 | *System.Int64*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

*System.ArgumentOutOfRangeException:* 

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.SByte}}*<br>The linq expression of the argument to check |
| min | *System.SByte*<br>minimum allowed value |
| max | *System.SByte*<br>maximum allowed value |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.SByte}}*<br>The exp. |
| min | *System.SByte*<br>The minimum. |
| max | *System.SByte*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.SByte}}*<br>The exp. |
| bound1 | *System.SByte*<br>The bound1. |
| bound2 | *System.SByte*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, val, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.SByte}}*<br>The exp. |
| val | *System.SByte*<br>The value. |
| bound1 | *System.SByte*<br>The bound1. |
| bound2 | *System.SByte*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

*System.ArgumentOutOfRangeException:* 

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Single}}*<br>The linq expression of the argument to check |
| min | *System.Single*<br>minimum allowed value |
| max | *System.Single*<br>maximum allowed value |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Single}}*<br>The exp. |
| min | *System.Single*<br>The minimum. |
| max | *System.Single*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Single}}*<br>The exp. |
| bound1 | *System.Single*<br>The bound1. |
| bound2 | *System.Single*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, val, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Single}}*<br>The exp. |
| val | *System.Single*<br>The value. |
| bound1 | *System.Single*<br>The bound1. |
| bound2 | *System.Single*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

*System.ArgumentOutOfRangeException:* 

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt16}}*<br>The linq expression of the argument to check |
| min | *System.UInt16*<br>minimum allowed value |
| max | *System.UInt16*<br>maximum allowed value |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt16}}*<br>The exp. |
| min | *System.UInt16*<br>The minimum. |
| max | *System.UInt16*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt16}}*<br>The exp. |
| bound1 | *System.UInt16*<br>The bound1. |
| bound2 | *System.UInt16*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, val, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt16}}*<br>The exp. |
| val | *System.UInt16*<br>The value. |
| bound1 | *System.UInt16*<br>The bound1. |
| bound2 | *System.UInt16*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

*System.ArgumentOutOfRangeException:* 

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt32}}*<br>The linq expression of the argument to check |
| min | *System.UInt32*<br>minimum allowed value |
| max | *System.UInt32*<br>maximum allowed value |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt32}}*<br>The exp. |
| min | *System.UInt32*<br>The minimum. |
| max | *System.UInt32*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt32}}*<br>The exp. |
| bound1 | *System.UInt32*<br>The bound1. |
| bound2 | *System.UInt32*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, val, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt32}}*<br>The exp. |
| val | *System.UInt32*<br>The value. |
| bound1 | *System.UInt32*<br>The bound1. |
| bound2 | *System.UInt32*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

*System.ArgumentOutOfRangeException:* 

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt64}}*<br>The linq expression of the argument to check |
| min | *System.UInt64*<br>minimum allowed value |
| max | *System.UInt64*<br>maximum allowed value |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, min, max, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt64}}*<br>The exp. |
| min | *System.UInt64*<br>The minimum. |
| max | *System.UInt64*<br>The maximum. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt64}}*<br>The exp. |
| bound1 | *System.UInt64*<br>The bound1. |
| bound2 | *System.UInt64*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsBetween(exp, val, bound1, bound2, allowEitherOrder, boundsType)

Ensures the expression and corresponding value evaluates to between the specified values

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt64}}*<br>The exp. |
| val | *System.UInt64*<br>The value. |
| bound1 | *System.UInt64*<br>The bound1. |
| bound2 | *System.UInt64*<br>The bound2. |
| allowEitherOrder | *System.Boolean*<br>if set to true [allow either order]. |
| boundsType | *DNX.Helpers.Maths.IsBetweenBoundsType*<br>Type of the bounds. |

*System.ArgumentOutOfRangeException:* 

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, min)

Ensures the expression evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Byte}}*<br>The exp. |
| min | *System.Byte*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Byte}}*<br>The exp. |
| val | *System.Byte*<br>The value. |
| min | *System.Byte*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, min)

Ensures the expression evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.DateTime}}*<br>The exp. |
| min | *System.DateTime*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.DateTime}}*<br>The exp. |
| val | *System.DateTime*<br>The value. |
| min | *System.DateTime*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, min)

Ensures the expression evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Decimal}}*<br>The exp. |
| min | *System.Decimal*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Decimal}}*<br>The exp. |
| val | *System.Decimal*<br>The value. |
| min | *System.Decimal*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, min)

Ensures the expression evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Double}}*<br>The exp. |
| min | *System.Double*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Double}}*<br>The exp. |
| val | *System.Double*<br>The value. |
| min | *System.Double*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, min)

Ensures the expression evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int16}}*<br>The exp. |
| min | *System.Int16*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int16}}*<br>The exp. |
| val | *System.Int16*<br>The value. |
| min | *System.Int16*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, min)

Ensures the expression evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int32}}*<br>The exp. |
| min | *System.Int32*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int32}}*<br>The exp. |
| val | *System.Int32*<br>The value. |
| min | *System.Int32*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, min)

Ensures the expression evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int64}}*<br>The exp. |
| min | *System.Int64*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int64}}*<br>The exp. |
| val | *System.Int64*<br>The value. |
| min | *System.Int64*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, min)

Ensures the expression evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.SByte}}*<br>The exp. |
| min | *System.SByte*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.SByte}}*<br>The exp. |
| val | *System.SByte*<br>The value. |
| min | *System.SByte*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, min)

Ensures the expression evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Single}}*<br>The exp. |
| min | *System.Single*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Single}}*<br>The exp. |
| val | *System.Single*<br>The value. |
| min | *System.Single*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, min)

Ensures the expression evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt16}}*<br>The exp. |
| min | *System.UInt16*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt16}}*<br>The exp. |
| val | *System.UInt16*<br>The value. |
| min | *System.UInt16*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, min)

Ensures the expression evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt32}}*<br>The exp. |
| min | *System.UInt32*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt32}}*<br>The exp. |
| val | *System.UInt32*<br>The value. |
| min | *System.UInt32*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, min)

Ensures the expression evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt64}}*<br>The exp. |
| min | *System.UInt64*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThan(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt64}}*<br>The exp. |
| val | *System.UInt64*<br>The value. |
| min | *System.UInt64*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, min)

Ensures the expression evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Byte}}*<br>The exp. |
| min | *System.Byte*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Byte}}*<br>The exp. |
| val | *System.Byte*<br>The value. |
| min | *System.Byte*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, min)

Ensures the expression evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.DateTime}}*<br>The exp. |
| min | *System.DateTime*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.DateTime}}*<br>The exp. |
| val | *System.DateTime*<br>The value. |
| min | *System.DateTime*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, min)

Ensures the expression evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Decimal}}*<br>The exp. |
| min | *System.Decimal*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Decimal}}*<br>The exp. |
| val | *System.Decimal*<br>The value. |
| min | *System.Decimal*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, min)

Ensures the expression evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Double}}*<br>The exp. |
| min | *System.Double*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Double}}*<br>The exp. |
| val | *System.Double*<br>The value. |
| min | *System.Double*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, min)

Ensures the expression evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int16}}*<br>The exp. |
| min | *System.Int16*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int16}}*<br>The exp. |
| val | *System.Int16*<br>The value. |
| min | *System.Int16*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, min)

Ensures the expression evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int32}}*<br>The exp. |
| min | *System.Int32*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int32}}*<br>The exp. |
| val | *System.Int32*<br>The value. |
| min | *System.Int32*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, min)

Ensures the expression evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int64}}*<br>The exp. |
| min | *System.Int64*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int64}}*<br>The exp. |
| val | *System.Int64*<br>The value. |
| min | *System.Int64*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, min)

Ensures the expression evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.SByte}}*<br>The exp. |
| min | *System.SByte*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.SByte}}*<br>The exp. |
| val | *System.SByte*<br>The value. |
| min | *System.SByte*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, min)

Ensures the expression evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Single}}*<br>The exp. |
| min | *System.Single*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Single}}*<br>The exp. |
| val | *System.Single*<br>The value. |
| min | *System.Single*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, min)

Ensures the expression evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt16}}*<br>The exp. |
| min | *System.UInt16*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt16}}*<br>The exp. |
| val | *System.UInt16*<br>The value. |
| min | *System.UInt16*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, min)

Ensures the expression evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt32}}*<br>The exp. |
| min | *System.UInt32*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt32}}*<br>The exp. |
| val | *System.UInt32*<br>The value. |
| min | *System.UInt32*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, min)

Ensures the expression evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt64}}*<br>The exp. |
| min | *System.UInt64*<br>The minimum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsGreaterThanOrEqualTo(exp, val, min)

Ensures the expression and corresponding value evaluates to greater than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt64}}*<br>The exp. |
| val | *System.UInt64*<br>The value. |
| min | *System.UInt64*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, max)

Ensures the expression evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Byte}}*<br>The exp. |
| max | *System.Byte*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, val, max)

Ensures the expression and corresponding value evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Byte}}*<br>The exp. |
| val | *System.Byte*<br>The value. |
| max | *System.Byte*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, max)

Ensures the expression evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.DateTime}}*<br>The exp. |
| max | *System.DateTime*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, val, max)

Ensures the expression and corresponding value evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.DateTime}}*<br>The exp. |
| val | *System.DateTime*<br>The value. |
| max | *System.DateTime*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, max)

Ensures the expression evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Decimal}}*<br>The exp. |
| max | *System.Decimal*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, val, max)

Ensures the expression and corresponding value evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Decimal}}*<br>The exp. |
| val | *System.Decimal*<br>The value. |
| max | *System.Decimal*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, max)

Ensures the expression evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Double}}*<br>The exp. |
| max | *System.Double*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, val, max)

Ensures the expression and corresponding value evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Double}}*<br>The exp. |
| val | *System.Double*<br>The value. |
| max | *System.Double*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, max)

Ensures the expression evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int16}}*<br>The exp. |
| max | *System.Int16*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, val, max)

Ensures the expression and corresponding value evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int16}}*<br>The exp. |
| val | *System.Int16*<br>The value. |
| max | *System.Int16*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, max)

Ensures the expression evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int32}}*<br>The exp. |
| max | *System.Int32*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, val, max)

Ensures the expression and corresponding value evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int32}}*<br>The exp. |
| val | *System.Int32*<br>The value. |
| max | *System.Int32*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, max)

Ensures the expression evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int64}}*<br>The exp. |
| max | *System.Int64*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, val, max)

Ensures the expression and corresponding value evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int64}}*<br>The exp. |
| val | *System.Int64*<br>The value. |
| max | *System.Int64*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, max)

Ensures the expression evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.SByte}}*<br>The exp. |
| max | *System.SByte*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, val, max)

Ensures the expression and corresponding value evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.SByte}}*<br>The exp. |
| val | *System.SByte*<br>The value. |
| max | *System.SByte*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, max)

Ensures the expression evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Single}}*<br>The exp. |
| max | *System.Single*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, val, max)

Ensures the expression and corresponding value evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Single}}*<br>The exp. |
| val | *System.Single*<br>The value. |
| max | *System.Single*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, max)

Ensures the expression evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt16}}*<br>The exp. |
| max | *System.UInt16*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, val, max)

Ensures the expression and corresponding value evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt16}}*<br>The exp. |
| val | *System.UInt16*<br>The value. |
| max | *System.UInt16*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, max)

Ensures the expression evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt32}}*<br>The exp. |
| max | *System.UInt32*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, val, max)

Ensures the expression and corresponding value evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt32}}*<br>The exp. |
| val | *System.UInt32*<br>The value. |
| max | *System.UInt32*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, max)

Ensures the expression evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt64}}*<br>The exp. |
| max | *System.UInt64*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThan(exp, val, max)

Ensures the expression and corresponding value evaluates to less than the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt64}}*<br>The exp. |
| val | *System.UInt64*<br>The value. |
| max | *System.UInt64*<br>The minimum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, max)

Ensures the expression evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Byte}}*<br>The exp. |
| max | *System.Byte*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, val, max)

Ensures the expression and corresponding value evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Byte}}*<br>The exp. |
| val | *System.Byte*<br>The value. |
| max | *System.Byte*<br>The maximum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, max)

Ensures the expression evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.DateTime}}*<br>The exp. |
| max | *System.DateTime*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, val, max)

Ensures the expression and corresponding value evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.DateTime}}*<br>The exp. |
| val | *System.DateTime*<br>The value. |
| max | *System.DateTime*<br>The maximum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, max)

Ensures the expression evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Decimal}}*<br>The exp. |
| max | *System.Decimal*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, val, max)

Ensures the expression and corresponding value evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Decimal}}*<br>The exp. |
| val | *System.Decimal*<br>The value. |
| max | *System.Decimal*<br>The maximum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, max)

Ensures the expression evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Double}}*<br>The exp. |
| max | *System.Double*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, val, max)

Ensures the expression and corresponding value evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Double}}*<br>The exp. |
| val | *System.Double*<br>The value. |
| max | *System.Double*<br>The maximum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, max)

Ensures the expression evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int16}}*<br>The exp. |
| max | *System.Int16*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, val, max)

Ensures the expression and corresponding value evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int16}}*<br>The exp. |
| val | *System.Int16*<br>The value. |
| max | *System.Int16*<br>The maximum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, max)

Ensures the expression evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int32}}*<br>The exp. |
| max | *System.Int32*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, val, max)

Ensures the expression and corresponding value evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int32}}*<br>The exp. |
| val | *System.Int32*<br>The value. |
| max | *System.Int32*<br>The maximum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, max)

Ensures the expression evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int64}}*<br>The exp. |
| max | *System.Int64*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, val, max)

Ensures the expression and corresponding value evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Int64}}*<br>The exp. |
| val | *System.Int64*<br>The value. |
| max | *System.Int64*<br>The maximum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, max)

Ensures the expression evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.SByte}}*<br>The exp. |
| max | *System.SByte*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, val, max)

Ensures the expression and corresponding value evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.SByte}}*<br>The exp. |
| val | *System.SByte*<br>The value. |
| max | *System.SByte*<br>The maximum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, max)

Ensures the expression evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Single}}*<br>The exp. |
| max | *System.Single*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, val, max)

Ensures the expression and corresponding value evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Single}}*<br>The exp. |
| val | *System.Single*<br>The value. |
| max | *System.Single*<br>The maximum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, max)

Ensures the expression evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt16}}*<br>The exp. |
| max | *System.UInt16*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, val, max)

Ensures the expression and corresponding value evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt16}}*<br>The exp. |
| val | *System.UInt16*<br>The value. |
| max | *System.UInt16*<br>The maximum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, max)

Ensures the expression evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt32}}*<br>The exp. |
| max | *System.UInt32*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, val, max)

Ensures the expression and corresponding value evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt32}}*<br>The exp. |
| val | *System.UInt32*<br>The value. |
| max | *System.UInt32*<br>The maximum. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, max)

Ensures the expression evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt64}}*<br>The exp. |
| max | *System.UInt64*<br>The maximum. |

### M:DNX.Helpers.Validation.BuiltInTypes.Guard.IsLessThanOrEqualTo(exp, val, max)

Ensures the expression and corresponding value evaluates to less than or equal to the specified minimum

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.UInt64}}*<br>The exp. |
| val | *System.UInt64*<br>The value. |
| max | *System.UInt64*<br>The maximum. |

*System.ArgumentOutOfRangeException:* 


## T:DNX.Helpers.Validation.Guard

Guard Extensions.


### M:DNX.Helpers.Validation.Guard.IsEnumOneOf``1(exp, val, allowed)

Ensures the expression is a valid Enum value

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{``0}}*<br>The exp. |
| val | *``0*<br>The value. |
| allowed | *System.Collections.Generic.IList{``0}*<br>The allowed. |

*System.ArgumentException:* 


### M:DNX.Helpers.Validation.Guard.IsEnumOneOf``1(exp, allowed)

Ensures the expression is a valid Enum value

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{``0}}*<br>The exp. |
| allowed | *``0[]*<br>The allowed. |

### M:DNX.Helpers.Validation.Guard.IsEnumOneOf``1(exp, allowed)

Ensures the expression is a valid Enum value

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{``0}}*<br>The exp. |
| allowed | *System.Collections.Generic.IList{``0}*<br>The allowed. |

### M:DNX.Helpers.Validation.Guard.IsFalse(exp)

Ensures the specified exp is false.

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Boolean}}*<br>The exp. |

### M:DNX.Helpers.Validation.Guard.IsFalse(exp, val)

Ensures the specified exp is false.

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Boolean}}*<br>The exp. |
| val | *System.Boolean*<br>The value. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.Guard.IsNotNull``1(exp)

Ensures the specified exp is not null

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{``0}}*<br>The linq expression of the argument to check |

### M:DNX.Helpers.Validation.Guard.IsNotNull``1(exp, val)

Ensures the specified exp is not null

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{``0}}*<br>The linq expression of the argument to check |
| val | *``0*<br>value of argument in exp |


#### Remarks

Use this if you are not happy that the expression exp will be invoked more than once by your method.


### M:DNX.Helpers.Validation.Guard.IsNotNullOrEmpty(exp)

Ensures the specified exp is not null or empty

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.String}}*<br>The linq expression of the argument to check |

### M:DNX.Helpers.Validation.Guard.IsNotNullOrEmpty(exp, val)

Ensures the specified exp is not null or empty

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.String}}*<br>The linq expression of the argument to check |
| val | *System.String*<br>value of argument in exp |


#### Remarks

Use this if you are not happy that the expression exp will be invoked more than once by your method.


### M:DNX.Helpers.Validation.Guard.IsNotNullOrWhitespace(exp)

Ensures the specified exp is not null or whitespace

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.String}}*<br>The linq expression of the argument to check |

### M:DNX.Helpers.Validation.Guard.IsNotNullOrWhitespace(exp, val)

Ensures the specified exp is not null or whitespace

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.String}}*<br>The linq expression of the argument to check |
| val | *System.String*<br>value of argument in exp |


#### Remarks

Use this if you are not happy that the expression exp will be invoked more than once by your method.


### M:DNX.Helpers.Validation.Guard.IsTrue(exp)

Ensures the specified exp is true.

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Boolean}}*<br>The exp. |

### M:DNX.Helpers.Validation.Guard.IsTrue(exp, val)

Ensures the specified exp is true.

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{System.Boolean}}*<br>The exp. |
| val | *System.Boolean*<br>The value. |

*System.ArgumentOutOfRangeException:* 


### M:DNX.Helpers.Validation.Guard.IsValidEnum``1(exp)

Ensures the expression is a valid Enum value

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{``0}}*<br>The exp. |

### M:DNX.Helpers.Validation.Guard.IsValidEnum``1(exp, val)

Ensures the expression is a valid Enum value

| Name | Description |
| ---- | ----------- |
| exp | *System.Linq.Expressions.Expression{System.Func{``0}}*<br>The exp. |
| val | *``0*<br>The value. |

*System.ArgumentException:* 


## T:DNX.Helpers.Validation.TypeExtensions

Type Extensions.


### M:DNX.Helpers.Validation.TypeExtensions.CreateDefaultInstance(type)

Gets a default instance.

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br>The type. |


#### Returns

System.Object.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Validation.TypeExtensions.CreateDefaultInstance``1

Gets a default instance.


#### Returns

System.Object.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Validation.TypeExtensions.GetDefaultValue(type)

Gets the default value.

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br>The type. |


#### Returns

System.Object.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.Validation.TypeExtensions.IsA(type, baseClassOrInterface)

Determines whether the specified type is a.

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br>The type. |
| baseClassOrInterface | *System.Type*<br>The base class or interface. |


#### Returns

System.Boolean.


### M:DNX.Helpers.Validation.TypeExtensions.IsA``1(type)

Determines whether the specified type is a.

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br>The type. |


#### Returns

true if the specified type is a; otherwise, false.


### M:DNX.Helpers.Validation.TypeExtensions.IsNullable(type)

Determines whether the specified type is nullable.

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br>The type. |


#### Returns

true if the specified type is nullable; otherwise, false.


#### Remarks

Also available as an extension method


