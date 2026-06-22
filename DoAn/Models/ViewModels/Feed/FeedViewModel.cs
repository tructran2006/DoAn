public class FeedViewModel
{
    public List<PostCardViewModel> Posts { get; set; } = new();

    public List<FriendSuggestionViewModel> Suggestions { get; set; } = new();

    public List<NotificationViewModel> Notifications { get; set; } = new();
}