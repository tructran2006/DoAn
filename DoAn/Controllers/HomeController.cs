using Microsoft.AspNetCore.Mvc;
using DoAn.Services;

public class HomeController : Controller
{
    private readonly FirebaseService _firebaseService;

    public HomeController(FirebaseService firebaseService)
    {
        _firebaseService = firebaseService;
    }

    public async Task<IActionResult> TestConnection()
    {
        try
        {
            // Thử lấy danh sách bài viết
            var posts = await _firebaseService.GetPosts();
            return Content("Kết nối thành công! Số lượng bài viết hiện có là: " + posts.Count);
        }
        catch (Exception ex)
        {
            return Content("Kết nối thất bại. Lỗi: " + ex.Message);
        }
    }

    public IActionResult Index() => View();
}