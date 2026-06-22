using Google.Cloud.Firestore;

namespace DoAn.Models;

[FirestoreData]
public class Message
{
    [FirestoreProperty]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [FirestoreProperty]
    public string ConversationId { get; set; } = string.Empty;

    [FirestoreProperty]
    public string SenderId { get; set; } = string.Empty;

    [FirestoreProperty]
    public string Content { get; set; } = string.Empty;

    [FirestoreProperty]
    public bool IsSeen { get; set; }

    [FirestoreProperty]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}