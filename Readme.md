# Refactoring-Improving.the.Design.of.Existing.Code.2nd.edition (Martin Fowler )
# Description
Work that I have done in the Path of this Refactoring project :

The goal of code refactoring is to turn dirty code into clean code, which reduces a project’s overall technical debt.

Different problems require different solutions!

I try to observe the problem space and find its

boundaries, and most common use case(s).

My assumptions and scenario for doing the assignment was:

First of all I did some Internet Surfing to find principles of refactoring codes,writing clean code…
I watched video tutorials, studied parts of the book(Refactoring Improving the Design of Existing
Code Second Edition)

● changing Areas in code that require repeated code changes in multiple areas in order for the desired changes to work appropriately(tragedy calculation,credit calculation,comedy… and all the thing may be add in future)

● Moving features between objects in order to better distribute functionality among classe an safely moving functionality, creating new classes, and try to hiding implementation
details from the next abstraction level.

● categorized in a MVC software design pattern commonly used for developing user

interfaces that divide the related program logic,because in this case may be in future

they want to print statement bill in another manner, or develop the structure of loyalty of

customers without changing the user interfaces(statment bills)

● I used techniques that allow for more abstraction

● Encapsulate field – to force code to access the field with getter and setter methods!

● Generalize type to create more general types to allow for more sharing I used techniques for breaking code apart into more logical pieces of their behavioral.

● Extract class

● Extract method, to turn part of the one larger method into a new methods. By breaking down code in smaller pieces, it is more easily understandable.

● Rename method to changing the name into a new one that better to its purpose

● Calculation logic for calculation for customer in strategy pattern (also known as the policy pattern)

● Credit logic for loyalty services that may be in future used by a separate module

● Create a specific printing module for statement(for example in future we may need a module for show the result of calculation in a different manner )
