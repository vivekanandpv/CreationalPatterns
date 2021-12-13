# Factory Method Pattern


## Motivation
Creating objects is a very natual occurance in OOP. Intuitively you think of using **new** keyword for instantiation. *Keep in mind that new can only be used with concrete class (cannot be used with interfaces or abstract classes)*. But as the applications grow complex, this approach of direct instantiation creates rigid systems. Code is riddled with hard-coded objects. The client code has to look after instantiation (because it is the direct approach) and deal with trouble that goes with this approach (deal with parameters, creational exceptions, etc). This is not a scalable approach. As an IT professional you do not think it wise to build your own chair. Rather, you get it made by a factory. While dealing with the factory, you, as a client, is declarative (tell what you want) and the factory deals with the imperative details (how to create a chair). This is single-responsibility or separation of concerns in a sense.
***So, how can the client code be declarative about the object (called collaborator) creation?*** -- This is the problem we solve.

## Definition
Define an interface for creating an object, but let subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses. Defining a "virtual" constructor. The new operator considered harmful.

## Understanding
*	Interface can be an interface or an abstract class
*	Subclass implements the interface or derives from abstract class
*	A virtual function is a contract that is implemented or specialized down the class-hierarchy. A constructor cannot be virtual. But by implementing this pattern, we come quite near.

## Observations
1.	Create an interface for factory that abstract this virtual constructor
2.	Typically, the objects created thus conform to an interface as well
3.	Implement the factory and product (final object) interfaces
4.	Let the client use the factory to get the object through the factory

## Remarks
1.	Any static method that returns a freshly created/recycled object may not be the factory method
2.	The focus is to decouple the construction from the use-site (place it is supposed to be used)