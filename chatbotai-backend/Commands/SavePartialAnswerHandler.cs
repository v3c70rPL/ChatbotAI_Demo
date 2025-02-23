using chatbotai_backend.Repositories;
using MediatR;

namespace chatbotai_backend.Commands;

public class SavePartialAnswerHandler: IRequestHandler<SavePartialAnswerCommand, bool>
{
    private readonly IChatRepository _chatRepository;
    private readonly ILogger<SavePartialAnswerHandler> _logger;

    public SavePartialAnswerHandler(IChatRepository chatRepository, ILogger<SavePartialAnswerHandler> logger)
    {
        _chatRepository = chatRepository;
        _logger = logger;
    }

    public async Task<bool> Handle(SavePartialAnswerCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Save partial answer handler executed");
        await _chatRepository.UpdateResponseBotAnswerAsync(request.MessageId, request.BotPartialAnswer);
        return true;
    }
}