using chatbotai_backend.Commands;
using chatbotai_backend.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace chatbotai_backend.Controllers;

[Route("api/chat")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly IMediator _mediator;

    public ChatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Sends a message to the chatbot and gets a response.
    /// </summary>
    [HttpPost("send-message")]
    public async Task<IActionResult> SendMessage([FromBody] SendMessageCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    /// <summary>
    /// Retrieves the conversation history for a given conversation ID.
    /// </summary>
    [HttpGet("history/{conversationId}")]
    public async Task<IActionResult> GetChatHistory(string conversationId)
    {
        var history = await _mediator.Send(new GetChatHistoryQuery(conversationId));
        return Ok(history);
    }

    /// <summary>
    /// Allows users to rate chatbot answers.
    /// </summary>
    [HttpPost("rate-answer")]
    public async Task<IActionResult> RateAnswer([FromBody] RateAnswerCommand command)
    {
        var success = await _mediator.Send(command);
        return success ? Ok() : BadRequest("Failed to rate anwser.");
    }
    
    /// <summary>
    /// Allows users to stop and save bot partial answer.
    /// </summary>
    [HttpPost("save-partial-answer")]
    public async Task<IActionResult> SavePartialAnswer([FromBody] SavePartialAnswerCommand command)
    {
        var success = await _mediator.Send(command);
        return success ? Ok() : BadRequest("Failed to save partial anwser.");
    }
}