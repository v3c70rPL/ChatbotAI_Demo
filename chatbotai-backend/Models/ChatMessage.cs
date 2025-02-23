namespace chatbotai_backend.Models;

public class ChatMessage
{
    public int Id { get; set; }
    public string ConversationId { get; set; } = Guid.NewGuid().ToString();
    public string UserMessage { get; set; } = string.Empty;
    public string BotResponse { get; set; } = string.Empty;
    public int? Rating { get; set; } // 1 upvote, -1 downvote, null - not voted
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
