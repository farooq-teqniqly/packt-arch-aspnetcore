namespace MediatorLib;

public class ChatRoom : IChatRoom
{
    private readonly List<IParticipant> _participants = [];

    public void Join(IParticipant participant)
    {
        ArgumentNullException.ThrowIfNull(participant);
        _participants.Add(participant);
        participant.ChatRoomJoined(this);
        Send(new ChatMessage(participant, "joined channel"));
    }

    public void Send(ChatMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _participants.ForEach(p => p.ReceiveMessage(message));
    }
}
