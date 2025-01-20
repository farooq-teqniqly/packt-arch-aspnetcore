namespace MediatorLib;

public interface IMessageWriter<in TMessage>
{
    void Write(TMessage message);
}
