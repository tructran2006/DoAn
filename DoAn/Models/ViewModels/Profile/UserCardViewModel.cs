namespace DoAn.Models.ViewModels.Profile;

public class UserCardViewModel
{
    public string Id { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string AvatarUrl { get; set; } = string.Empty;

    public string Bio { get; set; } = string.Empty;

    public int MutualFriendsCount { get; set; }

    public bool IsFriend { get; set; }

    public bool IsCurrentUser { get; set; }

    public bool HasPendingRequest { get; set; }
}