using chatbotai_backend.Models;
using MediatR;

namespace chatbotai_backend.Queries;

public record GetChatHistoryQuery(string ConversationId) : IRequest<List<ChatMessage>>;