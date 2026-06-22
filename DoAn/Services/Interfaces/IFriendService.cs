using DoAn.Models;
using DoAn.Models.Entities;

namespace DoAn.Services.Interfaces;

public interface IFriendService
{
    Task SendRequestAsync(
        string senderId,
        string receiverId);

    Task AcceptRequestAsync(
        string requestId);

    Task RejectRequestAsync(
        string requestId);

    Task CancelRequestAsync(
        string requestId);

    Task<bool> AreFriendsAsync(
        string userId,
        string friendId);

    Task<List<User>> GetFriendsAsync(
        string userId);

    Task<List<FriendRequest>> GetPendingRequestsAsync(
        string userId);

    Task RemoveFriendAsync(
        string userId,
        string friendId);
}