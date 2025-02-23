using MediatR;

namespace chatbotai_backend.Commands;

public record RateAnswerCommand(int MessageId, int Rating) : IRequest<bool>;