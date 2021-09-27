# AddToCartSolution 🎉

AddToCartSolution contains two project which are CartAPI and StockAPI. Client can trigger a processes for adding an item into the cart.
CartAPI will work with StockAPI for calculating available product count and manage the process.

Some features of the solution ✨

* CartAPI talks with StockAPI via token authentication.
* APIs have middlewares for exception handling.
* APIs have been developed according to DDD layer architecture (for more info: http://dddsample.sourceforge.net/architecture.html)
* StockAPI uses Event Sourcing pattern for holding the history of stock events. (for more info: https://martinfowler.com/eaaDev/EventSourcing.html#:~:text=The%20fundamental%20idea%20of%20Event,as%20the%20application%20state%20itself.)
* StockAPI has access for two data sources (Stock.json & StockEvent.json), so I seperated two access transactions via CQRS & Mediator patterns. MediatR lib has been used.
* Healthcheck of APIs can be accessed with _/hc_ path.
* APIs have swagger documentation.
* Both APIs recording their logs under Logs/log.txt file, via SeriLog.
* Both APIs contain unit tests. xUnit lib has been used.

## What could be better ? 💡

Handling the event sourcing pattern with a queue system (rabbitmq or kafka) would be great since stock events are suitable for being eventually consistent, but I didn't take this path since it would add a big, third party component in the system.

## Diagrams 📸

*High-Level Diagram of Solution*

![addtocart](https://user-images.githubusercontent.com/47561392/134829457-29baf3e3-1a17-4f8d-b3d8-b25777fc1178.png)

*Low-Level Diagram of CartAPI*

![Screenshot_2](https://user-images.githubusercontent.com/47561392/134829492-789d2711-a264-4ab6-bcae-fb83a2abce03.png)

*Low-Level Diagram of StockAPI*

![Screenshot_3](https://user-images.githubusercontent.com/47561392/134829516-201a2263-499c-4012-8e85-eed142a67099.png)
