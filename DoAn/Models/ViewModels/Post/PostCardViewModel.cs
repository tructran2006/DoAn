public class PostCardViewModel
{
    public string Id { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string AvatarUrl { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public List<string> Images { get; set; } = new();

    public int LikeCount { get; set; }

    public int CommentCount { get; set; }

    public int ShareCount { get; set; }

    public bool IsLikedByCurrentUser { get; set; }

    public DateTime CreatedAt { get; set; }
}