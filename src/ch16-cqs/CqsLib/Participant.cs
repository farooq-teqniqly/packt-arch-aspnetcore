using CqsLib.Features;

namespace CqsLib;

public class Participant : IParticipant
{
    private readonly IMediator _mediator;
    private readonly IMessageWriter<ChatMessage> _messageWriter;
    public string Name { get; }

    public Participant(string name, IMediator mediator, IMessageWriter<ChatMessage> messageWriter)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _messageWriter = messageWriter ?? throw new ArgumentNullException(nameof(messageWriter));
    }
    public void Join(IChatRoom chatRoom)
    {
        _mediator.Send(new JoinChatRoom.Command(chatRoom, this));
    }

    public void Leave(IChatRoom chatRoom)
    {
        _mediator.Send(new LeaveChatRoom.Command(chatRoom, this));
    }

    public void SendMessageTo(IChatRoom chatRoom, string message)
    {
        var chatMessage = new ChatMessage(this, message);
        var command = new SendChatMessage.Command(chatRoom, chatMessage);
        _mediator.Send(command);
    }

    public void NewMessageReceivedFrom(IChatRoom chatRoom, ChatMessage message)
    {
        _messageWriter.Write(chatRoom, message);
    }

    public IEnumerable<IParticipant> ListParticipantsOf(IChatRoom chatRoom)
    {
        var query = new ListParticipants.Query(chatRoom, this);
        return _mediator.Send<ListParticipants.Query, IEnumerable<IParticipant>>(query);
    }

    public IEnumerable<ChatMessage> ListMessagesOf(IChatRoom chatRoom)
    {
        var query = new ListMessages.Query(chatRoom, this);
        return _mediator.Send<ListMessages.Query, IEnumerable<ChatMessage>>(query);
    }
}