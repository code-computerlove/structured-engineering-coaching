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
- Not a magic bullet

## Dependency inversion principle

1. High-level modules should not depend on low-level modules. Both should depend on abstractions (e.g., interfaces).
2. Abstractions should not depend on details. Details (concrete implementations) should depend on abstractions.

Already covered in depth back in session 3.

## Interface segregation principle

Created by Robert C. Martin whilst working for Xerox, building a new printer system that could do many jobs such as printing, stapling and faxing. As the system grew making even small changes became costly often necessitating a 1+ hour deployment.

The system used a single `Job` class that was used by all tasks and therefore needed to know how to do everything even though each client only needed a small subset. We sometimes call such a thing a _god object_ or a _kitchen sink_.

The solution to the problem that Martin suggested is what we now call the ISP. Breaking each tasks hard dependency on the `Job` class using dependency inversion and introducing a series of interfaces such as a staple job and a fax job.

The `Job` class implemented all the required interfaces but by using DI and ISP, small changes no longer required a full rebuild.

> Clients should not be forced to depend upon interfaces that they do not use.
>
> -- Robert C. Martin.

## Open-closed principle

> Software entities should be open for extension, but closed for modification.
>
> -- Bertrand Mayer, Object-Oriented Software Construction

This was 1988 and to provide context, at that time modifying a library by adding fields or functions often had a large knock on effect to any software that relied on said library.

In other words, the code was very tightly coupled.

Meyer saw inheritance as a solution to this problem:

> A class is closed, since it may be compiled, stored in a library, baselined, and used by client classes. But it is also open, since any new class may use it as parent, adding new features. When a descendant class is defined, there is no need to change the original or to disturb its clients.
>
> -- Bertrand Mayer, Object-Oriented Software Construction

By the mid-90s the community had switched instead to OCP via abstract base classes. In more modern times we might also use interfaces. In these cases, OCP was now applied to the abstraction of behaviour rather than concrete code.

This shift in meaning has sometimes caused confusion around what OCP means but its usefulness extends beyond OO into other programming paradigms, package management and API design.

## Law of Demeter AKA the principle of least knowledge

AKA Trainwreck code

- Spooky action at a distance
- Difficulty reasoning about code
- Violates encapsulation
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

## Not a magic bullet

## Further reading

https://web.archive.org/web/20060822033314/http://www.objectmentor.com/resources/articles/ocp.pdf
