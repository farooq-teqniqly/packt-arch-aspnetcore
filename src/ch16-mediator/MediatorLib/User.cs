namespace MediatorLib;

public class User : IParticipant
{
    private readonly IMessageWriter<ChatMessage> _messageWriter;
    private IChatRoom? _chatRoom;

    public string Name { get; }

    public User(IMessageWriter<ChatMessage> messageWriter, string name)
    {
        _messageWriter = messageWriter ?? throw new ArgumentNullException(nameof(messageWriter));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
    public void Send(string message)
    {
        if (_chatRoom is null)
        {
            throw new ChatRoomNotJoinedException();
        }

        _chatRoom.Send(new ChatMessage(this, message));
    }

    public void ReceiveMessage(ChatMessage message)
    {
        _messageWriter.Write(message);
    }

    public void ChatRoomJoined(IChatRoom chatRoom)
    {
        _chatRoom = chatRoom ?? throw new ArgumentNullException(nameof(chatRoom));
    }
}
