using Google.Cloud.Firestore;

namespace DoAn.Models;

[FirestoreData]
public class Post
{
    [FirestoreProperty]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [FirestoreProperty]
    public string UserId { get; set; } = string.Empty;

    [FirestoreProperty]
    public string Content { get; set; } = string.Empty;

    [FirestoreProperty]
    public List<string> Images { get; set; } = new();

    [FirestoreProperty]
    public string Privacy { get; set; } = "public";

    [FirestoreProperty]
    public int LikeCount { get; set; }

    [FirestoreProperty]
    public int CommentCount { get; set; }

    [FirestoreProperty]
    public int ShareCount { get; set; }

    [FirestoreProperty]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [FirestoreProperty]
    public DateTime? UpdatedAt { get; set; }
}