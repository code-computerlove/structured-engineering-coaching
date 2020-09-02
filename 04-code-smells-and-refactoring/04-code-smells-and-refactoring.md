# Code smells and refactoring

## Goals

By the end of the session you will:

- Recognise common code smells.
- Understand common refactorings.
- Understand how to safely refactor code.

## Content

- What do devs spend most of their time doing?
- Common problems in the code base AKA code smells

  - Naming
  - Comments
  - Duplicated code
  - Missing objects
  - Fat methods and classes
  - Dead/ unreachable code
  - Special cases
  - Null AKA the billion dollar mistake

- A review of the refactorings

## What do devs spend most of their time doing?: 10 mins

> Indeed, the ratio of time spent reading versus writing is well over 10 to 1. We are constantly reading old code as part of the effort to write new code. ...[Therefore,] making it easy to read makes it easier to write.
>
> -- Robert C. Martin, Clean Code: A Handbook of Agile Software Craftsmanship

Development is slowed by code that:

- does not communicate its intent well (or downright lies).
- is duplicated.
- is inflexible.
- is bloated.
- is difficult to test.

## Common problems in the code base AKA code smells

### Naming: 5 mins

#### Type embedded in name

```csharp
// Compound words
void AddCustomer(Customer customer);

// Hungarian notation
string sName;
private string _name;

// Name reflects type rather than role
int integer;
```

#### Uncommunicative

```csharp
// Terse
string s;
int totNumOfCusts;

// Misleading
var customerName = new char[6];
```

#### Inconsistent

```csharp
void Put(string name);
void Add(string name);
void Save(string name);

int currentTotal;
int runningTotal;
```

#### Solutions to bad names

- Rename

### Comments: 5 mins

```csharp
int count = 0; // Count starts at 0

var temperature = (sensor - 32.0) / 1.8;
// The sensor returns Fahrenheit so we need to
// convert to Celsius

public decimal Execute(){
  // Calculates VAT
  ...
}

public VoucherCode IssueVoucherFor(Customer customer) {
  // Please only pass UK customers as we can't give
  // codes to international customers
  ...
}
```

#### Solutions to comments

- Remove
- Extract method
- Rename method/ variable
- Introduce assertion

```csharp
int count = 0;

var temperature =
  ConvertFahrenheitToCelsius(sensorTemperature);

public decimal CalculateVat() {
  ...
}

public VoucherCode IssueVoucherFor(Customer customer) {
  if (customer.IsInternational())
    throw new Exception(
      "Cannot issue vouchers for international customers.");
  ...
}
```

### Duplicated code: 5 mins

```csharp
string BillingAddress() {
  var fullName = _firstName + " " + _lastName;
  ...
}

string ShippingAddress() {
  var fullName = _firstName + " " + _lastName;
  ...
}
```

#### Bad APIs/ temporal coupling

```csharp
widgetApi.Initialise();
widgetApi.PreloadWidgets();
widgetApi.WarmTheDoohickey();
widgetApi.GetWidget(1234);

widgetApi.Initialise();
widgetApi.PreloadWidgets();
widgetApi.WarmTheDoohickey();
widgetApi.ReserveWidget(5678);
```

#### Solution to duplicated code

DRY but beware of so dry it's flammable.

- Extract method
- Extract abstract class

```csharp
string FullName() {
  return _firstName + " " + _lastName;
}

string BillingAddress() {
  ...
}

string ShippingAddress() {
  ...
}
```

```csharp
public class Widgets {
  private IWidgetApi _widgetApi;

  public Widgets(IWidgetApi widgetApi) {
      _widgetApi = widgetApi;
  }

  public Widget Get(int id) {
    PrepApiForRequest();
    return _widgetApi.GetWidget(id);
  }

  public Widget Reserve(int id) {
    PrepApiForRequest();
    return _widgetApi.GetWidget(id);
  }

  // Make sure to call this before each request
  // as there is temporal coupling in API
  private void PrepApiForRequest() {
    _widgetApi.Initialise();
    _widgetApi.PreloadWidgets();
    _widgetApi.WarmTheDoohickey();
  }
}
```

### Missing objects: 5 mins

#### Data clump

```csharp
string FullName(
  string salutation,
  string firstName,
  string lastName) {
    ...
  }
```

#### Anaemic object (data structure)

```csharp
class Name {
  public string Salutation { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
}
```

#### Feature envy

```csharp
class Name {
  public string Salutation { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
}

class NameHelper {
  public string FullName(Name name){
    return name.Salutation +
    " " + name.FirstName +
    " " + name.LastName;
  }
}
```

#### Primitive obsession

```csharp
IList<OrderLines> order;
```

#### Solutions for missing objects

- Extract class
- Move method

```csharp
class Name {
  public string Salutation { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }

  public string FullName(){
    return Salutation + " " +
      FirstName + " " +
      LastName;
  }
}
```

```csharp
class Order {
  private IList<OrderLines> _orderLines;

  public void Add(OrderLine orderLine) {
    ...
  }

  public decimal SubTotal() {
    ...
  }
}
```

### Fat methods and classes: 5 mins

```csharp
class LaaaaaaaaaaaargeClass {
  public void LaaaaaaaaaaaargeMethod() {
    // 50 lines of code
  }

  // 500 more lines of class
}
```

#### Solutions for fat methods and classes

- Extract method
- Extract class
- Look for feature envy

### Dead/ unreachable code: 5 mins

```csharp
class Bill {
  private Food _food;
  private Drinks _drinks;
  private IVat _vat;
  // I was used once upon a time
  private IEatOutToHelpOut _eatOutToHelpOut;

  public Bill(IVat vat, IEatOutToHelpOut eatOutToHelpOut) {
    _vat = vat;
    _eatOutToHelpOut = eatOutToHelpOut;
  }

  public decimal Total() {
    var subTotal = _food.Total() + _drinks.Total();
    var vatTotal = _vat.For(_food) + _vat.For(_drink);
    var total = subTotal + vatTotal;
    // var eatOutToHelpOutDiscount = _eatOutToHelpOut.DiscountFor(total);
    ...
  }
}
```

#### Solutions for dead/ unreachable code

- Delete it

```csharp
class Bill {
  private Food _food;
  private Drinks _drinks;
  private IVat _vat;

  public Bill(IVat vat) {
    _vat = vat;
  }

  public decimal Total() {
    var subTotal = _food.Total() + _drinks.Total();
    var vatTotal = _vat.For(_food) + _vat.For(_drink);
    var total = subTotal + vatTotal;
    ...
  }
}
```

### Special cases: 5 mins

```csharp
class Account {
  private AccountType _type;

  public decimal Interest() {
    if(_type == AccountType.Checking) {
      ...
    } else {
      ...
    }
  }
}

decimal GetTotal(bool isWeekend) {
  if(isWeekend) {
    ...
  } else {
    ...
  }
}
```

#### Solutions for special cases

- Extract class
- Extract abstract class
- Extract interface
- Use factories

```csharp
abstract class Account
{
    public abstract decimal Interest();
}

class CheckingAccount : Account {
  public override decimal Interest() {
    ...
  }
}

class SavingsAccount : Account {
  public override decimal Interest() {
    ...
  }
}
```

```csharp
decimal GetWeekendTotal() {
  ...
}

decimal GetWeekDayTotal() {
  ...
}
```

### Null AKA the billion dollar mistake: 5 mins

```csharp
class SurveyParticipants {
  private List<int> _customerIds;

  private ICustomers _customers;

  public SurveyParticipants(ICustomers customers) {
      _customers = customers;
  }

  public string Report() {
    var stringBuilder = new StringBuilder();
    stringBuilder.AppendLine("Participants:");

    foreach (var id in _customerIds) {
        var customer = _customers.Get(id);
        if (customer != null) {
            stringBuilder.AppendLine(customer.Email());
        } else {
            stringBuilder.AppendLine("Customer not found");
        }
    }
  }
}
```

#### Solutions for null

- Let it fail
- Use C# 8 non-nullable reference types

```csharp
class Customers : ICustomers {
  private ICustomersDb _database;

  public Customers(ICustomersDb database) {
    _database = database;
  }

  public Customer Get(int id) {
    var customer = _database.Get(id);

    if (customer == null)
      throw new NotFoundException(
        "Customer doesn't exist");

    return customer;
  }
}
```

## A review of the refactorings: 5 mins

- Rename
- Extract method
- Extract class

Always refactor safely! Where possible:

- validate with tests
- use safe refactoring tools
