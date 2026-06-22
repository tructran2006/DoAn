using Google.Cloud.Firestore;

namespace DoAn.Models;

[FirestoreData]
public class Conversation
{
    [FirestoreProperty]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [FirestoreProperty]
    public List<string> Members { get; set; } = new();

    [FirestoreProperty]
    public bool IsGroup { get; set; }

    [FirestoreProperty]
    public string Name { get; set; } = string.Empty;

    [FirestoreProperty]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}