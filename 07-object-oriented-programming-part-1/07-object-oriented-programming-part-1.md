# Object Oriented Programming Part 1

## Goals

## Content

## A quick history lesson

Abstract Data Types (ADT)
Type abstraction

Alan Kay
Getting rid of data
OOP predating OOP languages
Procedural abstraction
Black boxes and messages
"OOP to me means only messaging" - Alan Kay

Meanwhile
Bjarne Stroustrup
C with classes (ADT classes)

C++ as a Frankenstein monster of ADT for namespacing and enough OOP buzzwords to get it off the ground

"OO" languages do not drive you towards OOP.

## Messages (and to a lesser degree, objects)

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
