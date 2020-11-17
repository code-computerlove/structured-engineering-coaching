# Object Oriented Programming Part 2

## Goals

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

```tsx
ExampleComponent() : ReactComponent => {
    return (<View>
        <Text>This is a label</Text>
    </View>);
}
```

## Design patterns

> Patterns mean "I have run out of language."
>
> — Rich Hickey.

### Factory Method

```csharp
class Sprocket : Widget { }

class Cog: Widget { }

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

### Singleton (dependency injection to the rescue)

### Iterator (IEnumerable)

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

### Observer pattern

> "Tell, don't ask."

> "Don't call us, we'll call you." - The 'Hollywood' principle.

## CRC cards

Class-responsibility-collaboration cards.

Checkout kata with CRC cards.
