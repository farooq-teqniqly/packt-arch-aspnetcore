namespace CqsLib;

internal class HandlerDictionary
{
    private readonly Dictionary<Type, HandlerList> _handlers = [];

    public void AddHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand
    {
        var type = typeof(TCommand);
        EnforceTypeEntry(type);
        var registeredHandlers = _handlers[type];
        registeredHandlers.Add(handler);
    }

    public void AddHandler<TQuery, TReturn>(IQueryHandler<TQuery, TReturn> handler) where TQuery : IQuery<TReturn>
    {
        var type = typeof(TQuery);
        EnforceTypeEntry(type);
        var registeredHandlers = _handlers[type];
        registeredHandlers.Add(handler);
    }

    public IEnumerable<ICommandHandler<TCommand>> FindAll<TCommand>() where TCommand : ICommand
    {
        var type = typeof(TCommand);
        EnforceTypeEntry(type);
        var registeredHandlers = _handlers[type];
        return registeredHandlers.FindAll<TCommand>();
    }

    public IQueryHandler<TQuery, TReturn> Find<TQuery, TReturn>() where TQuery : IQuery<TReturn>
    {
        var type = typeof(TQuery);
        EnforceTypeEntry(type);
        var registeredHandlers = _handlers[type];
        return registeredHandlers.Find<TQuery, TReturn>();
    }

    private void EnforceTypeEntry(Type type)
    {
        if (_handlers.TryGetValue(type, out _))
        {
            return;
        }

        var value = new HandlerList();
        _handlers.Add(type, value);
    }
}