namespace CqsLib;
public record ChatMessage(IParticipant Sender, string Message)
{
    public DateTime CreatedDate { get; } = DateTime.UtcNow;
}
