
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
    

public class ProfileViewModel
{
    public string Id { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string AvatarUrl { get; set; } = string.Empty;

    public string CoverUrl { get; set; } = string.Empty;

    public string Bio { get; set; } = string.Empty;

    public int FriendCount { get; set; }

    public int PostCount { get; set; }

    public bool IsFriend { get; set; }

    public bool IsOwner { get; set; }
}