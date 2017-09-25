# events-bus
Represents dictionary with events, linked between multiple publishers and subscribers.

Quick start:

	// get bus instance:
	var bus = new EventsBus();
	
	// subscribe to custom event:
	bus.Subscribe<MyEvent>(e => Console.Write("My event is triggerred: " + e));
	
	// publish event:
	bus.Publish(new MyEvent());
