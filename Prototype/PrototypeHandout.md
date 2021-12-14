# Prototype Pattern


## Motivation
Object creation and use-site decoupling is a recurring theme in creational patterns. While factory method surely provides a virtual constructor and abstract factory takes it further with creation of objects of a common theme, both rely on construction mechanism. In some cases, we would like to model the instance creation based on the existing instance. It is like copying a document. Such an existing object is called a prototype. The *prototype* pattern deals with creation by cloning, which is invoked through an existing object. This is especially important for the languages where class-based inheritance is the rule (C++, Java, C#, etc).
***So, how can we an object to create another object?*** -- This is the problem we solve.

## Definition
Specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.

## Understanding
*	prototype is a regular object, but knows how to clone itself, like a biological cell

## Observations
1.	Define an interface with clone as a method
2.	Let the implementing class specialize the cloning
3.	Additionally, a registry to provide initial prototypes can be used 

## Remarks
1.	In factory method and abstract factory the virtual constructor is the crux, here it is the process of cloning
2.	Cloning is the responsibility of the object itself
3.	That apart, it is quite similar to factory method
4.	Implementing the cloning is a tricky issue (shallow vs deep cloning)