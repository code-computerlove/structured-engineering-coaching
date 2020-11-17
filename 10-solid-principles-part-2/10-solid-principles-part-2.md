# SOLID Principles Part 2
## Goals

Understanding of:
- Dependency injection principle
- Interface segregation principle
- Open closed principle
- Law of Demeter

## Content

## Dependency injection principle

## Interface segregation principle

## Open-closed principle

- A class/function/module should be open for extension, but closed for modification.
- A fancy way of saying we should be able to modify it's behaviour without having to modify the thing itself.
- Originally (in 1988), inheritance was proposed as a solution to this. Later, abstract base classes and interfaces became more popular approach:

```csharp

abstract class Table
{
  public void DrawTable(TableData data)
  {
    DrawHeader(data);
    foreach (var row in data.Rows)
    {
      DrawRow(row);
    }
  }

  protected abstract void DrawHeader(TableData data);
  protected abstract void DrawRow(TableData row);
}

```

## Law of Demeter AKA the principle of least knowledge

AKA Trainwreck code

- Spooky action at a distance
- Difficulty reasoning about code
- Tight coupling

```csharp
emailService.EmailParser.CleanseString("Hello world");
```

If we write classes to depend on an implementation of an interface rather than an actual concrete implementation we fall into a "pit of success", we can't see the internals because they're not exposed:

this is more descriptive:

```csharp
interface IEmailService {
  string CleanseString(string input);
}
```

than this interface, which doesn't actually expose any behaviour!:

```csharp
interface IEmailService {
  IEmailParser EmailParser { get; }
}
```

## Further reading

https://web.archive.org/web/20060822033314/http://www.objectmentor.com/resources/articles/ocp.pdf
