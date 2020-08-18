# Inversion of Control

## Goals

By the end of the session you will:

- Understand the principle of Inversion of Control.
- Understand the principle of Dependency Injection.
- Be able to write code that adheres to IoC.
- Test using mocks or fakes.
- Configure a dependency injection container.

## Content

- Introduction to IoC.
- Introduction to Dependency Inversion.
- 

## Introduction to Inversion of Control (IoC): 10 mins

A principle to decouple implementation specifics. Many techniques exist that follow this principle:

- Callbacks.
- Event loops.
- Dependency injection.
- Template methods.
- Abstract classes in .net.

## Inversion of Control by example: 10 mins

Imagine the scenario of a class that reads from a file system, and sends the contents of that file to an FTP server. In the process of doing so it converts all the text to upper-case.

This class has a 'concrete' dependency on the file system, and the FTP server.

But what if we want to read from a zip file instead? or write to an HTTP server?.

Two possible refactoring options:

- Create an abstract class with abstract `ReadFromSource` and `WriteToDestination` methods.
- Extract the behaviours of accessing the file system and FTP server into separate classes that implement a specific interface (a contract), and pass them into the constructor. This is dependency injection.

## Dependency injection: 10 minutes


<< example of new-ing up manually >>

Obviously creating objects like this is not feasible for an application of any decent size. 

## Mocking and Faking: 10 minutes

## Gotchas: 15 minutes

Some components may seem difficult to inject, or there may be specific ways in how they should be created. This is particuarly the case with components that wrap or interact with lower level system resources such as threads and sockets.

- DateTime.Now.
- HttpClient and HttpClientFactory.
- Libraries for mocking.

## Refactoring exercise: 60 minutes

Example class that has dependencies on DateTime.Now, HttpClient, and the file system.