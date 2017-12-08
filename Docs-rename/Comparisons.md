# DNX.Helpers.Comparisons

## ComparerFunc class

Some comparison functions the .NET library require an IComparer instance to be passed in to provide a result from the 2 objects being compared. Often constructing an entire class is cumbersome and relocates the logic to another class, which may not always be desirable.

This class allows a valid `IComparer` to be created inline from a simple `Func` returning an `int` to signify the comparison result.

A static method exists for explicit creation.

Examples:

```csharp
var list = new [] { 1, 2, 3, 4, 5 };

Func<int, int, int> evensFirst = (x, y) =>
{
    if (x == y) return 0;

    if (x % 2 == y % 2)
    {
        return x < y ? -1 : 1;
    }

    return (x % 2 == 0) ? -1 : 1;
};

var sortedList = list.OrderBy(x => x, ComparerFunc.Create<int>(evensFirst));

// sortedList[0] = 2;
// sortedList[1] = 4;
// sortedList[2] = 1;
// sortedList[3] = 3;
// sortedList[4] = 5;
```

## EqualityComparerFunc class

Other functions require an IEqualityComparer instance to be passed in to provide a result on whether 2 object instances are equal.

This class allows a valid IEqualityComparer to be created inline from a simple `Func` returning a `bool` to signify equality.

A static method exists for explicit creation.

Examples:

```csharp
Func<int, int, bool> absoluteEqualityFunc = (x, y) =>
{
    return Math.Abs(x) == Math.Abs(y);
};

var list = new [] { 1, -2, 3, -4, 5 };

var r1 = list.Contains(1, EqualityComparerFunc<int>.Create(absoluteEqualityFunc)); // True
var r2 = list.Contains(2, EqualityComparerFunc<int>.Create(absoluteEqualityFunc)); // True
var r3 = list.Contains(3, EqualityComparerFunc<int>.Create(absoluteEqualityFunc)); // True
var r4 = list.Contains(4, EqualityComparerFunc<int>.Create(absoluteEqualityFunc)); // True
var r5 = list.Contains(6, EqualityComparerFunc<int>.Create(absoluteEqualityFunc)); // False
```
