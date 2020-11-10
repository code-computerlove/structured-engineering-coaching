# SOLID Principles

## Goals

## Content

### What is it?

- Five principles for better software architecture.
- The principles were devised by Robert C Martin in early 2000's, the acronym came later.
- Not laws, mostly opinions from individuals that have written and maintained lots of codebases.

### The acronym

- Single Responsibility
- Open-closed Principle
- Liskov Substitution Principle
- Interface Segregation Principle
- Dependency Inversion Principle

### Single Responsibility

- "A class should only have one reason to change" - Robert C Martin.
- *nix command principle - do one thing, and do it well.
  - They read a stream of input, and write a stream of output.
  - `grep` - Find words
  - `wc` - Count words/lines
  - `ls` - List contents of a directory
  - `ls | grep json$ | wc -l` - Count json files in current directory

### Open-Closed Principle

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

### Liskov Substitution Principle

It should be possible to swap out an object with an instance of their subtype without altering the correctness of a program.

Eg, if we have some software that depends on a class `Fruit` we should be able to pass in an instance of `Apple` (that subclasses `Fruit`).

As we discussed in the previous session regarding `IEnumerable<T>` there may be subtle gotchas with the underlying implementing of the data source - e.g. N+1 scenarios when reading from a database line-by-line.

- Linux OS principle. Everything is a file.
- A file can be read from (usually), or written to (usually)
  - `/dev/null` - A black hole.
  - `/dev/random` - A stream of random bytes.
  - `/dev/lp0` - A printer
  - `/dev/tty0` - A terminal session

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

#### Law of Demeter AKA the principle of least knowledge

AKA Trainwreck code

- Spooky action at a distance
- Difficulty reasoning about code
- Tight coupling

```csharp
emailService.EmailParser.CleanseString("Hello world");
```

```

```

### Interface Segregation Principle



### Dependency Injection Principle



### Further reading

https://web.archive.org/web/20060822033314/http://www.objectmentor.com/resources/articles/ocp.pdf
