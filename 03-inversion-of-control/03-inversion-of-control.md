# Inversion of Control

## Goals

By the end of the session you will:

- Understand the principle of Inversion of Control.
- Understand the principle of Dependency Injection.
- Be able to write code that adheres to IoC.
- Test using mocks and fakes.
- Configure a dependency injection container.

## Content

- Introduction to IoC.
- Inversion of Control by example.
- Dependency Injection.
- Which way should dependencies go?
- Test Doubles.
- Gotchas.
- Refactoring Exercise.

## Introduction to Inversion of Control (IoC): 10 mins

Think of a simple console app. It might have simple procedures to help it render menus and take user input but the main program loop controls and directs everything.

Compare this to a windowed app. It would be unreasonably complicated for the main method to have to control what happens when the window is resized, dragged, minimized etc. Instead, the windowing framework controls all of that and more, and the main method is notified about particular user inputs.

An inversion of the flow of control.

A principle to decouple implementation specifics. Many techniques exist to enable this:

- Callbacks.
- Event loops.
- Template methods.
- Abstract classes in .net.
- Dependency injection.

## Inversion of Control by example: 10 mins

Imagine the scenario of a class that reads from a file system, and sends the contents of that file to an FTP server. In the process of doing so it converts all the text to upper-case.

This class has a 'concrete' dependency on the file system, and the FTP server.

But what if we want to read from a zip file instead? or write to an HTTP server?

Two possible refactoring options:

- Create an abstract class with abstract `ReadFromSource` and `WriteToDestination` methods.
- Extract the behaviours of accessing the file system and FTP server into separate classes that implement a specific interface (a contract), and pass them into the constructor. This is dependency injection.

## Dependency injection: 10 minutes

<< example of new-ing up manually >>

Sometimes called "poor mans DI". Massively lighter and quicker than an IoC framework. Might be fine for a microservice.

Obviously creating objects like this is not feasible for an application of any decent size.

## Which way should dependencies go? 10 minutes

N-Tier vs onion/ hexagonal architecture.

Is the database really the centre of the world?

## Test Doubles: 10 minutes

When writing tests, given that the code we write depends on a contract (interface), we don't necessarily have to use real implementations when writing our tests. Tests that rely on real web services, databases, times, may be brittle and slow. Instead we can swap out our implementation with a test double.

- Fakes - use a dictionary hash-map instead of a real MemoryCache.
- Mocks - verify an email was sent using the IEmailServer.Send() method.
- Stubs - return a canned response when a function is called.

In reality Mocks and Stubs all get lumped into the "Mock" category. Some mocking frameworks have abandoned differentiating to avoid confusion E.G. NSubstitute. The principle is we're providing the code being tested with the necessary scaffolding to perform the action being tested, in a manner that we can verify it was performed correctly.

## Gotchas: 15 minutes

Some components may seem difficult to inject, or there may be specific ways in how they should be created. This is particuarly the case with components that wrap or interact with lower level system resources such as threads and sockets.

- DateTime.Now.
- HttpClient and HttpClientFactory.
- Libraries for mocking.

## Refactoring exercise: 60 minutes

Example class that has dependencies on DateTime.Now, HttpClient, and the file system.
