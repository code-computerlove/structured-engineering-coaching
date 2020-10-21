# Object Oriented Programming Part 2

## Goals

- Understand the reason for the emergence of OOP as a paradigm.
- Understand limitations of inheritance within OOP and the alternative approaches.
- Identify the applications for OOP in building well architected solutions.
- Identify some common design patterns, why they exist, and how they have been incorporated into some languages as first-class concepts.

## Content

## Favour composition over inheritance

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

- Factory Method

```csharp
class WidgetFactory
{
    public Widget Create(WidgetType type, int size)
    {
        switch (type)
        {
            case WidgetType.Sprocket:
                return new Sprocket(size);
            case WidgetType.Cog:
                return new Cog(size);
            default:
                throw new ArgumentException(nameof(type));
        }
    }
}
```

```typescript
function WidgetFactory(type: WidgetType, size: number) {
  switch (type) {
    case WidgetType.Sprocket:
      return new Sprocket(size);
    case WidgetType.Cog:
      return new Cog(size);
    default:
      throw new Error("Unknown widget type");
  }
}
```

- Singleton (dependency injection to the rescue)
- Iterator (IEnumerable)

Allows iterating through a sequence of values without having to know the underlying data type.

```csharp
public interface IIterable
{
    bool HasNext();
    object Next();
}
```

This implemented in C# as a first-class language concept: `IEnumerable` (and the generic `IEnumerable<T>`).
`foreach` will use the `IEnumerable<T>` methods transparently - caution should be made though to understand potential drawbacks, e.g. enumerating over a database query which may cause unnecessary db utilization.

- Strategy (delegates)
- Observer (event handlers) (C# event)
- Adapter/ proxy/ wrapper

## God objects

The kitchen sink

## CRC cards
