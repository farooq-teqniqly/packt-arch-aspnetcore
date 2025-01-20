namespace CqsLib;

internal class HandlerList
{
    private readonly List<object> _commandHandlers = [];
    private readonly List<object> _queryHandlers = [];

    public void Add<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand
    {
        ArgumentNullException.ThrowIfNull(nameof(handler));
        _commandHandlers.Add(handler);
    }

    public void Add<TQuery, TReturn>(IQueryHandler<TQuery, TReturn> handler) where TQuery : IQuery<TReturn>
    {
        ArgumentNullException.ThrowIfNull(nameof(handler));
        _queryHandlers.Add(handler);
    }

    public IEnumerable<ICommandHandler<TCommand>> FindAll<TCommand>() where TCommand : ICommand
    {
        foreach (var handler in _commandHandlers)
        {
            if (handler is ICommandHandler<TCommand> output)
            {
                yield return output;
            }
        }
    }

    public IQueryHandler<TQuery, TReturn> Find<TQuery, TReturn>() where TQuery : IQuery<TReturn>
    {
        foreach (var handler in _queryHandlers)
        {
            if (handler is IQueryHandler<TQuery, TReturn> output)
            {
                return output;
            }
        }

        throw new QueryHandlerNotFoundException(typeof(TQuery));
    }
}