# Dealing with legacy code

## Goals

By the end of the session you will:

- Understand the definitions of Legacy Code
- What tools and methodologies we can use
- How we can introduce new functionality confidently

## Content

### What is legacy code? - 10 mins

- Old(ish)
- Probably not tested
- Poorly understood
- Uses old/out-of-date frameworks and libraries
- A bit whiffy
- No longer maintained by the original team
- Full of surprises

### What makes code hard to test - 10 mins

- It's slow.
- It produces visual output (spot the difference).
- Test environment is not indicative of Live.
- Reliance on 3rd party APIs.

### Getting the lay of the land - 5 mins

- What dependencies exist?
- Are there existing tests? if so, is code coverage calculated? are there hot spots?

### Verifying existing behaviour - 10 mins

We can assume that the existing system is functioning correctly.

Acceptance tests
 - Browser automation
 - Postman/SoapUI

Golden master
 - Text diffing
 - Visual regression testing (like backstop)

### Refactoring for readability - 10 mins

As you gain a clearer understanding:
- rename things
- extract methods
- extract classes
- move methods between classes

- Duplicate code blocks.
- Unused code?
- Separating classes into separate files.
- Applying code conventions.

### Refactoring to insert tests - 10 mins

"If it isn’t out by the time this book is released, I suspect that someone will soon develop an IDE that allows you to specify a set of tests that will run at every key-stroke. It would be an incredible way of closing the feedback loop."
- Michael Feathers, Working Effectively with Legacy Code, 2004.

- Seams
  - Object seams.
  - Monkey patching (dynamic languages like Javascript, Python).

Break concrete dependencies with extract interface. We did this in a previous session.

Make private methods public.

### Writing code for future developers - 5 mins

- Boy scout rule.
- Linting tools.
