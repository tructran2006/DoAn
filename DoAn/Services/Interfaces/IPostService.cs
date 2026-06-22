using DoAn.Models;
using Microsoft.Extensions.Hosting;

namespace DoAn.Services.Interfaces;

public interface IPostService
{
    Task<Post?> GetByIdAsync(string postId);

    Task<List<Post>> GetFeedAsync(int limit = 20);

    Task<List<Post>> GetUserPostsAsync(string userId);

    Task CreateAsync(Post post);

    Task UpdateAsync(Post post);

    Task DeleteAsync(string postId);

    Task IncrementLikeCountAsync(string postId);

    Task DecrementLikeCountAsync(string postId);

    Task IncrementCommentCountAsync(string postId);

    Task IncrementShareCountAsync(string postId);
}