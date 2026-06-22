using DoAn.Models;
using DoAn.Models.Entities;

namespace DoAn.Services.Interfaces;

public interface IMessageService
{
    Task<Conversation?> GetConversationAsync(
        string conversationId);

    Task<List<Conversation>> GetUserConversationsAsync(
        string userId);

    Task<Conversation> CreateConversationAsync(
        List<string> members);

    Task SendMessageAsync(
        Message message);

    Task<List<Message>> GetMessagesAsync(
        string conversationId);

    Task MarkAsSeenAsync(
        string messageId);
}