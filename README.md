# AddToCartSolution 🎉

AddToCartSolution contains two project which are CartAPI and StockAPI. Client can trigger a processes for adding an item into the cart.
CartAPI will work with StockAPI for calculating available product count and manage the process.

Some features of the solution ✨

* CartAPI talks with StockAPI via token authentication.
* APIs have middlewares for exception handling.
* APIs have been developed according to DDD layer architecture (for more info: http://dddsample.sourceforge.net/architecture.html)
* StockAPI uses Event Sourcing pattern for holding the history of stock events. (for more info: https://martinfowler.com/eaaDev/EventSourcing.html#:~:text=The%20fundamental%20idea%20of%20Event,as%20the%20application%20state%20itself.)
* StockAPI has access for two data sources (Stock.json & StockEvent.json), so I seperated two access transactions via CQRS & Mediator patterns. MediatR lib has been used.
* Healthcheck of APIs can be checked with _/hc_ path.
* APIs have swagger documentation.

## What could be better ? 💡

Handling the event sourcing pattern with a queue system (rabbitmq or kafka) would be great since stock events are suitable for being eventually consistent, but I didn't take this path since it would add a big, third party component in the system.
