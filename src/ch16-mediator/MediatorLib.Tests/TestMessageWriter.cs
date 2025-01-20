using System.Text;

namespace MediatorLib.Tests;

internal class TestMessageWriter : IMessageWriter<ChatMessage>
{
    public StringBuilder Output { get; } = new();

    public void Write(ChatMessage message)
    {
        Output.AppendLine($"[{message.Sender.Name}]: {message.Content}");
    }
}
