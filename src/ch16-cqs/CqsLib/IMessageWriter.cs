namespace CqsLib;

public interface IMessageWriter<in TMessage>
{
    void Write(IChatRoom chatRoom, TMessage message);
}
