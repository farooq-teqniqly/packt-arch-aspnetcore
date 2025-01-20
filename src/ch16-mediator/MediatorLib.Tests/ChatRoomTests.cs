namespace MediatorLib.Tests;

public class ChatRoomTests
{
    [Fact]
    public void ChatRoot_participants_should_send_and_receive_messages()
    {
        // Arrange
        var (kingChat, king) = CreateTestUser("King");
        var (kelleyChat, kelley) = CreateTestUser("Kelley");
        var (daveenChat, daveen) = CreateTestUser("Daveen");
        var (rutterChat, _) = CreateTestUser("Rutter");

        var chatRoom = new ChatRoom();

        // Act
        chatRoom.Join(king);
        chatRoom.Join(kelley);

        king.Send("Hey!");
        kelley.Send("What's up King?");

        chatRoom.Join(daveen);

        king.Send("Everything is great, I joined the CrazyChatRoom!");
        daveen.Send("Hey King!");
        king.Send("Hey Daveen!");

        // Assert

        Assert.Empty(rutterChat.Output.ToString());

        Assert.Equal("[King]: joined channel\r\n[Kelley]: joined channel\r\n[King]: Hey!\r\n[Kelley]: What's up King?\r\n[Daveen]: joined channel\r\n[King]: Everything is great, I joined the CrazyChatRoom!\r\n[Daveen]: Hey King!\r\n[King]: Hey Daveen!\r\n", kingChat.Output.ToString());

        Assert.Equal("[Kelley]: joined channel\r\n[King]: Hey!\r\n[Kelley]: What's up King?\r\n[Daveen]: joined channel\r\n[King]: Everything is great, I joined the CrazyChatRoom!\r\n[Daveen]: Hey King!\r\n[King]: Hey Daveen!\r\n", kelleyChat.Output.ToString());

        Assert.Equal("[Daveen]: joined channel\r\n[King]: Everything is great, I joined the CrazyChatRoom!\r\n[Daveen]: Hey King!\r\n[King]: Hey Daveen!\r\n", daveenChat.Output.ToString());
    }

    private (TestMessageWriter, User) CreateTestUser(string name)
    {
        var writer = new TestMessageWriter();
        var user = new User(writer, name);
        return (writer, user);
    }
}
