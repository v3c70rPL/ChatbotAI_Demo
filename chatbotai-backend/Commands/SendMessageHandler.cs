using chatbotai_backend.Models;
using chatbotai_backend.Services;
using MediatR;

namespace chatbotai_backend.Commands;

public class SendMessageHandler : IRequestHandler<SendMessageCommand, ChatMessage>
{
    private readonly IChatService _chatService;
    private readonly ILogger<SendMessageHandler> _logger;

    public SendMessageHandler(IChatService chatService, ILogger<SendMessageHandler> logger)
    {
        _chatService = chatService;
        _logger = logger;
    }

    public async Task<ChatMessage> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    { 
        _logger.LogInformation("Send message handler executed");
        return await _chatService.ProcessMessageAsync(request.ConversationId, request.UserMessage);
    }
}