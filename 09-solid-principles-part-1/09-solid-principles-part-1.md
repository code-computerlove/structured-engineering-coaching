# SOLID Principles Part 1

## Goals

Understanding of:
- the origin of SOLID principles.
- the Single Responsibility principle.
- the Liskov Substitution principle.

## Content

- What is it?
- The acronym
- Single responsibility principle
- Liskov substitution principle

## What is it?

- Five principles for better software architecture.
- The principles were devised by Robert C Martin in early 2000's, the acronym came later.
- Not laws, mostly opinions from individuals that have written and maintained lots of codebases.

## The acronym

- Single Responsibility
- Open-closed Principle
- Liskov Substitution Principle
- Interface Segregation Principle
- Dependency Inversion Principle

## Single responsibility principle

- "A class should only have one reason to change" - Robert C Martin.
- *nix command principle - do one thing, and do it well.
  - They read a stream of input, and write a stream of output.
  - `grep` - Find words
  - `wc` - Count words/lines
  - `ls` - List contents of a directory
  - `ls | grep json$ | wc -l` - Count json files in current directory

## Liskov substitution principle

It should be possible to swap out an object with an instance of their subtype without altering the correctness of a program.

Eg, if we have some software that depends on a class `Fruit` we should be able to pass in an instance of `Apple` (that subclasses `Fruit`).

As we discussed in the previous session regarding `IEnumerable<T>` there may be subtle gotchas with the underlying implementing of the data source - e.g. N+1 scenarios when reading from a database line-by-line.

- Linux OS principle. Everything is a file.
- A file can be read from (usually), or written to (usually)
  - `/dev/null` - A black hole
  - `/dev/random` - A stream of random bytes
  - `/dev/lp0` - A printer
  - `/dev/tty0` - A terminal session
  - `/dev/clipboard` - A clipboard

```typescript
function getName() {
    return 'kate';
}

function getAge() {
    return 22;
}

function getPerson() {
    return {
        name: getName(),
        age: getAge()
    };
}

function displayPerson(person: { name: string, age: number }) {
    console.log('Hello ' + person.name + ' you are ' + person.age + ' years old!');
}

displayPerson(getPerson());
```

- Streams in .net
  - Can read from (sometimes)
  - Can write to (sometimes)
  - Can sometimes violate this principle, e.g they can't be rewound `stream.Position = 0`, or they have to be rewound!.
  - `ZipStream`, `MemoryStream`, `StringStream`, etc.
  - `StreamReader`, `StreamWriter`.
