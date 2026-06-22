using DoAn.Models;
using DoAn.Models.Entities;

namespace DoAn.Services.Interfaces;

public interface IUserService
{
    Task<User?> GetByIdAsync(string userId);

    Task<User?> GetByEmailAsync(string email);

    Task<User?> GetByUsernameAsync(string username);

    Task<List<User>> SearchUsersAsync(string keyword);

    Task CreateAsync(User user);

    Task UpdateAsync(User user);

    Task DeleteAsync(string userId);

    Task<bool> ExistsByEmailAsync(string email);

    Task<bool> ExistsByUsernameAsync(string username);
}