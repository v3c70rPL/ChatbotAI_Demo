using chatbotai_backend.Models;

namespace chatbotai_backend.Services;

public interface IChatService
{
    Task<ChatMessage> ProcessMessageAsync(string conversationId, string message);
}