using Google.Cloud.Firestore;
using DoAn.Models;
using DoAn.Services.Interfaces;

namespace DoAn.Services;

public class FriendService : IFriendService
{
    private readonly FirestoreDb _db;

    public FriendService(FirebaseService firebase)
    {
        _db = firebase.Db;
    }

    public async Task SendRequestAsync(
        string senderId,
        string receiverId)
    {
        var request = new FriendRequest
        {
            Id = Guid.NewGuid().ToString(),
            SenderId = senderId,
            ReceiverId = receiverId,
            Status = "pending",
            CreatedAt = DateTime.UtcNow
        };

        await _db.Collection("friend_requests")
            .Document(request.Id)
            .SetAsync(request);
    }

    public async Task AcceptRequestAsync(string requestId)
    {
        var doc = await _db.Collection("friend_requests")
            .Document(requestId)
            .GetSnapshotAsync();

        if (!doc.Exists)
            return;

        var request = doc.ConvertTo<FriendRequest>();

        request.Status = "accepted";

        await doc.Reference.SetAsync(request);

        var friend1 = new Friend
        {
            Id = Guid.NewGuid().ToString(),
            UserId = request.SenderId,
            FriendId = request.ReceiverId,
            CreatedAt = DateTime.UtcNow
        };

        var friend2 = new Friend
        {
            Id = Guid.NewGuid().ToString(),
            UserId = request.ReceiverId,
            FriendId = request.SenderId,
            CreatedAt = DateTime.UtcNow
        };

        await _db.Collection("friends")
            .Document(friend1.Id)
            .SetAsync(friend1);

        await _db.Collection("friends")
            .Document(friend2.Id)
            .SetAsync(friend2);
    }

    public async Task RejectRequestAsync(string requestId)
    {
        await _db.Collection("friend_requests")
            .Document(requestId)
            .DeleteAsync();
    }

    public async Task CancelRequestAsync(string requestId)
    {
        await _db.Collection("friend_requests")
            .Document(requestId)
            .DeleteAsync();
    }

    public async Task<bool> AreFriendsAsync(
        string userId,
        string friendId)
    {
        var snapshot = await _db.Collection("friends")
            .WhereEqualTo("UserId", userId)
            .WhereEqualTo("FriendId", friendId)
            .Limit(1)
            .GetSnapshotAsync();

        return snapshot.Documents.Any();
    }

    public async Task<List<User>> GetFriendsAsync(string userId)
    {
        var friendDocs = await _db.Collection("friends")
            .WhereEqualTo("UserId", userId)
            .GetSnapshotAsync();

        var result = new List<User>();

        foreach (var doc in friendDocs.Documents)
        {
            var friend = doc.ConvertTo<Friend>();

            var userDoc = await _db.Collection("users")
                .Document(friend.FriendId)
                .GetSnapshotAsync();

            if (userDoc.Exists)
            {
                result.Add(userDoc.ConvertTo<User>());
            }
        }

        return result;
    }

    public async Task<List<FriendRequest>> GetPendingRequestsAsync(
        string userId)
    {
        var snapshot = await _db.Collection("friend_requests")
            .WhereEqualTo("ReceiverId", userId)
            .WhereEqualTo("Status", "pending")
            .GetSnapshotAsync();

        return snapshot.Documents
            .Select(x => x.ConvertTo<FriendRequest>())
            .ToList();
    }

    public async Task RemoveFriendAsync(
        string userId,
        string friendId)
    {
        var snapshot = await _db.Collection("friends")
            .WhereEqualTo("UserId", userId)
            .WhereEqualTo("FriendId", friendId)
            .GetSnapshotAsync();

        foreach (var doc in snapshot.Documents)
        {
            await doc.Reference.DeleteAsync();
        }

        var reverseSnapshot = await _db.Collection("friends")
            .WhereEqualTo("UserId", friendId)
            .WhereEqualTo("FriendId", userId)
            .GetSnapshotAsync();

        foreach (var doc in reverseSnapshot.Documents)
        {
            await doc.Reference.DeleteAsync();
        }
    }
}