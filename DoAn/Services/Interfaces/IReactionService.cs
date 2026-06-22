using DoAn.Models;
using DoAn.Models.Entities;

namespace DoAn.Services.Interfaces;

public interface IReactionService
{
    Task<PostReaction?> GetUserReactionAsync(
        string postId,
        string userId);

    Task ToggleLikeAsync(
        string postId,
        string userId);

    Task RemoveReactionAsync(
        string postId,
        string userId);

    Task<int> GetReactionCountAsync(
        string postId);
}