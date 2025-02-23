using chatbotai_backend.Models;

namespace chatbotai_backend.Repositories;

public interface IChatRepository
{
    Task<List<ChatMessage>> GetConversationHistoryAsync(string conversationId);

    Task SaveMessageAsync(ChatMessage message);
    Task<bool> UpdateResponseRatingAsync(int messageId, int rating);
    Task<bool> UpdateResponseBotAnswerAsync(int messageId, string botPartialAnswerToSave);
}