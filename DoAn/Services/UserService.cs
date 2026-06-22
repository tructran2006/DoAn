using DoAn.Models;

using DoAn.Services.Interfaces;
using Google.Cloud.Firestore;

namespace DoAn.Services;

public class UserService : IUserService
{
    private readonly FirestoreDb _db;

    public UserService(FirebaseService firebase)
    {
        _db = firebase.Db;
    }

    public async Task CreateAsync(User user)
    {
        await _db.Collection("users")
            .Document(user.Id)
            .SetAsync(user);
    }

    public async Task<User?> GetByIdAsync(string userId)
    {
        var doc = await _db.Collection("users")
            .Document(userId)
            .GetSnapshotAsync();

        return doc.Exists
            ? doc.ConvertTo<User>()
            : null;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var snapshot = await _db.Collection("users")
            .WhereEqualTo("Email", email)
            .Limit(1)
            .GetSnapshotAsync();

        return snapshot.Documents.FirstOrDefault()?.ConvertTo<User>();
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        var snapshot = await _db.Collection("users")
            .WhereEqualTo("Username", username)
            .Limit(1)
            .GetSnapshotAsync();

        return snapshot.Documents.FirstOrDefault()?.ConvertTo<User>();
    }

    public async Task<List<User>> SearchUsersAsync(string keyword)
    {
        var snapshot = await _db.Collection("users")
            .GetSnapshotAsync();

        return snapshot.Documents
            .Select(x => x.ConvertTo<User>())
            .Where(x => x.Username.Contains(keyword))
            .ToList();
    }

    public async Task UpdateAsync(User user)
    {
        await _db.Collection("users")
            .Document(user.Id)
            .SetAsync(user);
    }

    public async Task DeleteAsync(string userId)
    {
        await _db.Collection("users")
            .Document(userId)
            .DeleteAsync();
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await GetByEmailAsync(email) != null;
    }

    public async Task<bool> ExistsByUsernameAsync(string username)
    {
        return await GetByUsernameAsync(username) != null;
    }
}