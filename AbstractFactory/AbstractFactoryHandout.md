# Abstract Factory Pattern


## Motivation
This builds on the factory method pattern. The motivation for factory method comes from seprating the object creation from process from the use-site. So far in the factory method, the factory produced only one kind of an object. But the factory can create different kinds of objects that pertain to a common theme. For example, consider the abstraction of a furniture factory. Let's say a furniture factory produces 3 distinct items: chair, table, and cupboard. Now, say there are 2 different factories based on different themes: a plastic furniture factory and a wood furniture factory. Obviously, the items (chair, table, cupboard) manufactured by wood factory follow the common theme (made of wood).
***So, how can objects of a common theme be created?*** -- This is the problem we solve.

## Definition
Provide an interface for creating families of related or dependent objects without specifying their concrete classes.

## Understanding
*	family means a common theme (for a cloud service, AWS or Azure is a common theme)
*	related objects are distinct objects (chair is distinct from table, though both are made up of metal)
*	The objects are referenced by their abstraction (chair), not by their concrete classes (Maharaja chair with ivory finish)

## Observations
1.	Create an interface for a factory first. This involves APIs to create different products.
2.	Implement the factory interface in concrete factories

## Remarks
1.	Closely competes with **Prototype** pattern
2.	There is a concern that as the kinds of product objects increase so does the factory classes. Sometimes this complexity is uncalled for.