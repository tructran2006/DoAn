public class NotificationViewModel
{
    public string Id { get; set; } = string.Empty;

    public string ActorId { get; set; } = string.Empty;

    public string ActorName { get; set; } = string.Empty;

    public string ActorAvatar { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public bool IsRead { get; set; }

    public DateTime CreatedAt { get; set; }
}