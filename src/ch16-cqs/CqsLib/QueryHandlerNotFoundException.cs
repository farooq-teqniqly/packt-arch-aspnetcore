namespace CqsLib;

internal class QueryHandlerNotFoundException : Exception
{
    public QueryHandlerNotFoundException(Type queryType) : base($"No handler found for query '{queryType}'.")
    {
    }
}