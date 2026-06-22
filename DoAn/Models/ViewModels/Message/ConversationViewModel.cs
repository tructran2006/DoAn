public class ConversationViewModel
{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string LastMessage { get; set; } = string.Empty;

    public DateTime LastMessageTime { get; set; }

    public int UnreadCount { get; set; }
}