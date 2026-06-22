using DoAn.Models;

namespace DoAn.Services.Interfaces;

public interface INotificationService
{
    Task CreateAsync(Notification notification);

    Task<List<Notification>> GetUserNotificationsAsync(
        string userId);

    Task MarkAsReadAsync(
        string notificationId);

    Task MarkAllAsReadAsync(
        string userId);

    Task DeleteAsync(
        string notificationId);
}