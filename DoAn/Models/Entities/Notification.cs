using Google.Cloud.Firestore;

namespace DoAn.Models;

[FirestoreData]
public class Notification
{
    [FirestoreProperty]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [FirestoreProperty]
    public string UserId { get; set; } = string.Empty;

    [FirestoreProperty]
    public string ActorId { get; set; } = string.Empty;

    [FirestoreProperty]
    public string Type { get; set; } = string.Empty;

    [FirestoreProperty]
    public string Message { get; set; } = string.Empty;

    [FirestoreProperty]
    public bool IsRead { get; set; }

    [FirestoreProperty]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}