using Google.Cloud.Firestore;

namespace DoAn.Models;

[FirestoreData]
public class User
{
    [FirestoreProperty]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [FirestoreProperty]
    public string Username { get; set; } = string.Empty;

    [FirestoreProperty]
    public string Email { get; set; } = string.Empty;

    [FirestoreProperty]
    public string PasswordHash { get; set; } = string.Empty;

    [FirestoreProperty]
    public string FirstName { get; set; } = string.Empty;

    [FirestoreProperty]
    public string LastName { get; set; } = string.Empty;

    [FirestoreProperty]
    public string Bio { get; set; } = string.Empty;

    [FirestoreProperty]
    public string AvatarUrl { get; set; } = string.Empty;

    [FirestoreProperty]
    public string CoverUrl { get; set; } = string.Empty;

    [FirestoreProperty]
    public bool IsActive { get; set; } = true;

    [FirestoreProperty]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}