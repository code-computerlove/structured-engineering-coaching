# Arrange, Act, Assert

## Goals

By the end of the session you will:

- Be able to identify the benefits of automated testing.
- Understand the typical TDD test cycle.
- Be able to identify where to write tests.
- Be able to measure test coverage.

## Content

- Introduction to testing
- Why we test
- When we test
- What we test
- Types of testing and the test triangle
- Meaningful tests
- Measuring our tests - Coverage
- Unit testing in C♯

## Introduction to testing: 10 mins

Every dev is testing constantly whether they recognise it or not. Includes, manually running the project, Console.WriteLine and debuggers.

The problem with the above is that they're transient. What did you learn? Is there value in that knowledge? How long will you remember? How many other devs will have to go on that journey?

Testing frameworks and test suites are a more permanent solution. Codifying the state of a system (arrange), the critical interaction (act) and the side effect(s) we expect to see (assert).

Unit testing frameworks, what is a unit? Depends, what is the unit of your language? In procedural languages, this might be a module, in functional languages, it might be a function, in OO languages, an object.

Test driven development (TDD) is the bedrock of extreme programming.

The testing cycle, red-green-refactor.

## Why we test: 10 mins

The obvious:

- Catching regressions.
- A safety net for refactoring. If refactoring is dangerous we just won't.
- Let us know when we're "done".
- Confidence that the code is correct.

The not so obvious:

- Document code.
- Encourage simpler code. Complicated code is harder to test.
- Forces you to think about what you are building/ what the goal is as opposed to programming by coincidence (Pragmatic Programmer).

A few of these guide us towards clean code.

## When we test: 5 mins

As early as possible.

At least before we commit.

Preferably automated locally. NCrunch, Dotcover or dotnet watch test.

Definitely automated in CI.

## What we test: 10 mins

Production code.

Tests should mostly be around the public interface. There are horror stories of apps that after months of work and dozens of tickets released, don't actually do anything.

Unit tests should be fast. If tests are slow we'll feel disinclined to run them. Slow dependencies should be faked, mocked or stubbed, which we will be talking more about in the next session.

Cover as many paths through the code as is feasible. Touch on cyclomatic complexity, the metric of the number of unique paths through a unit of code.

## Types of testing and the test triangle: 10 mins

Behold my awesome ASCII skills!

```
--------
\      / Unit
 \    /  Integration
  \  /   UI
   \/    Manual/ exploratory
```

Many types of testing are not well defined. Integration, system, acceptance, UI.

Misunderstandings about unit tests and TDD have given rise to BDD and ATDD. (this is a personal opinion - Andrew Grant)

## Meaningful tests: 5 mins

Testing the same thing multiple times.

Testing fake stuff the test itself has set up.

Tests that make no assertions.

Testing implementation details. Leads to brittle and inflexible code.

> In order to make this change I'll have to update 50 tests!

Meaningless tests add noise.

## Measuring our tests - Coverage: 5 mins

Aim for 100% but accept that reaching that may not be practical.

Beware, all metrics can be gamed. 😄

Suggested tools: Dotcover, NCrunch or Coverlets.

## Unit testing in C♯: ~60 mins

Kata
