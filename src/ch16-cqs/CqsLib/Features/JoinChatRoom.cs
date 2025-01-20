namespace CqsLib.Features;
public class JoinChatRoom
{
    public record Command(IChatRoom ChatRoom, IParticipant Requester) : ICommand;

    public class Handler : ICommandHandler<Command>
    {
        public void Handle(Command command)
        {
            command.ChatRoom.Add(command.Requester);
        }
    }
}
