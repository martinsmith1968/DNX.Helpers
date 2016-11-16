
# DNX.Helpers


## Converters.ConvertExtensions

Conversion Extensions.


### M:DNX.Helpers.IsInt(text)

Determines if the string can be converted to an int or not

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |


#### Returns

true if the specified text is an int; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.IsLong(text)

Determines if the string can be converted to a long or not

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |


#### Returns

true if the specified text is a long; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.IsShort(text)

Determines if the string can be converted to a short or not

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |


#### Returns

true if the specified text is a short; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.ToInt(text)

Converts the string to an int

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |


#### Returns

System.Int32.

*Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.ToInt(text, defaultValue)

Converts the string to an int, or returns the default value if the conversion fails

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |
| defaultValue | *System.Int32* | The default value. |


#### Returns

System.Int32.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.ToLong(text)

Converts the string to a long

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |


#### Returns

System.Int64.

*Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.ToLong(text, defaultValue)

Converts the string to a long, or returns the default value if the conversion fails

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |
| defaultValue | *System.Int64* | The default value. |


#### Returns

System.Int64.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.ToShort(text)

Converts the string to a short

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |


#### Returns

System.Int16.

*Exceptions.ConversionException:* Unable to convert value to Type


#### Remarks

Also available as an extension method


### M:DNX.Helpers.ToShort(text, defaultValue)

Converts the string to a short, or returns the default value if the conversion fails

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |
| defaultValue | *System.Int16* | The default value. |


#### Returns

System.Int16.


#### Remarks

Also available as an extension method


## Exceptions.ConversionException

Conversion Exception.


#### Remarks

 Thrown when a conversion to a specified type fails 


### M:DNX.Helpers.#ctor(value, message)

Initializes a new instance of the class.

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | *System.String* | The value. |
| message | *System.String* | The message. |

### M:DNX.Helpers.#ctor(value, message, type)

Initializes a new instance of the class.

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | *System.String* | The value. |
| message | *System.String* | The message. |
| type | *System.Type* | The type. |

### .ConvertType

Gets the type of the convert.


### .Value

Gets the value.


## Linq.LinqExtensions

Linq Extensions.


### M:DNX.Helpers.GetAt``1(enumerable, index)

Get an element from a list at the specified index, or return default

| Name | Type | Description |
| ---- | ---- | ----------- |
| enumerable | *System.Collections.Generic.IList{``0}* | The enumerable. |
| index | *System.Int32* | The index. |


#### Returns

T. Or default(T)


#### Remarks

Also available as an extension method


### M:DNX.Helpers.HasAny``1(enumerable)

Determines whether the specified enumerable has any elements and is not null

| Name | Type | Description |
| ---- | ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{``0}* | The enumerable. |


#### Returns

true if the specified enumerable has any elements; otherwise, false.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.HasAny``1(System.Collections.Generic.IEnumerable{``0},System.Func{``0,System.Boolean})

Determines whether the specified enumerable has any elements that match the predicate and is not null

| Name | Type | Description |
| ---- | ---- | ----------- |
| enumerable | *System.Collections.Generic.IEnumerable{``0}* | The enumerable. |
| predicate | *Unknown type* | The predicate. |


#### Returns

true if the specified predicate has any elements that match the predicate; otherwise, false.


#### Remarks

Also available as an extension method


## Strings.StringExtensions

String Extensions


### M:DNX.Helpers.EnsureEndsWith(text, suffix)

Ensures a string ends with a suffix string.

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |
| suffix | *System.String* | The suffix. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.EnsureStartsAndEndsWith(text, prefixsuffix)

Ensures a string starts and ends with a prefix / suffix string.

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |
| prefixsuffix | *System.String* | The prefix / suffix. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.EnsureStartsAndEndsWith(text, prefix, suffix)

Ensures a string starts a prefix string and ends with a suffix string.

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |
| prefix | *System.String* | The prefix. |
| suffix | *System.String* | The suffix. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.EnsureStartsWith(text, prefix)

Ensure a string starts with a prefix string

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* |  |
| prefix | *System.String* |  |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.RemoveAny(text, charsToRemove)

Removes any of the specified characters from a string

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |
| charsToRemove | *System.Char[]* | The chars to remove. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.RemoveAny(text, charsToRemove)

Removes any of the specified characters from a string

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |
| charsToRemove | *System.String* | The chars to remove. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.RemoveAnyExcept(text, charsToKeep)

Removes any characters from a string so that only instances of the specified characters remain

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |
| charsToKeep | *System.Collections.Generic.IList{System.Char}* | The chars to keep. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.RemoveAnyExcept(text, charsToKeep)

Removes any characters from a string so that only instances of the specified characters remain

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |
| charsToKeep | *System.String* | The chars to keep. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.RemoveEndsWith(text, suffix)

Ensures a string does not end with a suffix string

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |
| suffix | *System.String* | The suffix. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.RemoveStartsAndEndsWith(text, prefixsuffix)

Ensures a string does not start or end with a prefix / suffix string

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |
| prefixsuffix | *System.String* | The prefixsuffix. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.RemoveStartsAndEndsWith(text, prefix, suffix)

Ensures a string does not start with a prefix string or end with a suffix string

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |
| prefix | *System.String* | The prefix. |
| suffix | *System.String* | The suffix. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


### M:DNX.Helpers.RemoveStartsWith(text, prefix)

Ensures a string does not start with a prefix string

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | *System.String* | The text. |
| prefix | *System.String* | The prefix. |


#### Returns

System.String.


#### Remarks

Also available as an extension method


