
#### How to use

NPublisher - very simple observe / event aggregation library.

You can use it by 2 ways:
- Static - global one instance for all application.
- Instances - using by constructor. Events will be divided by instances.

##### How to use

1. Implement Your Message.

```
using NPublisher;

public class TestMessage : NMessage
{
        
}

```

2. Subscribe you event. (for GC cleaning protection You should keep subscription reference)

```
private readonly NSubscription _subscription

public SomeClass() 
{

  _subscription = NPublisher.SubscribeIt<TestMessage>(x =>
  {
    Console.WriteLine($"Subscribed event for message {x.GetType()}");
  });
}

```

3. Publish It! 
```
  NPublisher.PublishIt<TestMessage>();
```


If you want more code samples, check tests folder or my code repository NoteMe.
