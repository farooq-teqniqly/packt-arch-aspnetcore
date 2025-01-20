namespace CqsLib.Features;

public class LeaveChatRoom
{
    public record Command(IChatRoom ChatRoom, IParticipant Requester) : ICommand;

    public class Handler : ICommandHandler<Command>
    {
        public void Handle(Command command)
        {
            command.ChatRoom.Remove(command.Requester);
        }
    }
}