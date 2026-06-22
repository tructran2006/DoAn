using DoAn.Models;

using DoAn.Services.Interfaces;
using Google.Cloud.Firestore;

namespace DoAn.Services;

public class ReactionService : IReactionService
{
    private readonly FirestoreDb _db;

    public ReactionService(FirebaseService firebase)
    {
        _db = firebase.Db;
    }

    public async Task<PostReaction?> GetUserReactionAsync(
        string postId,
        string userId)
    {
        var snapshot = await _db.Collection("post_reactions")
            .WhereEqualTo("PostId", postId)
            .WhereEqualTo("UserId", userId)
            .Limit(1)
            .GetSnapshotAsync();

        return snapshot.Documents
            .FirstOrDefault()
            ?.ConvertTo<PostReaction>();
    }

    public async Task ToggleLikeAsync(
        string postId,
        string userId)
    {
        var existing = await GetUserReactionAsync(
            postId,
            userId);

        if (existing != null)
        {
            await RemoveReactionAsync(postId, userId);
            return;
        }

        var reaction = new PostReaction
        {
            Id = Guid.NewGuid().ToString(),
            PostId = postId,
            UserId = userId,
            Type = "Like",
            CreatedAt = DateTime.UtcNow
        };

        await _db.Collection("post_reactions")
            .Document(reaction.Id)
            .SetAsync(reaction);
    }

    public async Task RemoveReactionAsync(
        string postId,
        string userId)
    {
        var snapshot = await _db.Collection("post_reactions")
            .WhereEqualTo("PostId", postId)
            .WhereEqualTo("UserId", userId)
            .GetSnapshotAsync();

        foreach (var doc in snapshot.Documents)
        {
            await doc.Reference.DeleteAsync();
        }
    }

    public async Task<int> GetReactionCountAsync(
        string postId)
    {
        var snapshot = await _db.Collection("post_reactions")
            .WhereEqualTo("PostId", postId)
            .GetSnapshotAsync();

        return snapshot.Count;
    }
}