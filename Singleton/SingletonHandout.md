# Singleton Pattern


## Motivation
Perhaps the most controversial design pattern of all (also, the most polorizing one). Opinions aside, this pattern deals with the problem of ensuring only one object ever is created of a class. Database connectors, network sockets, resource handles -- are some of the use cases where having only one object of a kind is desired. No matter how many times the request for the instance creation is invoked, the pattern must ensure the instantiation happens only once. Post instantiation, the instance must be cached and subsequent requests are served with the cached instance. As such this is somewhat simple to implement. Usual technique is to block the access to the constructor and expose a static method to get the instance. Inside the class, the instance is a private static field.
***So, how can only one instance ever be created of a class no matter our invocation?*** -- This is the problem we solve.

## Definition
Ensure a calss only has one instance, and provide a global point of access to it.

## Understanding
*	global point of access is through static method

## Observations
1.	Create class (usually a sealed class) whose constructor is set private
2.	The class a private static field of itself initialized with new
3.	The instance is exposed through a static method
4.	Class initialization rules ensure the static field is initialized before the static method access 

## Remarks
1.	A straightforward implementation (which is sufficient in most cases) the singleton is eagerly created
2.	Most of the complexity of the singleton implementation comes with lazy instantiation, where the instance is created when the static method is first accessed. This obviously is prone to thread-safety issues. Aggressive locking impacts the performance on the other hand. Multicore processor architecture adds another layer of complexity with L2/L3 caching mechanisms.