# Object Oriented Programming Part 1

## Goals

- Understand the reason for the emergence of OOP as a paradigm.
- Understand limitations of inheritance within OOP and the alternative approaches.
- Identify the applications for OOP in building well architected solutions.
- Identify some common design patterns, why they exist, and how they have been incorporated into some languages as first-class concepts.

## Content

## A quick history lesson

### In the beginning...

No code organisation. No management of complexity.

### Structured programming

The first paradigm.

- selection E.G. if
- repetition E.G. while/ for
- blocks {}
- subroutines

### Modular programming

Managing complexity by separating code into modules.

### Abstract data types (ADT)

Managing complexity by type abstraction.

More than just data structures.

### Alan Kay flavoured Object Oriented Programming (OOP)

Managing complexity by procedural abstraction.

Inspired by biological cells and the ADT model from Simula but implemented procedurally through techniques such as closures in Lisp rather than type definitions. Internal state was "closed over" and could not be reached from the outside making objects black boxes that could only be influenced by sending "messages" to.

Aimed to get rid of data structures.

> "OOP to me means only messaging"
>
> -- Alan Kay

Smalltalk was developed to support this idea of OOP as being about messages and black box architecture, and became the defacto language of enterprise development.

Sun originally tried to license Smalltalk so it would come by default on all Sun workstations. No Smalltalk vendor would agree to such a licensing model. So Sun developed Java instead.

### C++ flavoured OOP

Bjarne Stroustrup
C with classes (ADT-lite classes not OO classes)

C++ was a mixture of ADT-lite for namespacing and enough OOP buzzwords to ride the hype generated by Smalltalk. In many ways, C++ embodied the idea of OOP as a style of syntax.

> "I invented OOP and C++ was not what I had in mind."
>
> -- Alan Kay (hopefully apocryphal because it's incredibly arrogant)

Whilst Smalltalk was what big companies were using, the rise of affordable home computers and the fact that C++ was a free language meant there was now a large pool of untapped developers with C++ experience. Rebuffed by Smalltalk vendors, Sun developed Java and modelled it on C++ to take advantage of these devs.

Sun also put a lot of effort into Java supporting the newfangled Internet, something that Smalltalk vendors had not really payed any attention to.

Almost overnight, Java destroyed Smalltalk. This also had the unfortunate effect of making many people believe that OOP was the one true and only programming paradigm.

### Multi-paradigm

Whilst Alan Kay's pony may not have "won" the OO race, many developers have grown frustrated with the perceived shortcomings of OOP. This has led to a resurgence of interest in functional and procedural programming languages as well as lots of innovation in Java and C#.

In recognition that no paradigm is the best fit for all problems, most modern languages are now multi-paradigm, allowing procedural, functional and OO to a greater or lesser extent.

Many of C# 9's new features revolve around functional and procedural programming. E.G. Records and the ability to lose OO boilerplate for single class solutions.

## What OOP means to Code Computerlove

The truth of the matter is that C++ flavour languages are still so popular decades later because they are "good enough". They have demonstrated many times over that, in the hands of a mostly competent developer, a successful business can run on software developed in them.

However, there are also many examples in the industry of successful software products and the companies behind them disappearing without trace when the software was unable to adapt or deliver new features in a timely manner.



"OOP" languages do not drive you towards OOP.

OO is not:

- Classes: JS originally used prototypes. It now has classes as well.
- Static typing: Python and JS both support OOP. In fact the original OOP language, Smalltalk, was dynamic.

## Bad analogies

Car has 4 wheels. Leads to trying to simulate the real world.

```csharp
abstract class Vehicle, IReadOnlyList<Wheel>
{
    abstract void Start();
    abstract void Stop();
    float Speed { get; }
    IEnumerable<float> GetTyrePressures();
}

class Car : Vehicle
{
    /* ... */
}

class Bike : Vehicle
{
    /* ... */
}

class Cart : Vehicle
{
    // todo: tyre pressures?
}

class Tank : Vehicle
{
    // todo: tyre pressures?
}
```

Square is a type of rectangle?

IShape in general

```csharp
abstract class Shape { }

class Polygon : Shape { }

class Circle : Shape { }

class Triangle : Shape { }

class Rectangle : Shape { }

class Square : Shape { }
// or is Square a special case of Rectangle?
class Square : Rectangle { }
```

## It's not collections of properties

```csharp
interface IShape
{
    int Width { get; set; }
    int Height { get; set; }
}
```

Objects are about behaviour not data.

## It’s not taxonomy

Inheritance is overrated. Received wisdom that inheritance is the secret sauce of OO and EVERYTHING should use it everywhere possible.

sparrow is a type of bird is a type of animal is a type of lifeform is a type of object.

### Favour composition over inheritance.

```csharp
class GameObject { }
class Player : GameObject { }
class Enemy : GameObject { }
class StrongEnemy : Enemy { }
class Cloud : GameObject { }
class Powerup : GameObject { }
```

```csharp
class GameObject(Physics physics, Inventory inventory, SoundEffect soundEffect, Armour armour)
```

Some older UI libraries had (and still have) APIs that follow this sort of structure:

```csharp
class Component { }
class Container : Component { }
class Panel : Container { }
class Window : Container { }
class Button : Component { }
class Textbox : Component { }
class RadioButton : Component { }
```

In more modern UI libraries (React), there is no longer a forced hierarchy, eg `FlatList` extends `PureComponent`. Authoring new components is greatly simplified and favours composition:

```ts
ExampleComponent() : ReactComponent => {
    <Text>This is a label</Text>;
}
```

## It’s not mixins

ISaveable

```csharp
interface IFly
{
    public void Fly() => Console.WriteLine("I am flying");
}

interface ISwim
{
    public void Swim() => Console.WrlteLine("I am swimming");
}

interface IDive
{
    public void Dive() => Console.WriteLine("I am diving");
}

interface IEatBread
{
    public void EatBread() => Console.WriteLine("Yum.");
}

class Duck : IFly, ISwim, IDive, IEatBread { }

class AirbusA380 : IFly { }

class Submarine : IDive { }

class Person : ISwim, IDive, IEatBread { }
// unless they can't swim
// unless they're coeliac
```

## The DB model is not your domain model

Fossilised data as opposed to rich objects. No behaviour in relational DBs.

```csharp

class User
{
    public string Name { get; set; }
    public virtual List<Role> Roles { get; set; }
    public string PasswordHash { get; set; }
    public int PasswordIterations { get; set; }
}

class Role
{
    public string Name { get; set; }
}

class PasswordHash
{
    bool Matches(string plainText){...}
}

```

## Handler, manager and controller. Bad names for objects

- `LoginHandler`
- `AccountManager`
- `InputController`

Their names hint at their purpose, `LoginHandler` and `InputController` might be excused, because their naming convention may be expected within the ASP.NET ecosystem.

## Anaemic objects

Glorified data structures

Anemic objects rely on other objects to do the work for them (ignoring DTOs).

- Needly exposes class internals.
- Increases mental complexity by splitting intrinsically connected behaviour.
- Objects state changes through public property getters can lead to invalid data.

```csharp
class WeatherReport
{
    public float Temperature { get; set; }
    public int CloudCover { get; set; }
    public float BarometricPressure { get; set; }
    public float PrecipitationMm { get; set; }
    public float WindSpeed { get; set; }
}

class WeatherManager
{
    public static bool ShouldWearJacket(WeatherReport report) => 
        return report.Temperature < 10 || report.WindSpeed > 10 || report.PrecipitationMm > 5;

    public static bool IsBbqWeather(WeatherReport report) =>
        return report.Temperature > 0;

    public static bool IsValidWeatherReport(WeatherReport report) =>
        return report.WindSpeed > 0 &&
            report.Temperature >= -237.15f &&
            report.BarometricPressure > 0;
```

Refactored:

```csharp
class WeatherReport
{
    public float Temperature { get; }
    public int CloudCover { get; }
    public float BarometricPressure { get; }
    public float PrecipitationMm { get; }
    public float WindSpeed { get; }

    public bool ShouldWearJacket => return Temperature < 10 ||  WindSpeed > 10 ||  PrecipitationMm > 5;
    public bool IsBbqWeather => return Temperature > 0;

    public WeatherReport(float temperature, int cloudCover, float barometricPressure,
        float precipitationMm, float windSpeed)
    {
        if (temperature < 237.15f)
            throw new ArgumentException(nameof(temperature));
        if (windSpeed < 0)
            throw new ArgumentException(nameof(cloudCover));
        if (barometricPressure <= 0)
            throw new ArgumentException(nameof(barometricPressure))

        Temperature = temperature;
        CloudCover = cloudCover;
        BarometricPressure = barometricPressure;
        PrecipitationMm = precipitationMm;
        WindSpeed = windSpeed;
    }
}
```

## Design patterns

Find quote referring to design patterns being a way of patching up language features

- Factory
- Singleton (dependency injection to the rescue)
- Iterator (IEnumerable)
- Strategy (delegates)
- Observer (event handlers) (C# event)
- Adapter/ proxy/ wrapper

## God objects

The kitchen sink

## CRC cards