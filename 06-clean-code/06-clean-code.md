# Clean code

## Goals

By the end of the session you will:

## Content

## AKA Habitability

As we said back in session 4, 10:1 ratio reading to writing but clean code is more than just readability. Cleanliness might be considered superficial so some people prefer the term "Habitability".

> Habitability is the characteristic of source code that enables programmers, coders, bug-fixers, and people coming to the code later in its life to understand its construction and intentions and to change it comfortably and confidently.
>
> Habitability makes a place liveable, like home. And this is what we want in software - that developers feel at home, can place their hands on any item without having to think deeply about where it is.
>
> -- Richard P. Gabriel

## What is source code

Review:

- Machine code E.G. 05 2A 00 (add 42 to the accumulator)
- Assembly E.G. add 42 ax (add 42 to the accumulator). Symbolic representation of instructions and memory addresses
- Low level (implicitly procedural) E.G. C

As far as a CPU is concerned there is no such thing as variables, if statements, functions, methods, mutability or objects.

At the end of the day, some bits in memory will have changed.

- High level E.G. C#, F#, JavaScript, Fortran, Lisp, Go, T-SQL

Programming languages are abstractions for people.

- The Holodeck 😉

Since the dawn of time, business has dreamed of not needing devs.

> There's no point in me teaching you C because by the time you leave university C and C style programming languages will be obsolete.
>
> -- Andrew Grant's computer science teacher in the mid 90s

All attempts at getting business people to produce code have failed.

OOP was supposed to be HolodeckScript!

## A shiny new language

A language with no source files. Objects are created and edited directly in an IDE whilst the program is running. Able to pause and modify the program. Able to interactively fix bugs and errors whilst they're happening.

This language is Smalltalk. In some ways the industry has gone backwards from where it was nearly 50 years ago.

> Source code in files. How quaint.
>
> -- Kent Beck

There are no new ideas. But the same ones have been discovered dozens of times over the decades.

## Learn multiple languages.

If all you have is a hammer then every problem looks like an an abstract factory interface needing a concrete implementation to be late dispatched in via an IoC framework.

Many problems with a code base start when people focus on what code to write instead of how to solve the problem. If you don't have an appreciation for the different paradigms then you're not considering all solutions to the problem.

## Imagination time

Imagine you're in a large mansion. Someone asks "I'm going shopping, do I need to get baked beans?"

You'd look in the kitchen and pantry cupboards and be able to tell them with some confidence. "Yes, you need to get beans."

A bit of time has passed and:

- you've discovered assorted soup tins in a bathroom.
- a tin of corned beef you opened actually contained kidney beans.
- a handwritten note in a bedroom mentions a second kitchen but you've not found it yet.

If someone asks you the shopping question now you're more likely to say "I don't know. Even if there are beans I'm not sure we could find them. Maybe buy some beans just in case."

### Principle of least surprise

Problem 1, things aren't organised as expected.

If there's no inherent order to a code base then you don't know where to find existing functionality. You also don't know where to add new functionality. Things snowball from here.

### Don't repeat yourself

Problem 2, why is there (maybe) a second kitchen?

Are there more? Is there a reason for multiple kitchens? What aren't I getting?

But remember, too DRY is flammable.

### Refactor

Problem 3, why are we in a mansion? No one needs a mansion.

Code bases don't start as mansions.

Worse is better. Quality does not increase with functionality.

Recognise that architecture needs to evolve over time. What was the correct architecture yesterday may not be the correct architecture today. This is fine and expected as business requirements will change over time.

Don't put off correcting architecture until you're in a corner.

Don't be afraid to remove functionality which is no longer needed/ isn't performing as expected.

Lines of code cost money to write but also cost money to maintain. Once code is written it's not free here on out.

## Tests as living documentation

Code and test framework is usually all that is needed for a clear and unambiguous specification.

Gherkin is bloated, repetitive, ambiguous and, a barrier to abstraction and modularity.

Treat tests like any other code. Refactor. Remove duplication. Delete when no longer needed.

## Clean code is hard

There is no magic process for writing clean code. Clean code is usually achieved through refinement. Don't skimp on refactoring.

Parkinson's Law of Triviality
bikeshedding

Prioritise difficult or uncertain tasks ahead of those you're confident about.

A well maintained code base should be bikesheds all the way down.

## The campsite rule

You don't have to fix everything today but if you just give one variable a better name then you've improved things.
