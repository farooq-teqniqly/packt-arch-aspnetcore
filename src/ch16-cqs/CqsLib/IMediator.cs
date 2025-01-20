


namespace CqsLib;

public interface IMediator
{
    TReturn Send<TQuery, TReturn>(TQuery query) where TQuery : IQuery<TReturn>;
    void Send<TCommand>(TCommand command) where TCommand : ICommand;
    void Register<TCommand>(ICommandHandler<TCommand> commandHandler) where TCommand : ICommand;
    void Register<TQuery, TReturn>(IQueryHandler<TQuery, TReturn> queryHandler) where TQuery : IQuery<TReturn>;
}
