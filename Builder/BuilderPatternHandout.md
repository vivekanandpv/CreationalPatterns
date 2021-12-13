# Builder Pattern


## Motivation
While creating complex objects (objects that have other objects composed within), the creation process becomes a complexity unto itself. We now have to deal with two related but different concerns: representation and creation. Representation means the state of the object. From a client perspective we wish to relegate this construction process so that both concerns are taken care of in a flexible way. 
***So, how can a unified construction process create objects with different representations?*** -- This is the problem we solve.

## Definition
Separate the construction of a complex object from its representation so that the same construction process can create different representations..

## Understanding
*	State and composition structure of the object is called *representation*

## Observations
1.	Create an interface for Builder that deals with discrete steps of object representation
2.	Create a Director which delegates the construction and representation to a Builder instance
3.	Client uses Director for construction of the object and gets the final object by the concrete Builder instance

## Remarks
1.	This is the classic pattern as described in GoF book. There are other variants of Builder pattern, in which the Director and Builder are merged.
2.	In some variations the final object may be polymorphic, though this approach is debatable