using chatbotai_backend.Models;
using chatbotai_backend.Repositories;
using MediatR;

namespace chatbotai_backend.Queries;

public class GetChatHistoryHandler : IRequestHandler<GetChatHistoryQuery, List<ChatMessage>>
{
    private readonly IChatRepository _chatRepository;
    private readonly ILogger<GetChatHistoryHandler> _logger;

    public GetChatHistoryHandler(IChatRepository chatRepository, ILogger<GetChatHistoryHandler> logger)
    {
        _chatRepository = chatRepository;
        _logger = logger;
    }

    public async Task<List<ChatMessage>> Handle(GetChatHistoryQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get chat history handler executed");
        return await _chatRepository.GetConversationHistoryAsync(request.ConversationId);
    }
}