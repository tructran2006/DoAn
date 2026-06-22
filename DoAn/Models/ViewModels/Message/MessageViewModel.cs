public class MessageViewModel
{
    public string Id { get; set; } = string.Empty;

    public string SenderId { get; set; } = string.Empty;

    public string SenderName { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public bool IsMine { get; set; }

    public DateTime CreatedAt { get; set; }
}