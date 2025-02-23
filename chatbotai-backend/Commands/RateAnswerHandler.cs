using chatbotai_backend.Repositories;
using MediatR;

namespace chatbotai_backend.Commands;

public class RateAnswerHandler : IRequestHandler<RateAnswerCommand, bool>
{
    private readonly IChatRepository _chatRepository;
    private readonly ILogger<RateAnswerHandler> _logger;

    public RateAnswerHandler(IChatRepository chatRepository, ILogger<RateAnswerHandler> logger)
    {
        _chatRepository = chatRepository;
        _logger = logger;
    }

    public async Task<bool> Handle(RateAnswerCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Rate answer handler executed");
        await _chatRepository.UpdateResponseRatingAsync(request.MessageId, request.Rating);
        return true;
    }
}