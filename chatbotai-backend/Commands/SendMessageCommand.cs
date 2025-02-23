using chatbotai_backend.Models;
using MediatR;

namespace chatbotai_backend.Commands;

public record SendMessageCommand(string ConversationId, string UserMessage) : IRequest<ChatMessage>;