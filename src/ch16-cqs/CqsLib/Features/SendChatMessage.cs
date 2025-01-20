namespace CqsLib.Features;

public class SendChatMessage
{
    public record Command(IChatRoom ChatRoom, ChatMessage Message) : ICommand;

    public class Handler : ICommandHandler<Command>
    {
        public void Handle(Command command)
        {
            command.ChatRoom.Add(command.Message);
            var participants = command.ChatRoom.ListParticipants();

            foreach (var participant in participants)
            {
                participant.NewMessageReceivedFrom(command.ChatRoom, command.Message);
            }
        }
    }
}