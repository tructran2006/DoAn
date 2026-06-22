using DoAn.Models;
using DoAn.Models.Entities;

namespace DoAn.Services.Interfaces;

public interface ICommentService
{
    Task<Comment?> GetByIdAsync(string commentId);

    Task<List<Comment>> GetPostCommentsAsync(string postId);

    Task<List<Comment>> GetRepliesAsync(string parentCommentId);

    Task CreateAsync(Comment comment);

    Task UpdateAsync(Comment comment);

    Task DeleteAsync(string commentId);
}