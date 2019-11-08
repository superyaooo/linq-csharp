# linq-csharp
Intro to Linq

- **LINQ Fundamentals** from Pluralsight


**Notes**

```
// last param is return type; Linq uses Func<>
Func<int, int> square = x => x * x;
Func<int, int, int> add = (x, y) => x + y;
// return type void
Action<int> write = x => Console.WriteLine(x);
```

```
// use .ThenBy() to do secondary sort
.OderBy(x => x.Name).ThenBy(x => x.Date)
```

