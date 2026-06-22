using DoAn.Models;

using DoAn.Services.Interfaces;
using Google.Cloud.Firestore;

namespace DoAn.Services;

public class MessageService : IMessageService
{
    private readonly FirestoreDb _db;

    public MessageService(FirebaseService firebase)
    {
        _db = firebase.Db;
    }

    public async Task<Conversation> CreateConversationAsync(
        List<string> members)
    {
        var conversation = new Conversation
        {
            Id = Guid.NewGuid().ToString(),
            Members = members,
            IsGroup = members.Count > 2,
            CreatedAt = DateTime.UtcNow
        };

        await _db.Collection("conversations")
            .Document(conversation.Id)
            .SetAsync(conversation);

        return conversation;
    }

    public async Task<Conversation?> GetConversationAsync(
        string conversationId)
    {
        var doc = await _db.Collection("conversations")
            .Document(conversationId)
            .GetSnapshotAsync();

        return doc.Exists
            ? doc.ConvertTo<Conversation>()
            : null;
    }

    public async Task<List<Conversation>> GetUserConversationsAsync(
        string userId)
    {
        var snapshot = await _db.Collection("conversations")
            .GetSnapshotAsync();

        return snapshot.Documents
            .Select(x => x.ConvertTo<Conversation>())
            .Where(x => x.Members.Contains(userId))
            .ToList();
    }

    public async Task SendMessageAsync(Message message)
    {
        await _db.Collection("messages")
            .Document(message.Id)
            .SetAsync(message);
    }

    public async Task<List<Message>> GetMessagesAsync(
        string conversationId)
    {
        var snapshot = await _db.Collection("messages")
            .WhereEqualTo("ConversationId", conversationId)
            .GetSnapshotAsync();

        return snapshot.Documents
            .Select(x => x.ConvertTo<Message>())
            .OrderBy(x => x.CreatedAt)
            .ToList();
    }

    public async Task MarkAsSeenAsync(
        string messageId)
    {
        await _db.Collection("messages")
            .Document(messageId)
            .UpdateAsync("IsSeen", true);
    }
}