using Google.Cloud.Firestore;

namespace DoAn.Models;

[FirestoreData]
public class Friend
{
    [FirestoreProperty]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [FirestoreProperty]
    public string UserId { get; set; } = string.Empty;

    [FirestoreProperty]
    public string FriendId { get; set; } = string.Empty;

    [FirestoreProperty]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}