using chatbotai_backend.Data;
using chatbotai_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace chatbotai_backend.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly ChatDbContext _context;

    public ChatRepository(ChatDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves the conversation history based on conversation ID.
    /// </summary>
    public async Task<List<ChatMessage>> GetConversationHistoryAsync(string conversationId)
    {
        return await _context.ChatMessages
            .Where(m => m.ConversationId == conversationId)
            .OrderBy(m => m.Timestamp)
            .ToListAsync();
    }

    /// <summary>
    /// Saves a chat message to the database.
    /// </summary>
    public async Task SaveMessageAsync(ChatMessage message)
    {
        await _context.ChatMessages.AddAsync(message);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates the rating of a chatbot response.
    /// </summary>
    public async Task<bool> UpdateResponseRatingAsync(int messageId, int rating)
    {
        var message = await _context.ChatMessages.FindAsync(messageId);
        if (message == null) return false;

        message.Rating = rating;
        await _context.SaveChangesAsync();
        return true;
    }
    
    // <summary>
    /// Updates the bot response (answer) - extra handler for user request to stop answering user question
    /// </summary>
    public async Task<bool> UpdateResponseBotAnswerAsync(int messageId, string botPartialAnswerToSave)
    {
        var message = await _context.ChatMessages.FindAsync(messageId);
        if (message == null) return false;

        message.BotResponse = botPartialAnswerToSave;
        await _context.SaveChangesAsync();
        return true;
    }
}