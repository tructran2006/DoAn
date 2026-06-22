using DoAn.Models;
using DoAn.Services.Interfaces;
using Google.Cloud.Firestore;
using Microsoft.Extensions.Hosting;

namespace DoAn.Services;

public class PostService : IPostService
{
    private readonly FirestoreDb _db;

    public PostService(FirebaseService firebase)
    {
        _db = firebase.Db;
    }

    public async Task CreateAsync(Post post)
    {
        await _db.Collection("posts")
            .Document(post.Id)
            .SetAsync(post);
    }

    public async Task<Post?> GetByIdAsync(string postId)
    {
        var doc = await _db.Collection("posts")
            .Document(postId)
            .GetSnapshotAsync();

        return doc.Exists
            ? doc.ConvertTo<Post>()
            : null;
    }

    public async Task<List<Post>> GetFeedAsync(int limit = 20)
    {
        var snapshot = await _db.Collection("posts")
            .OrderByDescending("CreatedAt")
            .Limit(limit)
            .GetSnapshotAsync();

        return snapshot.Documents
            .Select(x => x.ConvertTo<Post>())
            .ToList();
    }

    public async Task<List<Post>> GetUserPostsAsync(string userId)
    {
        var snapshot = await _db.Collection("posts")
            .WhereEqualTo("UserId", userId)
            .GetSnapshotAsync();

        return snapshot.Documents
            .Select(x => x.ConvertTo<Post>())
            .ToList();
    }

    public async Task UpdateAsync(Post post)
    {
        await _db.Collection("posts")
            .Document(post.Id)
            .SetAsync(post);
    }

    public async Task DeleteAsync(string postId)
    {
        await _db.Collection("posts")
            .Document(postId)
            .DeleteAsync();
    }

    public async Task IncrementLikeCountAsync(string postId)
    {
        await _db.Collection("posts")
            .Document(postId)
            .UpdateAsync("LikeCount", FieldValue.Increment(1));
    }

    public async Task DecrementLikeCountAsync(string postId)
    {
        await _db.Collection("posts")
            .Document(postId)
            .UpdateAsync("LikeCount", FieldValue.Increment(-1));
    }

    public async Task IncrementCommentCountAsync(string postId)
    {
        await _db.Collection("posts")
            .Document(postId)
            .UpdateAsync("CommentCount", FieldValue.Increment(1));
    }

    public async Task IncrementShareCountAsync(string postId)
    {
        await _db.Collection("posts")
            .Document(postId)
            .UpdateAsync("ShareCount", FieldValue.Increment(1));
    }
}