using Google.Cloud.Firestore;
using DoAn.Models;
using DoAn.Services.Interfaces;

namespace DoAn.Services;

public class NotificationService : INotificationService
{
    private readonly FirestoreDb _db;

    public NotificationService(FirebaseService firebase)
    {
        _db = firebase.Db;
    }

    public async Task CreateAsync(Notification notification)
    {
        await _db.Collection("notifications")
            .Document(notification.Id)
            .SetAsync(notification);
    }

    public async Task<List<Notification>> GetUserNotificationsAsync(
        string userId)
    {
        var snapshot = await _db.Collection("notifications")
            .WhereEqualTo("UserId", userId)
            .GetSnapshotAsync();

        return snapshot.Documents
            .Select(x => x.ConvertTo<Notification>())
            .OrderByDescending(x => x.CreatedAt)
            .ToList();
    }

    public async Task MarkAsReadAsync(
        string notificationId)
    {
        await _db.Collection("notifications")
            .Document(notificationId)
            .UpdateAsync("IsRead", true);
    }

    public async Task MarkAllAsReadAsync(
        string userId)
    {
        var snapshot = await _db.Collection("notifications")
            .WhereEqualTo("UserId", userId)
            .WhereEqualTo("IsRead", false)
            .GetSnapshotAsync();

        foreach (var doc in snapshot.Documents)
        {
            await doc.Reference
                .UpdateAsync("IsRead", true);
        }
    }

    public async Task DeleteAsync(
        string notificationId)
    {
        await _db.Collection("notifications")
            .Document(notificationId)
            .DeleteAsync();
    }
}