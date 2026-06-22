public class CommentViewModel
{
    public string Id { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string AvatarUrl { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public int LikeCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<CommentViewModel> Replies { get; set; } = new();
}