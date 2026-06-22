using Google.Cloud.Firestore;

namespace DoAn.Models;

[FirestoreData]
public class FriendRequest
{
    [FirestoreProperty]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [FirestoreProperty]
    public string SenderId { get; set; } = string.Empty;

    [FirestoreProperty]
    public string ReceiverId { get; set; } = string.Empty;

    [FirestoreProperty]
    public string Status { get; set; } = "pending";

    [FirestoreProperty]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}