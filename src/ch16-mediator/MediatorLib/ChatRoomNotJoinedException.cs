namespace MediatorLib;

public class ChatRoomNotJoinedException : Exception
{
    public ChatRoomNotJoinedException() : base("You must join a chat room before sending a message.")
    {

    }
}
