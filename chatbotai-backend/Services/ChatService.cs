using chatbotai_backend.Models;
using chatbotai_backend.Repositories;

namespace chatbotai_backend.Services;

public class ChatService : IChatService
{
    private readonly IChatRepository _chatRepository;

    public ChatService(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    /// <summary>
    /// Processes a user message and generates a simulated chatbot response.
    /// </summary>
    public async Task<ChatMessage> ProcessMessageAsync(string conversationId, string message)
    {
        // Save user message
        var userMessage = new ChatMessage
        {
            ConversationId = conversationId,
            UserMessage = message,
            BotResponse = string.Empty,
            Timestamp = DateTime.UtcNow
        };

        await _chatRepository.SaveMessageAsync(userMessage);

        // Simulated AI response
        string botResponse = GenerateMockAiResponse(message);

        // Save bot response
        var botMessage = new ChatMessage
        {
            ConversationId = conversationId,
            UserMessage = message,
            BotResponse = botResponse,
            Timestamp = DateTime.UtcNow
        };

        await _chatRepository.SaveMessageAsync(botMessage);

        return botMessage;
    }
    
    private string GenerateMockAiResponse(string message)
    {
        var random = new Random();
        
        var mockAiAnswers = new List<string>() {
            "1Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eu viverra sem. Nunc commodo laoreet orci, quis vehicula leo hendrerit eget. Aliquam faucibus quam ligula, fermentum volutpat enim dignissim a. Donec maximus est ac elit dignissim dictum nec vel mauris. Ut sollicitudin sapien a erat faucibus condimentum. Morbi interdum, erat ut interdum ultricies, elit leo lacinia dolor, eu dictum lacus neque sit amet arcu. Sed a tempor arcu. Quisque pretium augue nec felis semper, ac mattis lectus elementum.",
            "2Pellentesque varius nisl lectus, a auctor libero dignissim quis. Integer pharetra, lorem non laoreet dignissim, neque nisi sodales urna, a porta est orci quis nisl. Etiam diam est, auctor et semper ut, pretium quis est. Donec hendrerit blandit massa, in cursus nisl rhoncus in. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean viverra malesuada sollicitudin. Curabitur eu scelerisque justo. Cras eu metus ac dui fermentum porttitor. Morbi vehicula, diam id tempus luctus, lectus tellus efficitur elit, at euismod mi tortor vitae nulla. Sed magna turpis, pulvinar ac consequat sit amet, pulvinar eu nisl. Nam hendrerit purus velit, non accumsan massa volutpat sed. Maecenas gravida ante dolor, et ultricies nunc tristique ac. Morbi lobortis facilisis mi, in ultrices ipsum ullamcorper ut.Vivamus eleifend, mi facilisis ultricies tincidunt, lorem nisi malesuada arcu, in condimentum purus nulla a sapien. Phasellus vel ante ac ex cursus scelerisque. Aliquam rutrum nunc nec nibh dignissim fringilla. Donec a magna sit amet nunc malesuada pulvinar. Donec interdum sodales tempor. Ut nec mi gravida, commodo orci non, malesuada sem. Donec maximus ultricies lectus. Fusce eu egestas lorem. Nunc vel feugiat massa. Nulla vel sollicitudin justo, imperdiet rhoncus nulla. Curabitur auctor eros in elit sodales ullamcorper. In hac habitasse platea dictumst. Integer ac sodales magna.",
            "3Vivamus eleifend, mi facilisis ultricies tincidunt, lorem nisi malesuada arcu, in condimentum purus nulla a sapien. Phasellus vel ante ac ex cursus scelerisque. Aliquam rutrum nunc nec nibh dignissim fringilla. Donec a magna sit amet nunc malesuada pulvinar. Donec interdum sodales tempor. Ut nec mi gravida, commodo orci non, malesuada sem. Donec maximus ultricies lectus. Fusce eu egestas lorem. Nunc vel feugiat massa. Nulla vel sollicitudin justo, imperdiet rhoncus nulla. Curabitur auctor eros in elit sodales ullamcorper. In hac habitasse platea dictumst. Integer ac sodales magna.Morbi eu interdum massa. Curabitur malesuada eu odio ultricies aliquet. Mauris porttitor in nisl ut molestie. Interdum et malesuada fames ac ante ipsum primis in faucibus. Phasellus a est vel risus sodales condimentum eu sit amet turpis. Quisque non porta libero, vel efficitur sem. In porttitor lobortis felis eget scelerisque.Sed condimentum, eros in fermentum luctus, nisi tortor condimentum ligula, a faucibus nunc nulla vel ligula. Fusce vitae ante dui. Curabitur lorem ipsum, euismod ac ultricies sed, gravida vitae orci. Vivamus pretium congue felis sit amet egestas. Sed sed vestibulum turpis. Integer consequat, ipsum vitae commodo tincidunt, leo leo tempor magna, eu tempor purus justo ut nulla. Duis id neque scelerisque, interdum magna ac, venenatis sapien. Cras sed eros arcu. Nunc rhoncus vitae odio vel sodales. Ut iaculis mi lobortis tincidunt scelerisque. Donec mollis vestibulum ligula a pulvinar. Nam et viverra nulla."
            };

        return mockAiAnswers[random.Next(mockAiAnswers.Count)];
    }
}