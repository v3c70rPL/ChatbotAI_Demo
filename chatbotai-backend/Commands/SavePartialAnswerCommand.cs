using MediatR;

namespace chatbotai_backend.Commands;

public record SavePartialAnswerCommand(int MessageId, string BotPartialAnswer) : IRequest<bool>;