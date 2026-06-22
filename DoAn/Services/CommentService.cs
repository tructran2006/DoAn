using DoAn.Models;

using DoAn.Services.Interfaces;
using Google.Cloud.Firestore;

namespace DoAn.Services;

public class CommentService : ICommentService
{
    private readonly FirestoreDb _db;

    public CommentService(FirebaseService firebase)
    {
        _db = firebase.Db;
    }

    public async Task CreateAsync(Comment comment)
    {
        await _db.Collection("comments")
            .Document(comment.Id)
            .SetAsync(comment);
    }

    public async Task<Comment?> GetByIdAsync(string commentId)
    {
        var doc = await _db.Collection("comments")
            .Document(commentId)
            .GetSnapshotAsync();

        return doc.Exists
            ? doc.ConvertTo<Comment>()
            : null;
    }

    public async Task<List<Comment>> GetPostCommentsAsync(string postId)
    {
        var snapshot = await _db.Collection("comments")
            .WhereEqualTo("PostId", postId)
            .GetSnapshotAsync();

        return snapshot.Documents
            .Select(x => x.ConvertTo<Comment>())
            .ToList();
    }

    public async Task<List<Comment>> GetRepliesAsync(string parentCommentId)
    {
        var snapshot = await _db.Collection("comments")
            .WhereEqualTo("ParentCommentId", parentCommentId)
            .GetSnapshotAsync();

        return snapshot.Documents
            .Select(x => x.ConvertTo<Comment>())
            .ToList();
    }

    public async Task UpdateAsync(Comment comment)
    {
        await _db.Collection("comments")
            .Document(comment.Id)
            .SetAsync(comment);
    }

    public async Task DeleteAsync(string commentId)
    {
        await _db.Collection("comments")
            .Document(commentId)
            .DeleteAsync();
    }
}