namespace CqsLib;

public class ChatRoom : IChatRoom
{
    private readonly List<IParticipant> _participants = [];
    private readonly List<ChatMessage> _messages = [];

    public string Name { get; }

    public ChatRoom(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void Add(IParticipant participant)
    {
        _participants.Add(participant);
    }

    public void Remove(IParticipant participant)
    {
        _participants.Remove(participant);
    }

    public IEnumerable<IParticipant> ListParticipants()
    {
        return _participants.AsReadOnly();
    }

    public void Add(ChatMessage message)
    {
        _messages.Add(message);
    }

    public IEnumerable<ChatMessage> ListMessages()
    {
        return _messages.AsReadOnly();
    }
}
