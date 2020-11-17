# SOLID Principles Part 2
## Goals

Understanding of:
- Dependency inversion principle
- Interface segregation principle
- Open closed principle
- Law of Demeter

## Content

- Dependency inversion principle
- Interface segregation principle
- Open-closed principle
- Law of Demeter

## Dependency inversion principle

1. High-level modules should not depend on low-level modules. Both should depend on abstractions (e.g., interfaces).
2. Abstractions should not depend on details. Details (concrete implementations) should depend on abstractions.

Already covered in depth back in session 3.

## Interface segregation principle

Created by Robert C. Martin whilst working for Xerox, building a new printer system that could do many jobs such as printing, stapling and faxing. As the system grew making even small changes became costly often necessitating a 1+ hour deployment.

The system used a single `Job` class that was used by all tasks and therefore needed to know how to do everything even though each client only needed a small subset. We sometimes call such a thing a _god object_ or a _kitchen sink_.

The solution to the problem that Martin suggested is what we now call the ISP. Breaking each tasks hard dependency on the `Job` class using dependency inversion and introducing a series of interfaces such as a staple job and a fax job.

The `Job` class implemented all the required interfaces but by using DI and ISP, small changes no longer required a full rebuild.

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
