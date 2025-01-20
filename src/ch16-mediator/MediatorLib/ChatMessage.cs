namespace MediatorLib;

public record ChatMessage
{
    public ChatMessage(IParticipant Sender, string Content)
    {
        this.Sender = Sender ?? throw new ArgumentNullException(nameof(Sender));
        this.Content = Content;
    }

    public IParticipant Sender { get; init; }
    public string Content { get; init; }

    public void Deconstruct(out IParticipant sender, out string content)
    {
        sender = Sender;
        content = Content;
    }
}
